using System.Net;
using System.Text.Json;
using TAMDownload.Config;
using TAMDownload.Core.Services;

namespace TAMDownload.Core.Utils
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private string CookieFile = "twitter_cookie.json";

        public HttpClientWrapper(App config)
        {
            _cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                UseProxy = config.Proxys != null,
                Proxy = config.Proxys != null ? new WebProxy(config.Proxys.Http) : null
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
            if (!File.Exists(CookieFile))
            {
                Console.Write("请输入Cookie: ");
                var cookieString = Console.ReadLine();
                if (string.IsNullOrEmpty(cookieString)) return;

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
            else
            {
                var cookies = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(File.ReadAllText(CookieFile));
                foreach (var cookie in cookies)
                {
                    _cookieContainer.Add(new Uri("https://x.com"),
                        new Cookie(cookie["Name"], cookie["Value"]));
                }
            }
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
            {
                Console.WriteLine("未找到twid Cookie");
                return string.Empty;
            }

            try
            {
                var decoded = Uri.UnescapeDataString(value);
                if (!decoded.StartsWith("u="))
                {
                    Console.WriteLine("twid格式不正确");
                    return string.Empty;
                }

                Console.WriteLine($"从Cookie中获取到TwID: {decoded.Substring(2)}"); 
                return decoded.Substring(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解析twid时发生错误: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<HttpResponseMessage> GetMediaAsync(string url)
        {
            var response = await _client.GetAsync(url);
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