using Newtonsoft.Json;

namespace TAMDownload.Config.Cookie
{
    public class CookiesSelectConfig
    {
        /// <summary>
        /// Json配置路径
        /// </summary>
        public static readonly string JsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cookies_db.json");

        /// <summary>
        /// 读取Json文件
        /// </summary>
        public static string ReadJson => File.ReadAllText(JsonPath);

        /// <summary>
        /// 当前选择项
        /// </summary>
        public string? SelectedID { get; set; }

        /// <summary>
        /// Cookies存储列表
        /// </summary>
        public List<CookiesConfig>? SelectedCookies { get; set; }

        public class CookiesConfig
        {
            /// <summary>
            /// 项ID
            /// </summary>
            public string? ID { get; set; }

            /// <summary>
            /// Twitter用户名
            /// </summary>
            public string? AccountName { get; set; }

            /// <summary>
            /// Cookie
            /// </summary>
            public string? Cookie { get; set; }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static CookiesSelectConfig? ReadConfig()
        {
            try
            {
                return JsonConvert.DeserializeObject<CookiesSelectConfig>(File.ReadAllText(JsonPath));
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
        public static void SaveConfig(CookiesSelectConfig config)
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
            var config = new CookiesSelectConfig
            {
                SelectedID = null,
                SelectedCookies = new List<CookiesConfig> { },
            };

            if (!Directory.Exists(Path.GetDirectoryName(JsonPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(JsonPath));

            File.WriteAllText(JsonPath, JsonConvert.SerializeObject(config, Formatting.Indented));
            Console.WriteLine("Create Cookies_db.json");
        }
    }
}
