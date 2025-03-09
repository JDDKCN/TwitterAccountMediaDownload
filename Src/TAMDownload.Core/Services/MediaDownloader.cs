using System.Globalization;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class MediaDownloader
    {
        private readonly HttpClientWrapper _http;
        private readonly int _timeoutSeconds;
        private readonly int _maxRetries;

        public MediaDownloader(HttpClientWrapper http, int timeoutSeconds = 30, int maxRetries = 3)
        {
            _http = http;
            _timeoutSeconds = timeoutSeconds;
            _maxRetries = maxRetries;
        }

        public async Task<bool> DownloadSingleMediaAsync(
            Media media,
            string tweetId,
            string userId,
            List<string> hashtags,
            int index,
            App.GetTypes type,
            string screenName,
            string name,
            string text,
            string basePath)
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
                var mediaPath = Path.Combine(basePath, type.ToString(), $"{name} @{screenName}", media.Type);

                if (!Directory.Exists(mediaPath))
                {
                    Directory.CreateDirectory(mediaPath);
                }

                var filePath = Path.Combine(mediaPath, fileName);

                if (File.Exists(filePath))
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileIsExist} : {filePath}");
                    return true;
                }

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(_timeoutSeconds));

                if (await DownloadWithRetryAsync(media.Url, filePath, cts.Token))
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskCompleted} : {filePath}");
                    return true;
                }
                else
                {
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskErrorRetry, filePath, _maxRetries));
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.FileDownloadTaskError} : {ex.Message}");
                return false;
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
                                await Task.Delay(1000 * attempt, ct);
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
    }
}
