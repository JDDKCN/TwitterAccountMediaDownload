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
        private readonly TwitterRequestBuilder _requestBuilder;
        private readonly TweetProcessor _tweetProcessor;

        /// <summary>
        /// 用户ID
        /// </summary>
        public static string? UserId { get; set; }

        public Dictionary<string, TwitterUser> Users { get; } = new();

        public TwitterApiService(HttpClientWrapper http)
        {
            _http = http;
            _requestBuilder = new TwitterRequestBuilder(http);
            _tweetProcessor = new TweetProcessor(Users);
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
            try
            {
                var request = _requestBuilder.BuildLikesRequest(cursor, count, UserId);
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
                            var tweet = _tweetProcessor.ProcessTweet(entry);
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
            try
            {
                var request = _requestBuilder.BuildBookmarksRequest(cursor, count, UserId);
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
                            var tweet = _tweetProcessor.ProcessTweet(entry);
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
            try
            {
                var request = _requestBuilder.BuildUserMediaRequest(userId, cursor, count);
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
                                var tweet = _tweetProcessor.ProcessTweetUserMedia01(entry);
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
                                var tweet = _tweetProcessor.ProcessTweetUserMedia02(entry);
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
            try
            {
                var request = _requestBuilder.BuildTweetDetailRequest(tweetId);
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
                                var tweet = _tweetProcessor.ProcessTweet(entry);
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
            try
            {
                var request = _requestBuilder.BuildUserIdRequest(screenName);
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
    }
}
