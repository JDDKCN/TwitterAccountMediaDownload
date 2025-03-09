using System.Threading.Tasks;
using TAMDownload.Config;
using TAMDownload.Core.Services;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Downloaders
{
    public class AllTypeDownloader : BaseDownloader
    {
        public AllTypeDownloader(HttpClientWrapper http, TwitterApiService twitterService, DownloadService downloadService) 
            : base(http, twitterService, downloadService)
        {
        }

        public override async Task DownloadAsync(App config)
        {
            // 处理全部内容（点赞+书签）
            var likesDownloader = new LikesDownloader(Http, TwitterService, DownloadService);
            await likesDownloader.DownloadAsync(config);

            var bookmarksDownloader = new BookmarksDownloader(Http, TwitterService, DownloadService);
            await bookmarksDownloader.DownloadAsync(config);
        }
    }
}
