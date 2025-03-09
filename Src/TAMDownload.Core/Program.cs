using TAMDownload.Config;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Managers;
using System;
using System.IO;
using System.Threading.Tasks;

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

                // 使用下载管理器处理下载任务
                var downloadManager = new DownloadManager(http, twitterService, downloadService);
                await downloadManager.ProcessDownloadAsync(config);

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
    }
}
