using System.Text.RegularExpressions;
using TAMDownload.Config;
using TAMDownload.Core.Models;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class DownloadService
    {
        private readonly HttpClientWrapper _http;
        private readonly string _basePath;

        public DownloadService(HttpClientWrapper http, string basePath)
        {
            _http = http;
            _basePath = basePath;
        }

        public async Task DownloadMediaAsync(MetadataContainer data, App.GetTypes type, App.DownloadTypes downloadType)
        {
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            foreach (var (userId, userData) in data.Users)
            {
                foreach (var tweet in userData.Tweets)
                {
                    var index = 1;
                    foreach (var media in tweet.Media)
                    {
                        if (downloadType == App.DownloadTypes.Photo)
                        {
                            if (media.Type != "photo")
                                continue;

                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type);
                        }
                        else if (downloadType == App.DownloadTypes.Video)
                        {
                            if (media.Type != "video")
                                continue;

                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type);
                        }
                        else if (downloadType == App.DownloadTypes.AnimatedGif)
                        {
                            if (media.Type != "animated_gif")
                                continue;

                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type);
                        }
                        else
                        {
                            await DownloadSingleMediaAsync(
                                media,
                                tweet.Id,
                                userId,
                                tweet.Hashtags,
                                index++,
                                type);
                        }
                    }
                }
            }
        }

        private async Task DownloadSingleMediaAsync(
            Media media,
            string tweetId,
            string userId,
            List<string> hashtags,
            int index,
            App.GetTypes type)
        {
            try
            {
                var tags = string.Join("_", hashtags);
                if (!string.IsNullOrEmpty(tags))
                {
                    tags = $"_{tags}";
                }

                var suffix = GetFileExtension(media.Url);
                var fileName = FileHelper.SafePath($"{userId}-{tweetId}{tags}_{index}.{suffix}");
                var mediaPath = Path.Combine(_basePath, type.ToString(), media.Type);

                if (!Directory.Exists(mediaPath))
                {
                    Directory.CreateDirectory(mediaPath);
                }

                var filePath = Path.Combine(mediaPath, fileName);

                if (File.Exists(filePath))
                {
                    Console.WriteLine($"File already exists: {filePath}");
                    return;
                }

                using var response = await _http.GetMediaAsync(media.Url);
                await using var stream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream);

                Console.WriteLine($"Downloaded: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading media: {ex.Message}");
            }
        }

        private string GetFileExtension(string url)
        {
            var formatMatch = Regex.Match(url, @"format=(\w+)&");
            if (formatMatch.Success)
            {
                return formatMatch.Groups[1].Value;
            }

            return url.Split('.').Last().Split('?').First();
        }
    }
}
