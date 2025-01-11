using TAMDownload.Config;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main() 
        {
            ApplicationConfiguration.Initialize();

            if (!File.Exists(App.JsonPath))
                App.CreateConfig();

            if (!File.Exists(CookiesSelectConfig.JsonPath))
                CookiesSelectConfig.CreateConfig();

            if (!ActivateFormUtil.ActivateForm())
                return;

            InitServices();

            Application.Run(new FormMain());
        }

        static async void InitServices()
        {
            var langHelper = LanguageHelper.Instance;
            await langHelper.InitLanguageAsync();
        }
    }
}