using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Models;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Downloaders
{
    public abstract class BaseDownloader
    {
        protected readonly HttpClientWrapper Http;
        protected readonly TwitterApiService TwitterService;
        protected readonly DownloadService DownloadService;

        protected BaseDownloader(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService)
        {
            Http = http;
            TwitterService = twitterService;
            DownloadService = downloadService;
        }

        public abstract Task DownloadAsync(App config);

        protected async Task DelayRequestAsync()
        {
            // 请求过快可能会封IP或者ban掉account
            await Task.Delay(1000);
        }

        // 记录错误信息的方法
        protected void LogError(string downloadType, Exception ex)
        {
            Console.WriteLine($"{downloadType} - {LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}\n{ex.StackTrace}");
        }

        // 元数据相关方法，使用从原Program.cs提取的静态方法
        protected MetadataContainer LoadMetadata(App.GetTypes type, string screenName = null)
        {
            return MetadataExtensions.LoadMetadata(type, screenName);
        }

        protected void SaveMetadata(MetadataContainer metadata, App.GetTypes type, string screenName = null)
        {
            MetadataExtensions.SaveMetadata(metadata, type, screenName);
        }

        protected void MergeMetadata(MetadataContainer target, MetadataContainer source)
        {
            MetadataExtensions.MergeMetadata(target, source);
        }
    }
}
