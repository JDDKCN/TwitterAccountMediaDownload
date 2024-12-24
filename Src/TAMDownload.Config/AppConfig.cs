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
            /// 全部内容
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
            /// <summary>
            /// 全部
            /// </summary>
            All
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
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

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
        public GetTypes GetType { get; set; }

        /// <summary>
        /// 获取类型
        /// </summary>
        public DownloadTypes DownloadType { get; set; }

        /// <summary>
        /// 代理配置
        /// </summary>
        public ProxysConfig? Proxys { get; set; }

        public class ProxysConfig
        {
            public string? Http { get; set; }
            public string? Https { get; set; }
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
                UserName = "",
                Ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0.0",
                SavePath = ".\\media",
                GetType = GetTypes.Likes,
                DownloadType = DownloadTypes.All,
                Proxys = new ProxysConfig
                {
                    Http = "http://127.0.0.1:7890",
                    Https = "http://127.0.0.1:7890"
                }
            };

            if (!Directory.Exists(Path.GetDirectoryName(JsonPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(JsonPath));

            File.WriteAllText(JsonPath, JsonConvert.SerializeObject(config, Formatting.Indented));
            Console.WriteLine("Create Config.json");
        }
    }
}
