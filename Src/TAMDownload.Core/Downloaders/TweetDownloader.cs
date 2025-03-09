using System;
using System.Threading.Tasks;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Downloaders
{
    public class TweetDownloader : BaseDownloader
    {
        public TweetDownloader(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService) 
            : base(http, twitterService, downloadService)
        {
        }

        public override async Task DownloadAsync(App config)
        {
            try
            {
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesStart}{LanguageHelper.CurrentLanguage.GUIMessage.TweetType}...");

                var tweets = await TwitterService.GetTweetDetailAsync(config.GetTypeMsg);
                var metadata = tweets.ToMetadataContainer(string.Empty, TwitterService.Users);
                await DownloadService.DownloadMediaAsync(metadata, App.GetTypes.Tweet, config.DownloadType);
            }
            catch (Exception ex)
            {
                LogError(LanguageHelper.CurrentLanguage.GUIMessage.TweetType, ex);
            }
        }
    }
}
