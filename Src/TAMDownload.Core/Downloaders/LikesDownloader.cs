using System;
using System.Linq;
using System.Threading.Tasks;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Downloaders
{
    public class LikesDownloader : BaseDownloader
    {
        public LikesDownloader(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService) 
            : base(http, twitterService, downloadService)
        {
        }

        public override async Task DownloadAsync(App config)
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
                    var (tweets, nextPage) = await TwitterService.GetLikesAsync(currentPage);

                    if (!tweets.Any())
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetPagesNoNewMedia);
                        break;
                    }

                    totalTweets += tweets.Count;
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByThisPage, tweets.Count));

                    // 更新元数据
                    var newMetadata = tweets.ToMetadataContainer(nextPage, TwitterService.Users);
                    MergeMetadata(metadata, newMetadata);
                    metadata.CurrentPage = nextPage;

                    // 保存元数据
                    SaveMetadata(metadata, App.GetTypes.Likes);

                    // 下载新内容
                    Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.DownloadTweetMediaTaskStart, totalTweets));
                    await DownloadService.DownloadMediaAsync(newMetadata, App.GetTypes.Likes, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetLastPages);
                        break;
                    }

                    currentPage = nextPage;
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetNextPages);
                    await DelayRequestAsync();
                }

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetTweetTaskCompleted, totalTweets));
            }
            catch (Exception ex)
            {
                LogError(LanguageHelper.CurrentLanguage.GUIMessage.Likes, ex);
            }
        }
    }
}
