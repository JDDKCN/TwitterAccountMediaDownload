using System;
using System.Linq;
using System.Threading.Tasks;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Downloaders
{
    public class AccountDownloader : BaseDownloader
    {
        public AccountDownloader(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService) 
            : base(http, twitterService, downloadService)
        {
        }

        public override async Task DownloadAsync(App config)
        {
            try
            {
                var accountMsg = await TwitterService.GetUserIdByScreenNameAsync(config.GetTypeMsg.Replace("@", string.Empty));
                if (accountMsg.id == null)
                {
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.UnknownGetUserAccountMsgTips);
                    return;
                }

                Console.WriteLine(string.Format(LanguageHelper.CurrentLanguage.CoreMessage.GetMediaByUserAccount, $"{accountMsg.name}({accountMsg.screenName})"));
                var metadata = LoadMetadata(App.GetTypes.Account, accountMsg.screenName);
                var currentPage = metadata?.CurrentPage ?? "";
                var totalTweets = 0;

                await DelayRequestAsync();

                while (true)
                {
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.GetPages} : {(string.IsNullOrEmpty(currentPage) ? LanguageHelper.CurrentLanguage.CoreMessage.HomePage : currentPage)}");
                    var (tweets, nextPage) = await TwitterService.GetUserMediaAsync(accountMsg.id, currentPage);

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
                    SaveMetadata(metadata, App.GetTypes.Account, accountMsg.screenName);

                    // 下载新内容
                    await DownloadService.DownloadMediaAsync(newMetadata, App.GetTypes.Account, config.DownloadType);

                    if (string.IsNullOrEmpty(nextPage))
                    {
                        Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.GetLastPages);
                        break;
                    }

                    currentPage = nextPage;
                    await DelayRequestAsync();
                }
            }
            catch (Exception ex)
            {
                LogError(LanguageHelper.CurrentLanguage.GUIMessage.AccountType, ex);
            }
        }
    }
}
