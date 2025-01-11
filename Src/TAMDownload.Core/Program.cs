using TAMDownload.Config;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;
using static TAMDownload.Core.Utils.MetadataExtensions;

namespace TAMDownload.Core
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                if (!File.Exists(App.JsonPath))
                    App.CreateConfig();

                if (!File.Exists(CookiesSelectConfig.JsonPath))
                    CookiesSelectConfig.CreateConfig();

                var langHelper = LanguageHelper.Instance;
                await langHelper.InitLanguageAsync();

                Console.WriteLine(ConstConfig.Copyright);

                if (LanguageHelper.CurrentLanguage.LanguageCode == "zh_CN")
                {
                    Console.Title = ConstConfig.APPName + ConstConfig.VersionStr + "  [免费软件，禁止倒卖]";
                    Console.WriteLine(ConstConfig.APPName + " - " + ConstConfig.VersionStr + "\n");
                }
                else
                {
                    Console.Title = ConstConfig.APPNameEn + ConstConfig.VersionStr + "  [免费软件/Free Software]";
                    Console.WriteLine(ConstConfig.APPNameEn + " - " + ConstConfig.VersionStr + "\n");
                }

                var config = App.ReadConfig();
                var cookiesConfig = CookiesSelectConfig.ReadConfig();

                if (config == null || cookiesConfig == null)
                {
                    Console.WriteLine(LanguageHelper.CurrentLanguage.GUIMessage.ConfigErrTips);
                    Console.ReadLine();
                    return;
                }

                string basePath = config.SavePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "media");
                var http = new HttpClientWrapper(config, cookiesConfig);
                var twitterService = new TwitterApiService(http);
                var downloadService = new DownloadService(config, http, basePath, config.Network.TimeOut, config.Network.RetryTime);

                TwitterApiService.UserId = http.GetTwID();

                Console.WriteLine(LanguageHelper.CurrentLanguage.GUIMessage.MediaSaveDirPath + " : " + Path.GetFullPath(basePath));

                if (config.DownloadType.Count <= 0)
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Error} : {LanguageHelper.CurrentLanguage.CoreMessage.DownloadConfigIsEmptyTips}");
                    return;
                }

                await SwitchDownloaderMode(http, twitterService, downloadService, config);

                Console.WriteLine("\n\n" + string.Format(LanguageHelper.CurrentLanguage.CoreMessage.DownloadStatistics,
                downloadService.PhotosNum + downloadService.VideosNum + downloadService.GIFsNum,
                downloadService.PhotosNum, downloadService.VideosNum, downloadService.GIFsNum));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
                Console.ReadLine();
            }
        }

        private static async Task SwitchDownloaderMode(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService, App config)
        {
            switch (config.GetType)
            {
                case App.GetTypes.Likes:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Likes}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    await GetLikes(http, twitterService, downloadService, config);
                    break;
                case App.GetTypes.BookMarks:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.BookMarks}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    await GetBookMarks(http, twitterService, downloadService, config);
                    break;
                case App.GetTypes.Account:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AccountType}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    await GetAccountMedia(http, twitterService, downloadService, config);
                    break;
                case App.GetTypes.Tweet:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.TweetType}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    await GetTweetDetail(http, twitterService, downloadService, config);
                    break;
                case App.GetTypes.All:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AllTypes}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    await GetLikes(http, twitterService, downloadService, config);
                    await GetBookMarks(http, twitterService, downloadService, config);
                    break;
                default:
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.UnknownGetTypesModeTips);
                    break;
            }
        }

        /// <summary>
        /// 获取点赞内容
        /// </summary>
        /// <param name="http"></param>
        /// <param name="twitterService"></param>
        /// <param name="downloadService"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private static async Task GetLikes(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService, App config)
        {
            try
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesStart}{LanguageHelper.CurrentLanguage.GUIMessage.Likes}...");
                var metadata = LoadMetadata(App.GetTypes.Likes);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                while (true)
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetPages} : {(string.IsNullOrEmpty(currentPage) ? LanguageHelper.CurrentLanguage.CoreMessage.HomePage : currentPage)}");
                    var (tweets, nextPage) = await twitterService.GetLikesAsync(currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetPagesNoNewMedia);
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByThisPage, tweets.Count));

                    // 更新元数据
                    var newMetadata = tweets.ToMetadataContainer(nextPage, twitterService.Users);
                    MergeMetadata(metadata, newMetadata);
                    metadata.CurrentPage = nextPage;

                    // 保存元数据
                    SaveMetadata(metadata, App.GetTypes.Likes);

                    // 下载新内容
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.DownloadTweetMediaTaskStart, totalTweets));
                    await downloadService.DownloadMediaAsync(newMetadata, App.GetTypes.Likes, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetLastPages);
                        break;
                    }

                    currentPage = nextPage;
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetNextPages);
                    await Task.Delay(1000); // 请求过快可能会封IP或者ban掉account
                }

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetTweetTaskCompleted, totalTweets));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Likes} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// 获取书签内容
        /// </summary>
        /// <param name="http"></param>
        /// <param name="twitterService"></param>
        /// <param name="downloadService"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private static async Task GetBookMarks(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService, App config)
        {
            try
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesStart}{LanguageHelper.CurrentLanguage.GUIMessage.BookMarks}...");
                var metadata = LoadMetadata(App.GetTypes.BookMarks);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                while (true)
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetPages} : {(string.IsNullOrEmpty(currentPage) ? LanguageHelper.CurrentLanguage.CoreMessage.HomePage : currentPage)}");
                    var (tweets, nextPage) = await twitterService.GetBookmarksAsync(currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetPagesNoNewMedia);
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByThisPage, tweets.Count));

                    // 更新元数据
                    var newMetadata = tweets.ToMetadataContainer(nextPage, twitterService.Users);
                    MergeMetadata(metadata, newMetadata);
                    metadata.CurrentPage = nextPage;

                    // 保存元数据
                    SaveMetadata(metadata, App.GetTypes.BookMarks);

                    // 下载新内容
                    await downloadService.DownloadMediaAsync(newMetadata, App.GetTypes.BookMarks, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetLastPages);
                        break;
                    }

                    currentPage = nextPage;
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.BookMarks} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// 获取单账号媒体内容
        /// </summary>
        /// <param name="http"></param>
        /// <param name="twitterService"></param>
        /// <param name="downloadService"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private static async Task GetAccountMedia(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService, App config)
        {
            try
            {
                var accountMsg = await twitterService.GetUserIdByScreenNameAsync(config.GetTypeMsg.Replace("@", string.Empty));
                if (accountMsg.id == null)
                {
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.UnknownGetUserAccountMsgTips);
                    return;
                }

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByUserAccount, $"{accountMsg.name}({accountMsg.screenName})"));
                var metadata = LoadMetadata(App.GetTypes.Account, accountMsg.screenName);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                await Task.Delay(1000);

                while (true)
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetPages} : {(string.IsNullOrEmpty(currentPage) ? LanguageHelper.CurrentLanguage.CoreMessage.HomePage : currentPage)}");
                    var (tweets, nextPage) = await twitterService.GetUserMediaAsync(accountMsg.id, currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetPagesNoNewMedia);
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByThisPage, tweets.Count));

                    // 更新元数据
                    var newMetadata = tweets.ToMetadataContainer(nextPage, twitterService.Users);
                    MergeMetadata(metadata, newMetadata);
                    metadata.CurrentPage = nextPage;

                    // 保存元数据
                    SaveMetadata(metadata, App.GetTypes.Account, accountMsg.screenName);

                    // 下载新内容
                    await downloadService.DownloadMediaAsync(newMetadata, App.GetTypes.Account, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetLastPages);
                        break;
                    }

                    currentPage = nextPage;
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AccountType} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
            }
        }

        private static async Task GetTweetDetail(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService, App config)
        {
            try
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesStart}{LanguageHelper.CurrentLanguage.GUIMessage.TweetType}...");

                var tweets = await twitterService.GetTweetDetailAsync(config.GetTypeMsg);
                var metadata = tweets.ToMetadataContainer(string.Empty, twitterService.Users);
                await downloadService.DownloadMediaAsync(metadata, App.GetTypes.Tweet, config.DownloadType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.TweetType} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
