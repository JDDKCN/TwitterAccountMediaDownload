using System;
using System.Threading.Tasks;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.Core.Services;
using TAMDownload.Core.Downloaders;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Managers
{
    public class DownloadManager
    {
        private readonly HttpClientWrapper _http;
        private readonly TwitterApiService _twitterService;
        private readonly DownloadService _downloadService;

        public DownloadManager(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService)
        {
            _http = http;
            _twitterService = twitterService;
            _downloadService = downloadService;
        }

        public async Task ProcessDownloadAsync(App config)
        {
            switch (config.GetType)
            {
                case App.GetTypes.Likes:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.Likes}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    var likesDownloader = new LikesDownloader(_http, _twitterService, _downloadService);
                    await likesDownloader.DownloadAsync(config);
                    break;

                case App.GetTypes.BookMarks:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.BookMarks}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    var bookmarksDownloader = new BookmarksDownloader(_http, _twitterService, _downloadService);
                    await bookmarksDownloader.DownloadAsync(config);
                    break;

                case App.GetTypes.Account:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AccountType}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    var accountDownloader = new AccountDownloader(_http, _twitterService, _downloadService);
                    await accountDownloader.DownloadAsync(config);
                    break;

                case App.GetTypes.Tweet:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.TweetType}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    var tweetDownloader = new TweetDownloader(_http, _twitterService, _downloadService);
                    await tweetDownloader.DownloadAsync(config);
                    break;

                case App.GetTypes.All:
                    Console.WriteLine($"{LanguageHelper.CurrentLanguage.GUIMessage.AllTypes}{LanguageHelper.CurrentLanguage.CoreMessage.GetTypesMode}.");
                    var allTypeDownloader = new AllTypeDownloader(_http, _twitterService, _downloadService);
                    await allTypeDownloader.DownloadAsync(config);
                    break;

                default:
                    Console.WriteLine(LanguageHelper.CurrentLanguage.CoreMessage.UnknownGetTypesModeTips);
                    break;
            }
        }
    }
}
