using System.Text.Encodings.Web;
using System.Text.Json;

namespace TAMDownload.Config.Language
{
    public sealed class LanguageHelper()
    {
        private static readonly Lazy<LanguageHelper> _instance = new(() => new LanguageHelper());
        private readonly Dictionary<string, LanguageConfig> _languageCache = new();

        public static LanguageHelper Instance => _instance.Value;
        public static readonly string LangDir = Path.Combine(AppContext.BaseDirectory, "lang");
        public bool IsLangLoadOK { get; private set; }
        public static LanguageConfig? CurrentLanguage { get; set; }

        public async Task InitLanguageAsync()
        {
            try
            {
                Directory.CreateDirectory(LangDir);
                await CreateMainLangJsonAsync(GetOptions());

                var config = App.ReadConfig();
                string targetLanguageName = config.LanguageCode;

                var languageFiles = Directory.GetFiles(LangDir, "*.json");
                if (languageFiles.Length <= 0)
                {
                    Console.WriteLine("未找到任何语言文件");
                    SetDefaultLanguageAsync(config);
                    return;
                }

                await LoadTargetLanguageAsync(targetLanguageName, languageFiles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"初始化语言模块时发生错误: {ex.Message}");
            }
        }

        private async Task LoadTargetLanguageAsync(string targetLanguageName, string[] languageFiles)
        {
            foreach (var languageFile in languageFiles)
            {
                try
                {
                    var basicInfo = await LoadLanguageBasicInfoAsync(languageFile);
                    if (basicInfo.LanguageCode == targetLanguageName)
                    {
                        LanguageConfig langConfig;
                        if (!_languageCache.TryGetValue(targetLanguageName, out langConfig))
                        {
                            var json = await File.ReadAllTextAsync(languageFile);
                            langConfig = JsonSerializer.Deserialize<LanguageConfig>(json);
                            _languageCache[targetLanguageName] = langConfig;
                        }
                        CurrentLanguage = langConfig;
                        IsLangLoadOK = true;
                        // Console.WriteLine($"已加载语言: {basicInfo.LanguageName}");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"加载语言文件 {languageFile} 时发生错误: {ex.Message}");
                }
            }
        }

        public static async Task<List<(string Name, string Code)>> GetLanguageInfoAsync()
        {
            try
            {
                var languageFiles = Directory.GetFiles(LangDir, "*.json");
                var langList = new List<(string Name, string Code)>();

                foreach (var file in languageFiles)
                {
                    try
                    {
                        var basicInfo = await LoadLanguageBasicInfoAsync(file);
                        langList.Add((basicInfo.LanguageName, basicInfo.LanguageCode));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"获取语言文件 {file} 信息时发生错误: {ex.Message}");
                    }
                }

                return langList.Count == 0
                    ? [("简体中文(内置)", "zh_CN")]
                    : langList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取语言信息时发生错误: {ex.Message}");
                return [("简体中文(内置)", "zh_CN")];
            }
        }

        private static async Task<BasicLanguageInfo> LoadLanguageBasicInfoAsync(string filePath)
        {
            var json = await File.ReadAllTextAsync(filePath);
            using var document = JsonDocument.Parse(json);

            return new BasicLanguageInfo
            {
                LanguageName = document.RootElement.GetProperty("LanguageName").GetString() ?? "未知语言",
                LanguageCode = document.RootElement.GetProperty("LanguageCode").GetString() ?? "unknown"
            };
        }

        private static void SetDefaultLanguageAsync(App config)
        {
            config.LanguageCode = "zh_CN";
            App.SaveConfig(config);
            Console.WriteLine("已设置默认语言为简体中文");
        }

        private static JsonSerializerOptions GetOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        private static async Task CreateMainLangJsonAsync(JsonSerializerOptions options)
        {
            var languageConfig = new LanguageConfig();
            var json = JsonSerializer.Serialize(languageConfig, options);
            await File.WriteAllTextAsync(Path.Combine(LangDir, "zh_CN.json"), json);
        }

        private record BasicLanguageInfo
        {
            public string? LanguageName { get; init; }
            public string? LanguageCode { get; init; }
        }
    }
}