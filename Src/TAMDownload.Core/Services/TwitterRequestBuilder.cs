using System.Text.Json;
using TAMDownload.Core.Constants;
using TAMDownload.Core.Utils;

namespace TAMDownload.Core.Services
{
    public class TwitterRequestBuilder
    {
        private readonly HttpClientWrapper _http;

        public TwitterRequestBuilder(HttpClientWrapper http)
        {
            _http = http;
        }

        public HttpRequestMessage BuildLikesRequest(string cursor = "", int count = 50, string userId = null)
        {
            var variables = new
            {
                userId,
                count,
                includePromotedContent = false,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetLikeFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TwitterApiConstants.LikeUrl, parameters));
            AddTwitterAuthHeaders(request);
            return request;
        }

        public HttpRequestMessage BuildBookmarksRequest(string cursor = "", int count = 20, string userId = null)
        {
            var variables = new
            {
                userId,
                count,
                includePromotedContent = true,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor,
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetBookmarkFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TwitterApiConstants.BookmarkUrl, parameters));
            AddTwitterAuthHeaders(request);
            request.Headers.Add("Referer", $"https://x.com/i/bookmarks");
            return request;
        }

        public HttpRequestMessage BuildUserMediaRequest(string userId, string cursor = "", int count = 20)
        {
            var variables = new
            {
                userId,
                count,
                includePromotedContent = false,
                withClientEventToken = false,
                withBirdwatchNotes = false,
                withVoice = true,
                withV2Timeline = true,
                cursor
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetUserMediaFeatures(),
                ["fieldToggles"] = "{\"withArticlePlainText\":false}"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TwitterApiConstants.UserMediaUrl, parameters));
            AddTwitterAuthHeaders(request);
            return request;
        }

        public HttpRequestMessage BuildTweetDetailRequest(string tweetId)
        {
            var variables = new
            {
                focalTweetId = tweetId,
                with_rux_injections = false,
                rankingMode = "Relevance",
                includePromotedContent = true,
                withCommunity = true,
                withQuickPromoteEligibilityTweetFields = true,
                withBirdwatchNotes = true,
                withVoice = true
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables),
                ["features"] = Features.GetTweetDetailFeatures(),
                ["fieldToggles"] = "{\"withArticleRichContentState\":true,\"withArticlePlainText\":false,\"withGrokAnalyze\":false,\"withDisallowedReplyControls\":false}"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TwitterApiConstants.TweetDetailUrl, parameters));
            AddTwitterAuthHeaders(request);
            return request;
        }

        public HttpRequestMessage BuildUserIdRequest(string screenName)
        {
            var variables = new
            {
                screen_name = screenName
            };

            var parameters = new Dictionary<string, string>
            {
                ["variables"] = JsonSerializer.Serialize(variables)
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(TwitterApiConstants.ProfileSpotlightsUrl, parameters));
            AddTwitterAuthHeaders(request);
            return request;
        }

        private void AddTwitterAuthHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {TwitterApiConstants.Bearer}");
            request.Headers.Add("x-csrf-token", _http.GetCookie("ct0"));
            request.Headers.Add("x-twitter-active-user", "yes");
            request.Headers.Add("x-twitter-auth-type", "OAuth2Session");
            request.Headers.Add("x-twitter-client-language", _http.GetCookie("lang"));
        }

        private string BuildUrl(string baseUrl, Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Any())
                return baseUrl;

            var queryString = string.Join("&", parameters.Select(p =>
                $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));

            return $"{baseUrl}?{queryString}";
        }
    }
}
