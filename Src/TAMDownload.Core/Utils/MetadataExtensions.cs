using System.Text.Json;
using TAMDownload.Config;
using TAMDownload.Core.Models;

namespace TAMDownload.Core.Utils
{
    public static class MetadataExtensions
    {
        public static string MetadataFile(App.GetTypes type)
        {
            if (type == App.GetTypes.Likes)
            {
                return "likes_metadata.json";
            }
            else if (type == App.GetTypes.BookMarks)
            {
                return "bookmarks_metadata.json";
            }
            else
            {
                return "metadata.json";
            }
        }

        public static MetadataContainer LoadMetadata(App.GetTypes type)
        {
            if (!File.Exists(MetadataFile(type)))
                return new MetadataContainer();

            var json = File.ReadAllText(MetadataFile(type));
            return JsonSerializer.Deserialize<MetadataContainer>(json) ?? new MetadataContainer();
        }

        public static void SaveMetadata(MetadataContainer metadata, App.GetTypes type)
        {
            var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(MetadataFile(type), json);
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
            Console.WriteLine($"Converting {tweets.Count} tweets to metadata");
            Console.WriteLine($"Available users: {users.Count}");

            var metadata = new MetadataContainer
            {
                CurrentPage = currentPage,
                Users = new Dictionary<string, MetadataContainer.UserData>()
            };

            foreach (var tweet in tweets)
            {
                Console.WriteLine($"Processing tweet {tweet.Id}");

                // 使用tweet的用户ID找到对应的用户信息
                var userId = tweet.UserId;
                if (!users.TryGetValue(userId, out var user))
                {
                    Console.WriteLine($"User not found for tweet {tweet.Id}");
                    continue;
                }

                if (!metadata.Users.ContainsKey(userId))
                {
                    metadata.Users[userId] = new MetadataContainer.UserData
                    {
                        UserHistory = new List<TwitterUser> { user },
                        Tweets = new List<Tweet>()
                    };
                    Console.WriteLine($"Created new user entry for {user.ScreenName}");
                }

                metadata.Users[userId].Tweets.Add(tweet);
                Console.WriteLine($"Added tweet for user {user.ScreenName}");
            }

            Console.WriteLine($"Metadata conversion complete. Users count: {metadata.Users.Count}");
            return metadata;
        }
    }
}
