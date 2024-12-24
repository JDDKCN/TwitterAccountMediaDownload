using System.Text.Json;
using TAMDownload.Config;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class TwitterApiService
    {
        private readonly HttpClientWrapper _http;
        private readonly App _config;
        private const string Host = "https://x.com";
        private const string LikeUrl = Host + "/i/api/graphql/oLLzvV4gwmdq_nhPM4cLwg/Likes";
        private const string BookmarkUrl = Host + "/i/api/graphql/Ds7FCVYEIivOKHsGcE84xQ/Bookmarks";

        public TwitterApiService(HttpClientWrapper http, App config)
        {
            _http = http;
            _config = config;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public static string? UserId { get; set; }

        public Dictionary<string, TwitterUser> Users { get; } = new();

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
                cursor = cursor
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = GetLikeFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            try
            {
                // 创建请求消息
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(LikeUrl, parameters));

                // 设置请求头
                request.Headers.Add("Authorization", "Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA");
                request.Headers.Add("Referer", $"https://x.com/{_config.UserName}/likes");
                request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
                request.Headers.Add("x-twitter-active-user", "yes");
                request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
                request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));

                // 发送请求并获取响应
                var response = await _http.SendRequestAsync<GraphQLResponse>(request);

                //var options = new JsonSerializerOptions
                //{
                //    WriteIndented = true,
                //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                //};
                //var jsonString = JsonSerializer.Serialize(response, options);
                //Console.WriteLine("Response JSON:");
                //Console.WriteLine(jsonString);

                var tweets = new List<Tweet>();
                string nextPage = cursor;

                //Console.WriteLine($"Instructions count: {response.Data.User.Result.TimelineV2.Timeline.Instructions.Count}");
                //Console.WriteLine($"First instruction type: {response.Data.User.Result.TimelineV2.Timeline.Instructions[0].Type}");
                //Console.WriteLine($"Entries count: {response.Data.User.Result.TimelineV2.Timeline.Instructions[0].Entries.Count}");

                foreach (var instruction in response.Data.User.Result.TimelineV2.Timeline.Instructions)
                {
                    if (instruction.Type != "TimelineAddEntries") continue;

                    foreach (var entry in instruction.Entries)
                    {
                        Console.WriteLine($"Processing entry: {entry.EntryId}");

                        if (entry.EntryId.StartsWith("tweet-"))
                        {
                            var tweet = ProcessTweet(entry);
                            if (tweet != null)
                            {
                                tweets.Add(tweet);
                                Console.WriteLine($"Added tweet: {tweet.Id}");
                            }
                        }
                        else if (entry.EntryId.StartsWith("cursor-bottom-"))
                        {
                            nextPage = entry.Content.Value;
                            Console.WriteLine($"Found next page: {nextPage}");
                        }
                    }
                }

                Console.WriteLine($"Processed {tweets.Count} tweets");
                return (tweets, nextPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting likes: {ex.Message}");
                return (new List<Tweet>(), string.Empty);
            }
        }

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
                ["features"] = GetBookmarkFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(BookmarkUrl, parameters));

                // 设置请求头
                request.Headers.Add("Authorization", "Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA");
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
                        Console.WriteLine($"Processing entry: {entry.EntryId}");

                        if (entry.EntryId.StartsWith("tweet-"))
                        {
                            var tweet = ProcessTweet(entry);
                            if (tweet != null)
                            {
                                tweets.Add(tweet);
                                Console.WriteLine($"Added tweet: {tweet.Id}");
                            }
                        }
                        else if (entry.EntryId.StartsWith("cursor-bottom-"))
                        {
                            nextPage = entry.Content.Value;
                            Console.WriteLine($"Found next page: {nextPage}");
                        }
                    }
                }

                return (tweets, nextPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting bookmarks: {ex.Message}");
                return (new List<Tweet>(), string.Empty);
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
                Users[userId] = new TwitterUser
                {
                    Id = userId,
                    ScreenName = userInfo.Legacy.ScreenName,
                    Name = userInfo.Legacy.Name,
                    Description = userInfo.Legacy.Description,
                    CreatedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                };

                Console.WriteLine($"Processing tweet from user: {userInfo.Legacy.ScreenName}");

                return new Tweet
                {
                    Id = tweetData.RestId,
                    UserId = userId,  // 设置UserId
                    Text = tweetData.Legacy?.FullText ?? string.Empty,
                    Hashtags = tweetData.Legacy?.Entities?.Hashtags
                        ?.Select(h => h.Text)
                        ?.ToList() ?? new List<string>(),
                    Media = ProcessMedia(tweetData.Legacy?.Entities?.Media)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing tweet: {ex.Message}");
                return null;
            }
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

        private string GetLikeFeatures() =>
            "{\"profile_label_improvements_pcf_label_in_post_enabled\":false," +
            "\"rweb_tipjar_consumption_enabled\":true," +
            "\"responsive_web_graphql_exclude_directive_enabled\":true," +
            "\"verified_phone_label_enabled\":false," +
            "\"creator_subscriptions_tweet_preview_api_enabled\":true," +
            "\"responsive_web_graphql_timeline_navigation_enabled\":true," +
            "\"responsive_web_graphql_skip_user_profile_image_extensions_enabled\":false," +
            "\"premium_content_api_read_enabled\":false," +
            "\"communities_web_enable_tweet_community_results_fetch\":true," +
            "\"c9s_tweet_anatomy_moderator_badge_enabled\":true," +
            "\"responsive_web_grok_analyze_button_fetch_trends_enabled\":true," +
            "\"articles_preview_enabled\":true," +
            "\"responsive_web_edit_tweet_api_enabled\":true," +
            "\"graphql_is_translatable_rweb_tweet_is_translatable_enabled\":true," +
            "\"view_counts_everywhere_api_enabled\":true," +
            "\"longform_notetweets_consumption_enabled\":true," +
            "\"responsive_web_twitter_article_tweet_consumption_enabled\":true," +
            "\"tweet_awards_web_tipping_enabled\":false," +
            "\"creator_subscriptions_quote_tweet_preview_enabled\":false," +
            "\"freedom_of_speech_not_reach_fetch_enabled\":true," +
            "\"standardized_nudges_misinfo\":true," +
            "\"tweet_with_visibility_results_prefer_gql_limited_actions_policy_enabled\":true," +
            "\"rweb_video_timestamps_enabled\":true," +
            "\"longform_notetweets_rich_text_read_enabled\":true," +
            "\"longform_notetweets_inline_media_enabled\":true," +
            "\"responsive_web_enhance_cards_enabled\":false}";

        private string GetBookmarkFeatures() =>
            "{\"graphql_timeline_v2_bookmark_timeline\":true," +
            "\"profile_label_improvements_pcf_label_in_post_enabled\":false," +
            "\"rweb_tipjar_consumption_enabled\":true," +
            "\"responsive_web_graphql_exclude_directive_enabled\":true," +
            "\"verified_phone_label_enabled\":false," +
            "\"creator_subscriptions_tweet_preview_api_enabled\":true," +
            "\"responsive_web_graphql_timeline_navigation_enabled\":true," +
            "\"responsive_web_graphql_skip_user_profile_image_extensions_enabled\":false," +
            "\"premium_content_api_read_enabled\":false," +
            "\"communities_web_enable_tweet_community_results_fetch\":true," +
            "\"c9s_tweet_anatomy_moderator_badge_enabled\":true," +
            "\"responsive_web_grok_analyze_button_fetch_trends_enabled\":false," +
            "\"articles_preview_enabled\":true," +
            "\"responsive_web_edit_tweet_api_enabled\":true," +
            "\"graphql_is_translatable_rweb_tweet_is_translatable_enabled\":true," +
            "\"view_counts_everywhere_api_enabled\":true," +
            "\"longform_notetweets_consumption_enabled\":true," +
            "\"responsive_web_twitter_article_tweet_consumption_enabled\":true," +
            "\"tweet_awards_web_tipping_enabled\":false," +
            "\"creator_subscriptions_quote_tweet_preview_enabled\":false," +
            "\"freedom_of_speech_not_reach_fetch_enabled\":true," +
            "\"standardized_nudges_misinfo\":true," +
            "\"tweet_with_visibility_results_prefer_gql_limited_actions_policy_enabled\":true," +
            "\"rweb_video_timestamps_enabled\":true," +
            "\"longform_notetweets_rich_text_read_enabled\":true," +
            "\"longform_notetweets_inline_media_enabled\":true," +
            "\"responsive_web_enhance_cards_enabled\":false}";
    }
}
