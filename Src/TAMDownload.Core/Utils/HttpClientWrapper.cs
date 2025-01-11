using System.Net;
using System.Text.Json;
using TAMDownload.Config;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;

namespace TAMDownload.Core.Utils
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private CookiesSelectHelper _cookiesSelectHelper;
        private CookiesSelectConfig _cookiesSelectConfig;
        private readonly string CookieFile = "twitter_cookie.json";

        public HttpClientWrapper(App config, CookiesSelectConfig cookiesSelectConfig)
        {
            _cookiesSelectHelper = new CookiesSelectHelper();
            _cookiesSelectConfig = cookiesSelectConfig;
            _cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                UseProxy = config.Network != null,
                Proxy = config.Network != null ? new WebProxy(config.Network.ProxyUrl) : null
            };

            _client = new HttpClient(handler);
            _client.DefaultRequestHeaders.Add("User-Agent", config.Ua);
            LoadCookies();
        }

        public async Task<T> GetJsonAsync<T>(string url, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        public void SaveCookies()
        {
            var cookies = _cookieContainer.GetAllCookies().Cast<Cookie>()
                .Select(c => new { c.Name, c.Value })
                .ToList();

            File.WriteAllText(CookieFile, JsonSerializer.Serialize(cookies));
        }

        private void LoadCookies()
        {
            string cookieString;
            if (_cookiesSelectConfig.SelectedID == null || _cookiesSelectHelper.Find(_cookiesSelectConfig.SelectedID) == null)
            {
                if (File.Exists(CookieFile))
                {
                    var cookies = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(File.ReadAllText(CookieFile));
                    foreach (var cookie in cookies)
                    {
                        _cookieContainer.Add(new Uri("https://x.com"),
                            new Cookie(cookie["Name"], cookie["Value"]));
                    }
                    return;
                }

                Console.Write($"{LanguageHelper.CurrentLanguage.CoreMessage.EnterCookies} : ");
                cookieString = Console.ReadLine();
            }
            else
            {
                cookieString = _cookiesSelectHelper.Find(_cookiesSelectConfig.SelectedID).Cookie;
                Console.WriteLine($"{LanguageHelper.CurrentLanguage.CoreMessage.CookiesByAccount} : {_cookiesSelectHelper.Find(_cookiesSelectConfig.SelectedID).AccountName}");
            }

            if (string.IsNullOrEmpty(cookieString))
                return;

            foreach (var cookie in cookieString.Split(';'))
            {
                var parts = cookie.Trim().Split('=');
                if (parts.Length == 2)
                {
                    _cookieContainer.Add(new Uri("https://x.com"), new Cookie(parts[0], parts[1]));
                }
            }

            SaveCookies();
        }

        public string GetCookie(string name)
        {
            var cookies = _cookieContainer.GetCookies(new Uri("https://x.com"));
            var cookie = cookies[name];
            return cookie?.Value;
        }

        public string GetTwID()
        {
            string value = GetCookie("twid");
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            try
            {
                var decoded = Uri.UnescapeDataString(value);
                if (!decoded.StartsWith("u="))
                    return string.Empty;
                return decoded.Substring(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"twid-{LanguageHelper.CurrentLanguage.GUIMessage.Error} : {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<HttpResponseMessage> GetMediaAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> GetMediaAsync(string url, CancellationToken ct = default)
        {
            var response = await _client.GetAsync(url, ct);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}