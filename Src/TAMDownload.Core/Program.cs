using TAMDownload.Config;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;
using static TAMDownload.Core.Utils.MetadataExtensions;

namespace TAMDownload.Core
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine(ConstConfig.APPName);
                Console.WriteLine("版本: " + ConstConfig.VersionStr);
                Console.WriteLine(ConstConfig.Copyright + "\n");

                if (!File.Exists(App.JsonPath))
                {
                    App.CreateConfig();
                    Console.WriteLine("请填写配置文件。");
                    Console.ReadLine();
                    return;
                }

                var config = App.ReadConfig();
                if (config == null)
                {
                    Console.WriteLine("配置加载失败，请重置。");
                    Console.ReadLine();
                    return;
                }

                string basePath = config.SavePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "media");
                var http = new HttpClientWrapper(config);
                var twitterService = new TwitterApiService(http, config);
                var downloadService = new DownloadService(http, basePath);

                TwitterApiService.UserId = http.GetTwID();

                Console.WriteLine($"下载账号：{config.UserName}");
                Console.WriteLine("下载路径: " + basePath);

                if (App.DownloadTypes.Photo == config.DownloadType)
                    Console.WriteLine("下载内容：仅下载图片。");
                else if (App.DownloadTypes.Video == config.DownloadType)
                    Console.WriteLine("下载内容：仅下载视频。");
                else if (App.DownloadTypes.AnimatedGif == config.DownloadType)
                    Console.WriteLine("下载内容：仅下载动图。");
                else
                    Console.WriteLine("下载内容：下载全部内容。");

                if (App.GetTypes.Likes == config.GetType)
                {
                    Console.WriteLine("点赞获取模式。");
                    await GetLikes(http, twitterService, downloadService, config);
                }
                else if (App.GetTypes.BookMarks == config.GetType)
                {
                    Console.WriteLine("书签获取模式。");
                    await GetBookMarks(http, twitterService, downloadService, config);
                }
                else if (App.GetTypes.All == config.GetType)
                {
                    Console.WriteLine("全部获取模式。");
                    await GetLikes(http, twitterService, downloadService, config);
                    await GetBookMarks(http, twitterService, downloadService, config);
                }
                else
                {
                    Console.WriteLine("未知的获取类型");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
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
                Console.WriteLine("开始获取点赞内容...");
                var metadata = LoadMetadata(App.GetTypes.Likes);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                while (true)
                {
                    Console.WriteLine($"正在获取页面: {(string.IsNullOrEmpty(currentPage) ? "首页" : currentPage)}");
                    var (tweets, nextPage) = await twitterService.GetLikesAsync(currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine("当前页面没有新的点赞内容");
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine($"本页获取到 {tweets.Count} 条推文");

                    // 更新元数据
                    var newMetadata = tweets.ToMetadataContainer(nextPage, twitterService.Users);
                    MergeMetadata(metadata, newMetadata);
                    metadata.CurrentPage = nextPage;

                    // 保存元数据
                    SaveMetadata(metadata, App.GetTypes.Likes);

                    // 下载新内容
                    Console.WriteLine($"开始下载第 {totalTweets} 条推文的媒体文件...");
                    await downloadService.DownloadMediaAsync(newMetadata, App.GetTypes.Likes, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine("已到达最后一页");
                        break;
                    }

                    currentPage = nextPage;
                    Console.WriteLine("准备获取下一页...");
                    await Task.Delay(1000); // 请求过快可能会封IP或者ban掉account
                }

                Console.WriteLine($"任务完成，共处理 {totalTweets} 条推文");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取点赞时发生错误: {ex.Message}");
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
                Console.WriteLine("开始获取书签内容...");
                var metadata = LoadMetadata(App.GetTypes.BookMarks);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                while (true)
                {
                    Console.WriteLine($"正在获取书签页面: {(string.IsNullOrEmpty(currentPage) ? "首页" : currentPage)}");
                    var (tweets, nextPage) = await twitterService.GetBookmarksAsync(currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine("当前页面没有新的书签内容");
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine($"本页获取到 {tweets.Count} 条书签推文");

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
                        Console.WriteLine("已到达最后一页");
                        break;
                    }

                    currentPage = nextPage;
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取书签时发生错误: {ex.Message}");
            }
        }
    }
}
