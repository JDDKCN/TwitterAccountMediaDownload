using System.Text.Json;
using TAMDownload.Config.Language;
using TAMDownload.Core.Constants;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class TwitterApiService
    {
        private readonly HttpClientWrapper _http;
        private const string Host = "https://x.com";
        private const string LikeUrl = Host + "/i/api/graphql/oLLzvV4gwmdq_nhPM4cLwg/Likes";
        private const string BookmarkUrl = Host + "/i/api/graphql/Ds7FCVYEIivOKHsGcE84xQ/Bookmarks";
        private const string UserMediaUrl = Host + "/i/api/graphql/BGmkmGDG0kZPM-aoQtNTTw/UserMedia";
        private const string ProfileSpotlightsUrl = Host + "/i/api/graphql/-0XdHI-mrHWBQd8-oLo1aA/ProfileSpotlightsQuery";
        private const string TweetDetailUrl = Host + "/i/api/graphql/tivxwX7ezCWlYBkrhxoR0A/TweetDetail";
        private const string Bearer = "AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA";

        /// <summary>
        /// 用户ID
        /// </summary>
        public static string? UserId { get; set; }

        public Dictionary<string, TwitterUser> Users { get; } = new();

        public TwitterApiService(HttpClientWrapper http)
        {
            _http = http;
        }

        /// <summary>
        /// 获取点赞媒体
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="fullGet"></param>
        /// <returns></returns>
        public async Task<(List<Tweet> Tweets, string NextPage)> GetLikesAsync(
            string cursor = "",
            int count = 50,
            bool fullGet = true)
        {
            var variables = new
            {
                userId = UserId,
                count,
                includePromotedContent = false,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetLikeFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(LikeUrl, parameters));

                request.Headers.Add("Authorization", $"Bearer {Bearer}");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                var tweets = new List<Tweet>();
                string nextPage = cursor;

                foreach (var instruction in response.Data.User.Result.TimelineV2.Timeline.Instructions)
                {
                    if (instruction.Type != "TimelineAddEntries") continue;

                    foreach (var entry in instruction.Entries)
                    {
                        Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessingEntry, entry.EntryId));

                        if (entry.EntryId.StartsWith("tweet-"))
                        {
                            var tweet = ProcessTweet(entry);
                            if (tweet != null)
                            {
                                tweets.Add(tweet);
                                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.AddedTweet, tweet.Id));
                            }
                        }
                        else if (entry.EntryId.StartsWith("cursor-bottom-"))
                        {
                            nextPage = entry.Content.Value;
                            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.FoundNextPage, nextPage));
                        }
                    }
                }

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessedTweetsCount, tweets.Count));
                return (tweets, nextPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Likes} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return (new List<Tweet>(), string.Empty);
            }
        }

        /// <summary>
        /// 获取书签媒体
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="fullGet"></param>
        /// <returns></returns>
        public async Task<(List<Tweet> Tweets, string NextPage)> GetBookmarksAsync(
            string cursor = "",
            int count = 20,
            bool fullGet = true)
        {
            var variables = new
            {
                userId = UserId,
                count,
                includePromotedContent = true,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor,
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetBookmarkFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(BookmarkUrl, parameters));

                request.Headers.Add("Authorization", $"Bearer {Bearer}");
                request.Headers.Add("Referer", $"https://x.com/i/bookmarks");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                var tweets = new List<Tweet>();
                string nextPage = cursor;

                foreach (var instruction in response.Data.BookmarkTimelineV2.Timeline.Instructions)
                {
                    if (instruction.Type != "TimelineAddEntries") continue;

                    foreach (var entry in instruction.Entries)
                    {
                        Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessingEntry, entry.EntryId));

                        if (entry.EntryId.StartsWith("tweet-"))
                        {
                            var tweet = ProcessTweet(entry);
                            if (tweet != null)
                            {
                                tweets.Add(tweet);
                                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.AddedTweet, tweet.Id));
                            }
                        }
                        else if (entry.EntryId.StartsWith("cursor-bottom-"))
                        {
                            nextPage = entry.Content.Value;
                            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.FoundNextPage, nextPage));
                        }
                    }
                }

                return (tweets, nextPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.BookMarks} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return (new List<Tweet>(), string.Empty);
            }
        }

        /// <summary>
        /// 获取单用户媒体
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="fullGet"></param>
        /// <returns></returns>
        public async Task<(List<Tweet> Tweets, string NextPage)> GetUserMediaAsync(
            string userId,
            string cursor = "",
            int count = 20,
            bool fullGet = true)
        {
            var variables = new
            {
                userId,
                count,
                includePromotedContent = false,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetUserMediaFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(UserMediaUrl, parameters));

                request.Headers.Add("Authorization", $"Bearer {Bearer}");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                var tweets = new List<Tweet>();
                string nextPage = cursor;

                foreach (var instruction in response.Data.User.Result.TimelineV2.Timeline.Instructions)
                {
                    if (instruction.Type == "TimelineAddEntries")
                        foreach (var entry in instruction.Entries)
                        {
                            if (entry.EntryId.StartsWith("profile-"))
                            {
                                var tweet = ProcessTweetUserMedia01(entry);
                                if (tweet != null)
                                {
                                    tweets.AddRange(tweet);
                                }
                            }
                            else if (entry.EntryId.StartsWith("cursor-bottom-"))
                            {
                                nextPage = entry.Content.Value;
                                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.FoundNextPage, nextPage));
                            }
                        }

                    if (instruction.Type == "TimelineAddToModule")
                        foreach (var entry in instruction.ModuleItems)
                        {
                            if (entry.EntryId.StartsWith("profile-"))
                            {
                                var tweet = ProcessTweetUserMedia02(entry);
                                if (tweet != null)
                                {
                                    tweets.AddRange(tweet);
                                }
                            }
                        }
                }

                return (tweets, nextPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AccountType} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return (new List<Tweet>(), string.Empty);
            }
        }

        public async Task<List<Tweet>?> GetTweetDetailAsync(string tweetId)
        {
            var variables = new
            {
                focalTweetId = tweetId,
                with_rux_injections = false,
                rankingMode = "Relevance",
                includePromotedContent = true,
                withCommunity = true,
                withQuickPromoteEligibilityTweetFields = true,
                withBirdwatchNotes = true,
                withVoice = true
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetTweetDetailFeatures(),
                ["fieldToggles"] = "{\"withArticleRichContentState\":true,\"withArticlePlainText\":false,\"withGrokAnalyze\":false,\"withDisallowedReplyControls\":false}"
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TweetDetailUrl, parameters));

                request.Headers.Add("Authorization", $"Bearer {Bearer}");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                if (response?.Data?.ThreadedConversationV2?.Instructions == null)
                    return null;

                List<Tweet> tweets = new();
                foreach (var instruction in response.Data.ThreadedConversationV2.Instructions)
                {
                    if (instruction.Type == "TimelineAddEntries")
                        foreach (var entry in instruction.Entries)
                        {
                            if (entry.EntryId.StartsWith("tweet-"))
                            {
                                var tweet = ProcessTweet(entry);
                                if (tweet != null)
                                {
                                    tweets.AddRange(tweet);
                                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.AddedTweet, tweet.Id));
                                }
                            }
                        }
                }

                return tweets;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.TweetType} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 通过用户名获取用户ID
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public async Task<(string? id, string? name, string? screenName)> GetUserIdByScreenNameAsync(string screenName)
        {
            var variables = new
            {
                screen_name = screenName
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables)
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(ProfileSpotlightsUrl, parameters));

                request.Headers.Add("Authorization", $"Bearer {Bearer}");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                return (response?.Data?.UserResultByScreenName?.Result?.RestId,
                    response?.Data?.UserResultByScreenName?.Result?.Legacy?.Name,
                    response?.Data?.UserResultByScreenName?.Result?.Legacy?.ScreenName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetUserAccountID} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return (null, null, null);
            }
        }

        private Tweet ProcessTweet(TimelineEntry entry)
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

        private List<Tweet> ProcessTweetUserMedia01(TimelineEntry entry)
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

        private Tweet ProcessTweetUserMedia02(ItemMedia entry)
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
            Users[userId] = new TwitterUser
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

        private string BuildUrl(string baseUrl, Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Any())
                return baseUrl;

            var queryString = string.Join("&", parameters.Select(p =>
                $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));

            return $"{baseUrl}?{queryString}";
        }
    }
}
