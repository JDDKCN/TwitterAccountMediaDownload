using System.Globalization;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class DownloadService
    {
        private readonly App _config;
        private readonly HttpClientWrapper _http;
        private readonly string _basePath;
        private readonly int _timeoutSeconds; 
        private readonly int _maxRetries;
        
        // 辅助类
        private readonly MediaDownloader _mediaDownloader;
        private readonly ContentFilter _contentFilter;

        public int VideosNum { get; private set; } = 0;
        public int PhotosNum { get; private set; } = 0;
        public int GIFsNum { get; private set; } = 0;

        public DownloadService(App config, HttpClientWrapper http, string basePath, int timeoutSeconds = 30, int maxRetries = 3)
        {
            _config = config;
            _http = http;
            _basePath = Path.GetFullPath(basePath);
            _timeoutSeconds = timeoutSeconds; // 超时时间(s)
            _maxRetries = maxRetries;     // 最大重试次数
            
            // 初始化辅助类
            _mediaDownloader = new MediaDownloader(http, timeoutSeconds, maxRetries);
            _contentFilter = new ContentFilter(config);
        }

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

                    // 使用内容过滤器检查日期范围
                    if (!_contentFilter.IsInDateRange(tweet.CreatedAt))
                    {
                        Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.SkipDateRangeTweet, tweet.CreatedAt, text));
                        continue;
                    }

                    // 使用内容过滤器检查屏蔽词
                    if (_config.SkipTweetBlockedWords.IsEnable)
                    {
                        var (state, firstBlockedWord) = _contentFilter.CheckBlockedWords(tweet.Text, _config.SkipTweetBlockedWords.BlockedWords);
                        if (!state)
                        {
                            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.SkipBlockedWordsTweet, firstBlockedWord, text));
                            continue;
                        }
                    }

                    await ProcessTweetMediaAsync(tweet, userId, type, downloadType, screenName, name, text);
                }
            }
        }

        private async Task ProcessTweetMediaAsync(Tweet tweet, string userId, App.GetTypes type, List<App.DownloadTypes> downloadType, string screenName, string name, string text)
        {
            var index = 1;
            foreach (var media in tweet.Media)
            {
                bool downloadResult = false;
                
                if (downloadType.Contains(App.DownloadTypes.Photo) && media.Type == "photo")
                {
                    downloadResult = await _mediaDownloader.DownloadSingleMediaAsync(
                        media,
                        tweet.Id,
                        userId,
                        tweet.Hashtags,
                        index++,
                        type,
                        screenName,
                        name,
                        text,
                        _basePath);

                    if (downloadResult)
                        PhotosNum++;
                }

                if (downloadType.Contains(App.DownloadTypes.Video) && media.Type == "video")
                {
                    downloadResult = await _mediaDownloader.DownloadSingleMediaAsync(
                        media,
                        tweet.Id,
                        userId,
                        tweet.Hashtags,
                        index++,
                        type,
                        screenName,
                        name,
                        text,
                        _basePath);

                    if (downloadResult)
                        VideosNum++;
                }

                if (downloadType.Contains(App.DownloadTypes.AnimatedGif) && media.Type == "animated_gif")
                {
                    downloadResult = await _mediaDownloader.DownloadSingleMediaAsync(
                        media,
                        tweet.Id,
                        userId,
                        tweet.Hashtags,
                        index++,
                        type,
                        screenName,
                        name,
                        text,
                        _basePath);

                    if (downloadResult)
                        GIFsNum++;
                }
            }
        }

      
        public bool IsInDateRange(string? tweetCreatedAt)
        {
            return _contentFilter.IsInDateRange(tweetCreatedAt);
        }

        public (bool state, string? firstBlockedWord) CheckText(string text, List<string> BlockedWords)
        {
            return _contentFilter.CheckBlockedWords(text, BlockedWords);
        }
    }
}
