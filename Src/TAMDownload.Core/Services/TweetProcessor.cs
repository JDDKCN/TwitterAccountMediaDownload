using TAMDownload.Config.Language;
using TAMDownload.Core.Models;

namespace TAMDownload.Core.Services
{
    public class TweetProcessor
    {
        private readonly Dictionary<string, TwitterUser> _users;

        public TweetProcessor(Dictionary<string, TwitterUser> users)
        {
            _users = users;
        }

        public Tweet ProcessTweet(TimelineEntry entry)
        {
            try
            {
                var tweetResult = entry.Content.ItemContent.TweetResults.Result;
                if (tweetResult == null || tweetResult.Tombstone != null)
                    return null;

                var tweetData = tweetResult.Tweet ?? tweetResult;
                var userInfo = tweetData.Core.UserResults.Result;
                var userId = userInfo.RestId;  // 使用rest_id作为用户ID

                // 维护Users字典
                UpdateUserInfo(userId, userInfo);

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessingTweetFromUser, userInfo.Legacy.ScreenName));

                return new Tweet
                {
                    Id = tweetData.RestId,
                    UserId = userId,  // 设置UserId
                    Text = tweetData.Legacy?.FullText ?? string.Empty,
                    Hashtags = tweetData.Legacy?.Entities?.Hashtags
                        ?.Select(h => h.Text)
                        ?.ToList() ?? new List<string>(),
                    CreatedAt = tweetData.Legacy?.CreatedAt,
                    Media = ProcessMedia(tweetData.Legacy?.Entities?.Media)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tweet - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return null;
            }
        }

        public List<Tweet> ProcessTweetUserMedia01(TimelineEntry entry)
        {
            var tweets = new List<Tweet>();

            try
            {
                if (entry.Content.Items == null) return tweets;

                foreach (var item in entry.Content.Items)
                {
                    if (item?.Item?.ItemContent?.TweetResults?.Result == null)
                        continue;

                    var tweetResult = item.Item.ItemContent.TweetResults.Result;
                    if (tweetResult.Tombstone != null)
                        continue;

                    var userInfo = tweetResult.Core.UserResults.Result;
                    var userId = userInfo.RestId;

                    // 维护Users字典
                    UpdateUserInfo(userId, userInfo);

                    var tweet = new Tweet
                    {
                        Id = tweetResult.RestId,
                        UserId = userId,
                        Text = tweetResult.Legacy?.FullText ?? string.Empty,
                        Hashtags = tweetResult.Legacy?.Entities?.Hashtags
                            ?.Select(h => h.Text)
                            ?.ToList() ?? new List<string>(),
                        CreatedAt = tweetResult.Legacy?.CreatedAt,
                        Media = ProcessMedia(tweetResult.Legacy?.ExtendedEntities?.Media)
                    };

                    tweets.Add(tweet);
                }

                return tweets;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tweet - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return tweets;
            }
        }

        public Tweet ProcessTweetUserMedia02(ItemMedia entry)
        {
            try
            {
                var tweetResult = entry.Item.ItemContent.TweetResults.Result;
                if (tweetResult == null)
                    return null;

                var tweetData = tweetResult;
                var userInfo = tweetData.Core.UserResults.Result;
                var userId = userInfo.RestId;

                // 维护Users字典
                UpdateUserInfo(userId, userInfo);

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessingTweetFromUser, userInfo.Legacy.ScreenName));

                return new Tweet
                {
                    Id = tweetData.RestId,
                    UserId = userId,
                    Text = tweetData.Legacy?.FullText ?? string.Empty,
                    Hashtags = tweetData.Legacy?.Entities?.Hashtags
                        ?.Select(h => h.Text)
                        ?.ToList() ?? new List<string>(),
                    CreatedAt = tweetData.Legacy?.CreatedAt,
                    Media = ProcessMedia(tweetData.Legacy?.Entities?.Media)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tweet - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return null;
            }
        }

        private void UpdateUserInfo(string userId, UserResultInfo userInfo)
        {
            _users[userId] = new TwitterUser
            {
                Id = userId,
                ScreenName = userInfo.Legacy.ScreenName,
                Name = userInfo.Legacy.Name,
                Description = userInfo.Legacy.Description,
                CreatedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
        }

        private List<Media> ProcessMedia(List<MediaEntity> mediaEntities)
        {
            if (mediaEntities == null) return new List<Media>();

            return mediaEntities.Select(m => new Media
            {
                Type = m.Type,
                Url = m.Type == "photo"
                    ? GetOriginalImageUrl(m.MediaUrlHttps)
                    : GetHighestQualityVideoUrl(m.VideoInfo),
                Bitrate = m.Type == "video"
                    ? GetHighestBitrate(m.VideoInfo)
                    : null
            }).ToList();
        }

        private string GetOriginalImageUrl(string url)
        {
            var parts = url.Split('.');
            var ext = parts.Last();
            var basePath = string.Join(".", parts.Take(parts.Length - 1));
            return $"{basePath}?format={ext}&name=orig";
        }

        private string GetHighestQualityVideoUrl(VideoInfo videoInfo)
        {
            return videoInfo.Variants
                .Where(v => v.Bitrate.HasValue)
                .OrderByDescending(v => v.Bitrate)
                .First()
                .Url;
        }

        private long? GetHighestBitrate(VideoInfo videoInfo)
        {
            return videoInfo.Variants
                .Where(v => v.Bitrate.HasValue)
                .Max(v => v.Bitrate);
        }
    }
}
