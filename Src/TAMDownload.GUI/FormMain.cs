using System.Diagnostics;
using TAMDownload.Config;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI
{
    public partial class FormMain : Sunny.UI.UIForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = ConstConfig.APPName + ConstConfig.VersionStr;
            uiLabel8.Text = ConstConfig.Copyright;

            App config = App.ReadConfig();
            if (config == null)
            {
                KUI.Error("配置加载失败，请重置配置文件。");
                Application.Exit();
                return;
            }

            rtxtUA.Text = config.Ua;
            txtSavePath.Text = config.SavePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "media");
            cbEnableProxy.Checked = !string.IsNullOrEmpty(config.Proxys.Http) && !string.IsNullOrEmpty(config.Proxys.Https);
            txtHttpProxy.Text = config.Proxys.Http;
            txtHttpsProxy.Text = config.Proxys.Https;

            if (config.GetType == App.GetTypes.Likes)
                rdoLikes.Checked = true;
            else if (config.GetType == App.GetTypes.BookMarks)
                rdoBookMarks.Checked = true;
            else
                rdoAllType.Checked = true;

            if (config.DownloadType == App.DownloadTypes.Photo)
                rdoPhoto.Checked = true;
            else if (config.DownloadType == App.DownloadTypes.Video)
                rdoVideo.Checked = true;
            else if (config.DownloadType == App.DownloadTypes.AnimatedGif)
                rdoGif.Checked = true;
            else
                rdoAllDownload.Checked = true;
        }

        private async void uiButton2_Click(object sender, EventArgs e)
        {
            if (!InputChecker.TextCheck(rtxtUA) || !InputChecker.TextCheck(txtSavePath))
                return;

            App config = App.ReadConfig();

            config.Ua = rtxtUA.Text;
            config.SavePath = txtSavePath.Text;

            if (cbEnableProxy.Checked)
            {
                config.Proxys.Http = txtHttpProxy.Text;
                config.Proxys.Https = txtHttpsProxy.Text;
            }
            else
            {
                config.Proxys.Http = null;
                config.Proxys.Https = null;
            }

            if (rdoLikes.Checked)
                config.GetType = App.GetTypes.Likes;
            else if (rdoBookMarks.Checked)
                config.GetType = App.GetTypes.BookMarks;
            else
                config.GetType = App.GetTypes.All;

            if (rdoPhoto.Checked)
                config.DownloadType = App.DownloadTypes.Photo;
            else if (rdoVideo.Checked)
                config.DownloadType = App.DownloadTypes.Video;
            else if (rdoGif.Checked)
                config.DownloadType = App.DownloadTypes.AnimatedGif;
            else
                config.DownloadType = App.DownloadTypes.All;

            App.SaveConfig(config);

            FormMain_Load(null, null);

            if (!File.Exists(".\\TAMDownload.Core.exe"))
            {
                KUI.Error("下载内核程序不存在，无法进行下载操作。\n请尝试重装程序以解决该问题。");
                return;
            }

            await Task.Run(() => RunCore());
        }

        private void RunCore()
        {
            uiButton2.Enabled = false;
            uiButton2.Text = "正在下载...";

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ".\\TAMDownload.Core.exe",
                    Arguments = string.Empty,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                }
            };

            process.Start();
            process.WaitForExit();

            uiButton2.Enabled = true;
            uiButton2.Text = "开始下载";
        }

        public static void RunBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                KUI.Error(ex.Message);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            folderBrowserDialog.ShowNewFolderButton = true;

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                txtSavePath.Text = folderBrowserDialog.SelectedPath;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            KUI.Info("从Twitter(X)网页版中导入Cookies：\n1. 首先在浏览器中登录账号。\n" +
                "2. 进入<个人资料>页面，点击<喜欢的内容>。\n3. 停留在此页面，按F12/Fn+F12唤出开发者工具。\n" +
                "4. 在开发者工具顶栏中找到并进入<网络(Internet)>项。\n5. 点击筛选栏右侧的<Fetch/XHR>筛选按钮，在筛选栏左侧的过滤器输入框中输入 like 。\n" +
                "6. 点击过滤出的项，查看右侧<标头>项的请求标头-Cookie。\n7. 复制完整Cookie文字到控制台中即可。");
        }

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            RunBrowser(ConstConfig.GithubURL);
        }

        private void uiLinkLabel2_Click(object sender, EventArgs e)
        {
            RunBrowser(ConstConfig.BiliURL);
        }
    }
}
