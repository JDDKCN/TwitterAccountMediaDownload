using Sunny.UI;
using System.Diagnostics;
using TAMDownload.Config;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Forms;
using TAMDownload.GUI.Properties;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI
{
    public partial class FormMain : Sunny.UI.UIForm
    {
        private CookiesSelectHelper _cookiesSelectHelper;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Icon = new Icon(new MemoryStream(Resources.icon));

            _cookiesSelectHelper = new CookiesSelectHelper();

            App config = App.ReadConfig();
            if (config == null)
            {
                KUI.Error(LanguageHelper.CurrentLanguage.GUIMessage.ConfigErrTips);
                Application.Exit();
                return;
            }

            InitLang(config);
            InitUI(config);
            PageRefreshActionUtil.PageRefreshed += UpdateAccountNickNameText;
        }

        private void InitLang(App config)
        {
            if (string.IsNullOrWhiteSpace(config.LanguageCode))
            {
                FormLang formLang = new FormLang();
                formLang.ControlBox = false;
                formLang.ShowDialog();
                return;
            }

            if (LanguageHelper.CurrentLanguage.LanguageCode == "zh_CN")
            {
                Text = ConstConfig.APPName + ConstConfig.VersionStr + "  [Ãâ·ÑÈí¼þ£¬½ûÖ¹µ¹Âô]";
                uiLinkLabel1.Text = "GithubµØÖ·";
                uiLinkLabel2.Text = "BÕ¾µØÖ·";
                UIStyles.CultureInfo = CultureInfos.zh_CN;
            }
            else
            {
                Text = ConstConfig.APPNameEn + ConstConfig.VersionStr + "  [Ãâ·ÑÈí¼þ/Free Software]";
                uiLinkLabel1.Text = "Github Page";
                uiLinkLabel2.Text = "BiliBili Page";
                UIStyles.CultureInfo = CultureInfos.en_US;
            }

            uiLabel8.Text = ConstConfig.Copyright;
            uiLabel2.Text = LanguageHelper.CurrentLanguage.GUIMessage.MediaSaveDirPath + " :";
            uiButton1.Text = LanguageHelper.CurrentLanguage.GUIMessage.SelectPath;
            uiLabel3.Text = LanguageHelper.CurrentLanguage.GUIMessage.GetTypes + " :";
            uiLabel4.Text = LanguageHelper.CurrentLanguage.GUIMessage.DownloadTypes + " :";
            cbEnableProxy.Text = LanguageHelper.CurrentLanguage.GUIMessage.EnableProxy + " :";
            uiButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.StartDownload;
            rdoLikes.Text = LanguageHelper.CurrentLanguage.GUIMessage.Likes;
            rdoBookMarks.Text = LanguageHelper.CurrentLanguage.GUIMessage.BookMarks;
            rdoAllType.Text = LanguageHelper.CurrentLanguage.GUIMessage.AllTypes;
            rdoAccount.Text = LanguageHelper.CurrentLanguage.GUIMessage.AccountType;
            rdoTweet.Text = LanguageHelper.CurrentLanguage.GUIMessage.TweetType;
            cbPhoto.Text = LanguageHelper.CurrentLanguage.GUIMessage.Photos;
            cbVideo.Text = LanguageHelper.CurrentLanguage.GUIMessage.Videos;
            cbGIF.Text = LanguageHelper.CurrentLanguage.GUIMessage.Gifs;
            uiButton3.Text = LanguageHelper.CurrentLanguage.GUIMessage.CookiesSettingMenu;
            uiLabel1.Text = LanguageHelper.CurrentLanguage.GUIMessage.TimeOut + " :";
            uiLabel5.Text = LanguageHelper.CurrentLanguage.GUIMessage.RetryTime + " :";
            uiLine1.Text = LanguageHelper.CurrentLanguage.GUIMessage.UsingAccount;
            uiButton5.Text = LanguageHelper.CurrentLanguage.GUIMessage.FilterTweetSettingMenu;
            uiButton6.Text = LanguageHelper.CurrentLanguage.GUIMessage.MetadataManager;
            uiLabel6.Text = LanguageHelper.CurrentLanguage.GUIMessage.UserNameOrTweetID + " :";
            uiButton7.Text = LanguageHelper.CurrentLanguage.GUIMessage.HandBook;
        }

        private void InitUI(App config)
        {
            if (!string.IsNullOrEmpty(config.SavePath))
                txtSavePath.Text = Path.GetFullPath(config.SavePath);
            else
                txtSavePath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "media");

            cbEnableProxy.Checked = !string.IsNullOrEmpty(config.Network.ProxyUrl);
            txtHttpProxy.Text = config.Network.ProxyUrl;
            txtTimeOut.Text = config.Network.TimeOut.ToString();
            txtRetryTime.Text = config.Network.RetryTime.ToString();
            txtGetType.Text = config.GetTypeMsg;

            if (config.GetType == App.GetTypes.Likes)
                rdoLikes.Checked = true;
            else if (config.GetType == App.GetTypes.BookMarks)
                rdoBookMarks.Checked = true;
            else if (config.GetType == App.GetTypes.Account)
                rdoAccount.Checked = true;
            else if (config.GetType == App.GetTypes.Tweet)
                rdoTweet.Checked = true;
            else if (config.GetType == App.GetTypes.All)
                rdoAllType.Checked = true;

            txtGetType.Enabled = rdoAccount.Checked || rdoTweet.Checked;
            cbPhoto.Checked = config.DownloadType.Contains(App.DownloadTypes.Photo);
            cbVideo.Checked = config.DownloadType.Contains(App.DownloadTypes.Video);
            cbGIF.Checked = config.DownloadType.Contains(App.DownloadTypes.AnimatedGif);

            UpdateAccountNickNameText();
        }

        private void UpdateAccountNickNameText()
        {
            var cookiesConfig = CookiesSelectConfig.ReadConfig();
            uiLabel7.Text = (cookiesConfig.SelectedID == null || _cookiesSelectHelper.Find(cookiesConfig.SelectedID) == null)
                ? LanguageHelper.CurrentLanguage.GUIMessage.NoUserSelected : _cookiesSelectHelper.Find(cookiesConfig.SelectedID).AccountName;
        }

        private async void uiButton2_Click(object sender, EventArgs e)
        {
            if (!InputChecker.TextCheck(txtSavePath) || !InputChecker.NumCheck(txtTimeOut) || !InputChecker.NumCheck(txtRetryTime))
                return;

            if (!cbGIF.Checked && !cbPhoto.Checked && !cbVideo.Checked)
            {
                ShowTipUtil.ShowTip(LanguageHelper.CurrentLanguage.GUIMessage.MediaTypeNoSelectErrTips, uiLabel4);
                return;
            }

            if (rdoAccount.Checked || rdoTweet.Checked)
                if (!InputChecker.TextCheck(txtGetType))
                    return;

            var cookiesConfig = CookiesSelectConfig.ReadConfig();
            if(string.IsNullOrWhiteSpace(cookiesConfig.SelectedID))
            {
                KUI.Error(LanguageHelper.CurrentLanguage.GUIMessage.NoUserSelected);
                FormCookies formCookies = new FormCookies();
                formCookies.ShowDialog();
                return;
            }

            App config = App.ReadConfig();

            config.SavePath = txtSavePath.Text;
            config.Network.TimeOut = int.Parse(txtTimeOut.Text);
            config.Network.RetryTime = int.Parse(txtRetryTime.Text);
            config.Network.ProxyUrl = cbEnableProxy.Checked ? txtHttpProxy.Text : null;

            if (rdoLikes.Checked)
                config.GetType = App.GetTypes.Likes;
            else if (rdoBookMarks.Checked)
                config.GetType = App.GetTypes.BookMarks;
            else if (rdoAccount.Checked)
                config.GetType = App.GetTypes.Account;
            else if (rdoTweet.Checked)
                config.GetType = App.GetTypes.Tweet;
            else
                config.GetType = App.GetTypes.All;

            List<App.DownloadTypes> downloadTypesList = new List<App.DownloadTypes>();

            if (cbPhoto.Checked)
                downloadTypesList.Add(App.DownloadTypes.Photo);
            if (cbVideo.Checked)
                downloadTypesList.Add(App.DownloadTypes.Video);
            if (cbGIF.Checked)
                downloadTypesList.Add(App.DownloadTypes.AnimatedGif);

            config.DownloadType = downloadTypesList;

            if (rdoAccount.Checked || rdoTweet.Checked)
                config.GetTypeMsg = txtGetType.Text;

            App.SaveConfig(config);

            InitUI(App.ReadConfig());

            if (!File.Exists(".\\TAMDownload.Core.exe"))
            {
                KUI.Error(LanguageHelper.CurrentLanguage.GUIMessage.CoreNoExistErrTips);
                return;
            }

            await Task.Run(() => RunCore());
        }

        private void RunCore()
        {
            uiButton2.Enabled = false;
            uiButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.Downloading + " ...";

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
            uiButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.StartDownload;
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
            string? path = FolderPathSelect();
            if (path != null)
                txtSavePath.Text = path;
        }

        private string? FolderPathSelect()
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                return folderBrowserDialog.SelectedPath;
            return null;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            FormCookies formCookies = new FormCookies();
            formCookies.ShowDialog();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            FormLang formLang = new FormLang();
            formLang.ShowDialog();
        }

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            RunBrowser(ConstConfig.GithubURL);
        }

        private void uiLinkLabel2_Click(object sender, EventArgs e)
        {
            RunBrowser(ConstConfig.BiliURL);
        }

        private void RBCheckedChanged(object sender, EventArgs e)
        {
            txtGetType.Enabled = rdoAccount.Checked || rdoTweet.Checked;
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            FormFilterTweet formFilterTweet = new FormFilterTweet();
            formFilterTweet.ShowDialog();
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            FormMetadataManager formMetadataManager = new FormMetadataManager();
            formMetadataManager.ShowDialog();
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            KUI.Info(LanguageHelper.CurrentLanguage.GUIMessage.GetUserScreenNameAndTweetIDHandBook, LanguageHelper.CurrentLanguage.GUIMessage.HandBook);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
