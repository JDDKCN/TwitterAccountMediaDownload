using System.Data;
using TAMDownload.Config.Cookie;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Properties;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI.Forms
{
    public partial class FormCookies : Sunny.UI.UIForm
    {
        private CookiesSelectHelper _cookiesSelectHelper;

        public FormCookies()
        {
            InitializeComponent();
        }

        private void FormCookies_Load(object sender, EventArgs e)
        {
            Icon = new Icon(new MemoryStream(Resources.icon));
            this.Text = LanguageHelper.CurrentLanguage.GUIMessage.CookiesSettingMenu;
            _cookiesSelectHelper = new CookiesSelectHelper();
            InitLang();
            RefreshAccountList();
        }

        private void InitLang()
        {
            uiLabel4.Text = LanguageHelper.CurrentLanguage.GUIMessage.TwitterAccountNickName + " :";
            uiButton1.Text = LanguageHelper.CurrentLanguage.GUIMessage.HandBook;
            uiButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.ApplyChanges;
            uiSymbolButton1.Text = LanguageHelper.CurrentLanguage.GUIMessage.Add;
            uiSymbolButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.Del;
        }

        private void RefreshAccountList()
        {
            var cookiesConfig = CookiesSelectConfig.ReadConfig();
            if (cookiesConfig.SelectedCookies == null)
                return;

            listBoxAccounts.DataSource = null;

            if (cookiesConfig.SelectedID != null && _cookiesSelectHelper.Find(cookiesConfig.SelectedID) != null)
            {
                listBoxAccounts.DataSource = cookiesConfig.SelectedCookies
                            .OrderByDescending(x => x.ID == cookiesConfig.SelectedID)
                            .Select(x => x.AccountName)
                            .ToArray();

                listBoxAccounts.DrawItem -= ListBox_DrawItem;
                listBoxAccounts.DrawItem += ListBox_DrawItem;
            }
            else
            {
                listBoxAccounts.DataSource = cookiesConfig.SelectedCookies
                    .Select(x => x.AccountName)
                    .ToArray();
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAccounts.SelectedItem == null)
            {
                textBoxAccountName.Clear();
                richTextBoxCookies.Clear();
                return;
            }

            string selectedAccountName = listBoxAccounts.SelectedItem.ToString();
            if (string.IsNullOrEmpty(selectedAccountName))
                return;

            var cookieConfig = _cookiesSelectHelper.FindByAccountName(selectedAccountName);
            if (cookieConfig == null)
                return;

            textBoxAccountName.Text = cookieConfig.AccountName;
            richTextBoxCookies.Text = cookieConfig.Cookie;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (!InputChecker.TextCheck(textBoxAccountName) || !InputChecker.TextCheck(richTextBoxCookies))
                return;

            if (_cookiesSelectHelper.UpdateSelectedIDByAccountName(textBoxAccountName.Text))
                _cookiesSelectHelper.UpdateItemCookieByAccountName(textBoxAccountName.Text, richTextBoxCookies.Text);
            else
                _cookiesSelectHelper.Add(textBoxAccountName.Text, richTextBoxCookies.Text, true);

            PageRefreshActionUtil.TriggerPageRefresh();
            Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (listBoxAccounts.SelectedItem == null)
                return;

            if (!KUI.ShowBool(string.Format(LanguageHelper.CurrentLanguage.GUIMessage.DelWarnTips, listBoxAccounts.SelectedItem),
                LanguageHelper.CurrentLanguage.GUIMessage.Info, Sunny.UI.UIStyle.Orange))
                return;

            _cookiesSelectHelper.Delete(
                _cookiesSelectHelper.FindByAccountName(
                    listBoxAccounts.SelectedItem.ToString()).ID);

            RefreshAccountList();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            textBoxAccountName.Text = "New Unnamed Cookies";
            richTextBoxCookies.Text = string.Empty;
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var cookiesConfig = CookiesSelectConfig.ReadConfig();
            var listBox = sender as ListBox;
            var accountName = listBox.Items[e.Index].ToString();

            var isActiveItem = cookiesConfig.SelectedCookies
                .FirstOrDefault(x => x.AccountName == accountName)?.ID == cookiesConfig.SelectedID;

            using StringFormat sf = new StringFormat
            {
                // Alignment = StringAlignment.Center,     // 水平居中
                LineAlignment = StringAlignment.Center    // 垂直居中
            };

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(isActiveItem ? Color.FromArgb(110, 190, 40) : Color.FromArgb(80, 160, 255)), e.Bounds);
                using var brush = new SolidBrush(Color.White);
                e.Graphics.DrawString(accountName, e.Font, brush, e.Bounds, sf);
            }
            else
            {
                e.DrawBackground();
                using var brush = new SolidBrush(isActiveItem ? Color.FromArgb(110, 190, 40) : Color.FromArgb(80, 160, 255));
                e.Graphics.DrawString(accountName, e.Font, brush, e.Bounds, sf);
            }

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            KUI.Info(LanguageHelper.CurrentLanguage.GUIMessage.GetCookiesHandBook, LanguageHelper.CurrentLanguage.GUIMessage.HandBook);
        }

        private void FormCookies_FormClosed(object sender, FormClosedEventArgs e)
        {
            PageRefreshActionUtil.TriggerPageRefresh();
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
