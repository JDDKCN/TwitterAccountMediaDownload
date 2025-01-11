using System.Data;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Properties;

namespace TAMDownload.GUI.Forms
{
    public partial class FormLang : Sunny.UI.UIForm
    {
        private List<(string Name, string Code)> langList;

        public FormLang()
        {
            InitializeComponent();
        }

        private async void FormLang_Load(object sender, EventArgs e)
        {
            Icon = new Icon(new MemoryStream(Resources.icon));

            langList = await LanguageHelper.GetLanguageInfoAsync();
            uiComboBox1.DataSource = langList.Select(x => x.Name).ToList();

            var config = App.ReadConfig();

            if (config.LanguageCode != null)
            {
                var selectedLang = langList.FirstOrDefault(x => x.Code == config.LanguageCode);
                if (selectedLang != default)
                {
                    int index = langList.IndexOf(selectedLang);
                    uiComboBox1.SelectedIndex = index;
                }
            }
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem == null)
                return;

            var config = App.ReadConfig();
            string FindLang = langList.FirstOrDefault(t => t.Item1 == uiComboBox1.SelectedItem.ToString()).Item2;

            if (FindLang == null)
                return;

            if (FindLang == config.LanguageCode)
            {
                Close();
                return;
            }

            config.LanguageCode = FindLang;
            App.SaveConfig(config);
            Application.Restart();
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
