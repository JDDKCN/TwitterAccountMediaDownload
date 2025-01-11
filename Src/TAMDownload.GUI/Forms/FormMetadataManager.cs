using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAMDownload.Config;
using TAMDownload.Config.Language;
using TAMDownload.GUI.Properties;
using TAMDownload.GUI.Utils;

namespace TAMDownload.GUI.Forms
{
    public partial class FormMetadataManager : Sunny.UI.UIForm
    {
        public static readonly string MetadataBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "metadata");

        public FormMetadataManager()
        {
            InitializeComponent();
        }

        private void FormMetadataManager_Load(object sender, EventArgs e)
        {
            Icon = new Icon(new MemoryStream(Resources.icon));
            Text = LanguageHelper.CurrentLanguage.GUIMessage.MetadataManager;
            uiSymbolButton2.Text = LanguageHelper.CurrentLanguage.GUIMessage.Del;

            var config = App.ReadConfig();
            RefreshUI(config);
        }

        private void RefreshUI(App config)
        {
            if(!Directory.Exists(MetadataBaseDir))
                Directory.CreateDirectory(MetadataBaseDir);

            List<string> list = new List<string>();
            list = Directory.GetFiles(MetadataBaseDir, "*.json")
                   .Select(f => Path.GetFileName(f))
                   .ToList();

            listBoxFiles.DataSource = list;
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null)
                return;

            if (!KUI.ShowBool(string.Format(LanguageHelper.CurrentLanguage.GUIMessage.DelWarnTips, listBoxFiles.SelectedItem),
                LanguageHelper.CurrentLanguage.GUIMessage.Info, Sunny.UI.UIStyle.Orange))
                return;

            File.Delete(Path.Combine(MetadataBaseDir, listBoxFiles.SelectedItem.ToString()));
            RefreshUI(App.ReadConfig());
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
