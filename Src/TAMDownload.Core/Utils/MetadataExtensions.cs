using System.Text.Json;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Models;

namespace TAMDownload.Core.Utils
{
    public static class MetadataExtensions
    {
        public static readonly string MetadataBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "metadata");

        public static string MetadataFile(App.GetTypes type, string? accountName) => type switch
        {
            App.GetTypes.Likes => Path.Combine(MetadataBaseDir, "likes_metadata.json"),
            App.GetTypes.BookMarks => Path.Combine(MetadataBaseDir, "bookmarks_metadata.json"),
            App.GetTypes.Account => Path.Combine(MetadataBaseDir, $"account_{accountName ?? "UnName"}_metadata.json"),
            _ => Path.Combine(MetadataBaseDir, "metadata.json")
        };

        public static MetadataContainer LoadMetadata(App.GetTypes type, string? accountName = null)
        {
            if(!Directory.Exists(MetadataBaseDir)) 
                Directory.CreateDirectory(MetadataBaseDir);

            if (!File.Exists(MetadataFile(type, accountName)))
                return new MetadataContainer();

            var json = File.ReadAllText(MetadataFile(type, accountName));
            return JsonSerializer.Deserialize<MetadataContainer>(json) ?? new MetadataContainer();
        }

        public static void SaveMetadata(MetadataContainer metadata, App.GetTypes type, string? accountName = null)
        {
            if (!Directory.Exists(MetadataBaseDir))
                Directory.CreateDirectory(MetadataBaseDir);

            var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(MetadataFile(type, accountName), json);
        }

        public static void MergeMetadata(MetadataContainer existing, MetadataContainer newData)
        {
            existing.CurrentPage = newData.CurrentPage;

            foreach (var (userId, userData) in newData.Users)
            {
                if (!existing.Users.ContainsKey(userId))
                {
                    existing.Users[userId] = userData;
                    continue;
                }

                // 合并用户历史
                existing.Users[userId].UserHistory.AddRange(userData.UserHistory);

                // 合并推文，避免重复
                foreach (var tweet in userData.Tweets)
                {
                    if (!existing.Users[userId].Tweets.Any(t => t.Id == tweet.Id))
                    {
                        existing.Users[userId].Tweets.Add(tweet);
                    }
                }
            }
        }

        public static MetadataContainer ToMetadataContainer(
            this List<Tweet> tweets,
            string currentPage,
            Dictionary<string, TwitterUser> users)
        {
            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ConvertingTweets, tweets.Count));
            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.AvailableUsers, users.Count));

            var metadata = new MetadataContainer
            {
                CurrentPage = currentPage,
                Users = new Dictionary<string, MetadataContainer.UserData>()
            };

            foreach (var tweet in tweets)
            {
                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.ProcessingTweet, tweet.Id));

                // 使用tweet的用户ID找到对应的用户信息
                var userId = tweet.UserId;
                if (!users.TryGetValue(userId, out var user))
                {
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.UserNotFound, tweet.Id));
                    continue;
                }

                if (!metadata.Users.ContainsKey(userId))
                {
                    metadata.Users[userId] = new MetadataContainer.UserData
                    {
                        UserHistory = new List<TwitterUser> { user },
                        Tweets = new List<Tweet>()
                    };
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.CreatedNewUserEntry, user.ScreenName));
                }

                metadata.Users[userId].Tweets.Add(tweet);
                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.AddedTweetForUser, user.ScreenName));
            }

            Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.MetadataConversionComplete, metadata.Users.Count));
            return metadata;
        }
    }
}
