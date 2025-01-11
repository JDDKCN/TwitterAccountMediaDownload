using Newtonsoft.Json;

namespace TAMDownload.Config
{
    public class App
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        public enum GetTypes
        {
            /// <summary>
            /// 点赞内容
            /// </summary>
            Likes,
            /// <summary>
            /// 书签内容
            /// </summary>
            BookMarks,
            /// <summary>
            /// 单账号内容
            /// </summary>
            Account,
            /// <summary>
            /// 单推文内容
            /// </summary>
            Tweet,
            /// <summary>
            /// 全部内容(点赞+书签)
            /// </summary>
            All
        }

        /// <summary>
        /// 下载内容类型
        /// </summary>
        public enum DownloadTypes
        {
            /// <summary>
            /// 图片
            /// </summary>
            Photo,
            /// <summary>
            /// 视频
            /// </summary>
            Video,
            /// <summary>
            /// 动图
            /// </summary>
            AnimatedGif,
        }

        /// <summary>
        /// Json配置路径
        /// </summary>
        public static readonly string JsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        /// <summary>
        /// 读取Json文件
        /// </summary>
        public static string ReadJson => File.ReadAllText(JsonPath);

        /// <summary>
        /// 浏览器UA
        /// </summary>
        public string? Ua { get; set; }

        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string? SavePath { get; set; }

        /// <summary>
        /// 获取类型
        /// </summary>
        public new GetTypes GetType { get; set; }

        /// <summary>
        /// (单账号下载使用)类型信息
        /// </summary>
        public string? GetTypeMsg { get; set; }

        /// <summary>
        /// 获取类型
        /// </summary>
        public List<DownloadTypes>? DownloadType { get; set; }

        /// <summary>
        /// 网络配置
        /// </summary>
        public NetworkConfig? Network { get; set; }

        /// <summary>
        /// 跳过推文屏蔽词配置
        /// </summary>
        public SkipTweetBlockedWordsConfig? SkipTweetBlockedWords { get; set; }

        /// <summary>
        /// 跳过推文时间段配置
        /// </summary>
        public SkipTweetDateTimeConfig? SkipTweetDateRange { get; set; }

        /// <summary>
        /// 语言代码
        /// </summary>
        public string? LanguageCode { get; set; }

        public class NetworkConfig
        {
            /// <summary>
            /// 代理配置
            /// </summary>
            public string? ProxyUrl { get; set; }

            /// <summary>
            /// TimeOut时间(s)
            /// </summary>
            public int TimeOut { get; set; }

            /// <summary>
            /// 重试次数
            /// </summary>
            public int RetryTime { get; set; }
        }

        public class SkipTweetBlockedWordsConfig
        {
            /// <summary>
            /// 是否启用
            /// </summary>
            public bool IsEnable { get; set; }

            /// <summary>
            /// 推文屏蔽词
            /// </summary>
            public List<string>? BlockedWords { get; set; }
        }

        public class SkipTweetDateTimeConfig
        {
            /// <summary>
            /// 是否启用
            /// </summary>
            public bool IsEnable { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public long? StartTimestamp { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public long? EndTimestamp { get; set; }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static App? ReadConfig()
        {
            try
            {
                return JsonConvert.DeserializeObject<App>(File.ReadAllText(JsonPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="config"></param>
        public static void SaveConfig(App config)
        {
            try
            {
                string updatedJson = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(JsonPath, updatedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 创建配置
        /// </summary>
        public static void CreateConfig()
        {
            var config = new App
            {
                Ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0.0",
                SavePath = ".\\media",
                GetType = GetTypes.Likes,
                GetTypeMsg = string.Empty,
                DownloadType = new List<DownloadTypes>
                {
                    DownloadTypes.Photo,
                    DownloadTypes.Video,
                    DownloadTypes.AnimatedGif,
                },
                Network = new NetworkConfig
                {
                    ProxyUrl = "http://127.0.0.1:7890",
                    TimeOut = 30,
                    RetryTime = 5,
                },
                SkipTweetBlockedWords = new SkipTweetBlockedWordsConfig
                {
                    IsEnable = false,
                    BlockedWords = [],
                },
                SkipTweetDateRange = new SkipTweetDateTimeConfig
                {
                    IsEnable = false,
                    StartTimestamp = 1735660800,
                    EndTimestamp = 1735660800,
                },
                LanguageCode = "zh_CN",
            };

            if (!Directory.Exists(Path.GetDirectoryName(JsonPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(JsonPath));

            File.WriteAllText(JsonPath, JsonConvert.SerializeObject(config, Formatting.Indented));
            Console.WriteLine("Create Config.json");
        }
    }
}
