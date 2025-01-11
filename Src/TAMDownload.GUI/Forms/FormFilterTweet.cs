using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Properties;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI.Forms
{
    public partial class FormFilterTweet : Sunny.UI.UIForm
    {
        private static bool isInitOK = false;

        public FormFilterTweet()
        {
            InitializeComponent();
            isInitOK = true;
        }

        private void FormFilterTweet_Load(object sender, EventArgs e)
        {
            Icon = new Icon(new MemoryStream(Resources.icon));
            Text = LanguageHelper.CurrentLanguage.GUIMessage.FilterTweetSettingMenu;
            pictureBox1.Image = Image.FromStream(new MemoryStream(Resources.KCN_Logo));
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var config = App.ReadConfig();

            InitLang(config);
            RefreshUI(config);
        }

        private void InitLang(App config)
        {
            uiLabel1.Text = (config.SkipTweetBlockedWords.IsEnable == true ?
                LanguageHelper.CurrentLanguage.GUIMessage.Enable : LanguageHelper.CurrentLanguage.GUIMessage.Disable) +
                " " + LanguageHelper.CurrentLanguage.GUIMessage.FilterBlockedWords;

            uiLabel2.Text = (config.SkipTweetDateRange.IsEnable == true ?
                LanguageHelper.CurrentLanguage.GUIMessage.Enable : LanguageHelper.CurrentLanguage.GUIMessage.Disable) +
                " " + LanguageHelper.CurrentLanguage.GUIMessage.FilterDateRange;

            uiLabel3.Text = LanguageHelper.CurrentLanguage.GUIMessage.BlockedWords + " :";
            uiLabel4.Text = LanguageHelper.CurrentLanguage.GUIMessage.SetStartDate + " :";
            uiLabel5.Text = LanguageHelper.CurrentLanguage.GUIMessage.SetEndDate + " :";
            uiSymbolButton1.Text = LanguageHelper.CurrentLanguage.GUIMessage.Add;
            uiSymbolButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.Del;
        }

        private void RefreshUI(App config)
        {
            uiSwitch1.Active = config.SkipTweetBlockedWords.IsEnable;
            uiSwitch2.Active = config.SkipTweetDateRange.IsEnable;

            txtWord.Text = string.Empty;
            listBoxWords.DataSource = null;
            listBoxWords.DataSource = config.SkipTweetBlockedWords.BlockedWords;

            if (config.SkipTweetDateRange.StartTimestamp != null)
                uiDatetimePicker1.Value = DateTimeOffset.FromUnixTimeSeconds((long)config.SkipTweetDateRange.StartTimestamp).LocalDateTime;
            if (config.SkipTweetDateRange.EndTimestamp != null)
                uiDatetimePicker2.Value = DateTimeOffset.FromUnixTimeSeconds((long)config.SkipTweetDateRange.EndTimestamp).LocalDateTime;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var config = App.ReadConfig();

            if (!InputChecker.TextCheck(txtWord))
                return;

            if (config.SkipTweetBlockedWords.BlockedWords.Any(x => x.Equals(txtWord.Text, StringComparison.OrdinalIgnoreCase)))
                return;

            config.SkipTweetBlockedWords.BlockedWords.Add(txtWord.Text);
            App.SaveConfig(config);

            RefreshUI(App.ReadConfig());
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (listBoxWords.SelectedItem == null)
                return;

            if (!KUI.ShowBool(string.Format(LanguageHelper.CurrentLanguage.GUIMessage.DelWarnTips, listBoxWords.SelectedItem),
                LanguageHelper.CurrentLanguage.GUIMessage.Info, Sunny.UI.UIStyle.Orange))
                return;

            var config = App.ReadConfig();
            config.SkipTweetBlockedWords.BlockedWords.RemoveAll(x => x == listBoxWords.SelectedItem.ToString());
            App.SaveConfig(config);

            RefreshUI(App.ReadConfig());
        }

        private void listBoxWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWords.SelectedItem == null)
                return;
            txtWord.Text = listBoxWords.SelectedItem.ToString();
        }

        private void uiSwitch1_ValueChanged(object sender, bool value)
        {
            if (!isInitOK)
                return;

            var config = App.ReadConfig();
            config.SkipTweetBlockedWords.IsEnable = value;
            App.SaveConfig(config);
            InitLang(App.ReadConfig());
        }

        private void uiSwitch2_ValueChanged(object sender, bool value)
        {
            if (!isInitOK)
                return;

            var config = App.ReadConfig();
            config.SkipTweetDateRange.IsEnable = value;
            App.SaveConfig(config);
            InitLang(App.ReadConfig());
        }

        private void uiDatetimePicker1_ValueChanged(object sender, DateTime value)
        {
            if (!isInitOK)
                return;

            var config = App.ReadConfig();
            config.SkipTweetDateRange.StartTimestamp = ((DateTimeOffset)value).ToUnixTimeSeconds();
            App.SaveConfig(config);
        }

        private void uiDatetimePicker2_ValueChanged(object sender, DateTime value)
        {
            if (!isInitOK)
                return;

            var config = App.ReadConfig();
            config.SkipTweetDateRange.EndTimestamp = ((DateTimeOffset)value).ToUnixTimeSeconds();
            App.SaveConfig(config);
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
