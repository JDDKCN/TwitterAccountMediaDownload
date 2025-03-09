using System.Globalization;
using TAMDownload.Config;

namespace TAMDownload.Core.Services
{
    public class ContentFilter
    {
        private readonly App _config;

        public ContentFilter(App config)
        {
            _config = config;
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

        public (bool state, string? firstBlockedWord) CheckBlockedWords(string text, List<string> blockedWords)
        {
            if (string.IsNullOrEmpty(text) || blockedWords == null || blockedWords.Count == 0)
                return (true, null);
                
            var foundWord = blockedWords.FirstOrDefault(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));
            return foundWord == null ? (true, null) : (false, foundWord);
        }
    }
}
