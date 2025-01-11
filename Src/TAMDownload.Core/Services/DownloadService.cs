using System.Globalization;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class DownloadService(App config, HttpClientWrapper http, string basePath, int timeoutSeconds = 30, int maxRetries = 3)
    {
        private readonly App _config = config;
        private readonly HttpClientWrapper _http = http;
        private readonly string _basePath = Path.GetFullPath(basePath);
        private readonly int _timeoutSeconds = timeoutSeconds; // 超时时间(s)
        private readonly int _maxRetries = maxRetries;     // 最大重试次数

        public int VideosNum { get; private set; } = 0;
        public int PhotosNum { get; private set; } = 0;
        public int GIFsNum { get; private set; } = 0;

        public async Task DownloadMediaAsync(MetadataContainer data, App.GetTypes type, List<App.DownloadTypes> downloadType)
        {
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            foreach (var (userId, userData) in data.Users)
            {
                string screenName = userData.UserHistory.FirstOrDefault()?.ScreenName ?? "Unknown";
                string name = FileHelper.RemoveInvalidPathChars(userData.UserHistory.FirstOrDefault()?.Name) ?? "Unknown";

                foreach (var tweet in userData.Tweets)
                {
                    string removeText = FileHelper.RemoveInvalidPathChars(tweet.Text);
                    string text = removeText.Length > 27
                                ? removeText.Substring(0, 27).Replace("\n", " ") + "..."
                                : removeText ?? "Unknown";

                    if (!IsInDateRange(tweet.CreatedAt))
                    {
                        Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.SkipDateRangeTweet, tweet.CreatedAt, text));
                        continue;
                    }

                    if (_config.SkipTweetBlockedWords.IsEnable)
                    {
                        var (state, firstBlockedWord) = CheckText(tweet.Text, _config.SkipTweetBlockedWords.BlockedWords);
                        if (!state)
                        {
                            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.SkipBlockedWordsTweet, firstBlockedWord, text));
                            continue;
                        }
                    }

                    var index = 1;
                    foreach (var media in tweet.Media)
                    {
                        if (downloadType.Contains(App.DownloadTypes.Photo) && media.Type == "photo")
                        {
                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type,
                                screenName,
                                name,
                                text);

                            PhotosNum++;
                        }

                        if (downloadType.Contains(App.DownloadTypes.Video) && media.Type == "video")
                        {
                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type,
                                screenName,
                                name,
                                text);

                            VideosNum++;
                        }

                        if (downloadType.Contains(App.DownloadTypes.AnimatedGif) && media.Type == "animated_gif")
                        {
                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type,
                                screenName,
                                name,
                                text);

                            GIFsNum++;
                        }
                    }
                }
            }
        }

        private async Task DownloadSingleMediaAsync(
            Media media,
            string tweetId,
            string userId,
            List<string> hashtags,
            int index,
            App.GetTypes type,
            string screenName,
            string name,
            string text)
        {
            try
            {
                var tags = string.Join("_", hashtags);
                if (!string.IsNullOrEmpty(tags))
                {
                    tags = $"_{tags}";
                }

                var suffix = FileHelper.GetFileExtension(media.Url);
                var fileName = FileHelper.SafePath($"{text}-{userId}-{tweetId}{tags}_{index}.{suffix}");
                var mediaPath = Path.Combine(_basePath, type.ToString(), $"{name} @{screenName}", media.Type);

                if (!Directory.Exists(mediaPath))
                {
                    Directory.CreateDirectory(mediaPath);
                }

                var filePath = Path.Combine(mediaPath, fileName);

                if (File.Exists(filePath))
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileIsExist} : {filePath}");
                    return;
                }

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(_timeoutSeconds));

                if (await DownloadWithRetryAsync(media.Url, filePath, cts.Token))
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskCompleted} : {filePath}");
                }
                else
                {
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskErrorRetry, filePath, _maxRetries));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskError} : {ex.Message}");
            }
        }

        private async Task<bool> DownloadWithRetryAsync(string url, string filePath, CancellationToken ct)
        {
            for (var attempt = 1; attempt <= _maxRetries; attempt++)
            {
                try
                {
                    using var response = await _http.GetMediaAsync(url, ct);
                    await using var stream = await response.Content.ReadAsStreamAsync(ct);
                    await using var fileStream = File.Create(filePath);
                    await stream.CopyToAsync(fileStream, ct);

                    return true;
                }
                catch (Exception ex)
                {
                    if (attempt < _maxRetries)
                    {
                        string errorMessage = ex is OperationCanceledException
                            ? "TimeOut"
                            : ex.Message;

                        Console.WriteLine(string.Format(
                            LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskErrorRetry2,
                            filePath,
                            attempt,
                            _maxRetries,
                            errorMessage));

                        if (!ct.IsCancellationRequested)
                        {
                            try
                            {
                                await Task.Delay(1000 * attempt, ct); // 指数退避
                            }
                            catch (OperationCanceledException)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public (bool state, string? firstBlockedWord) CheckText(string text, List<string> BlockedWords)
        {
            if (string.IsNullOrEmpty(text) || BlockedWords == null || BlockedWords.Count == 0)
                return (true, null);
            var foundWord = BlockedWords.FirstOrDefault(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));
            return foundWord == null ? (true, null) : (false, foundWord);
        }

        public bool IsInDateRange(string? tweetCreatedAt)
        {
            if (_config.SkipTweetDateRange == null || !_config.SkipTweetDateRange.IsEnable)
                return true;

            if (!_config.SkipTweetDateRange.StartTimestamp.HasValue && !_config.SkipTweetDateRange.EndTimestamp.HasValue)
                return true;

            // 解析推文时间为时间戳 (Twitter服务器响应格式："created_at": "Tue Apr 10 12:00:00 +0000 2024")
            if (!DateTime.TryParseExact(tweetCreatedAt,
                "ddd MMM dd HH:mm:ss +0000 yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime tweetDate))
                return true;

            long tweetTimestamp = ((DateTimeOffset)tweetDate).ToUnixTimeSeconds();

            return (!_config.SkipTweetDateRange.StartTimestamp.HasValue || tweetTimestamp >= _config.SkipTweetDateRange.StartTimestamp) &&
                   (!_config.SkipTweetDateRange.EndTimestamp.HasValue || tweetTimestamp <= _config.SkipTweetDateRange.EndTimestamp);
        }
    }
}
