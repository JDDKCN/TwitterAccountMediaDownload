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
                KUI.Error("���ü���ʧ�ܣ������������ļ���");
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
                KUI.Error("�����ں˳��򲻴��ڣ��޷��������ز�����\n�볢����װ�����Խ�������⡣");
                return;
            }

            await Task.Run(() => RunCore());
        }

        private void RunCore()
        {
            uiButton2.Enabled = false;
            uiButton2.Text = "��������...";

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
            uiButton2.Text = "��ʼ����";
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
            KUI.Info("��Twitter(X)��ҳ���е���Cookies��\n1. ������������е�¼�˺š�\n" +
                "2. ����<��������>ҳ�棬���<ϲ��������>��\n3. ͣ���ڴ�ҳ�棬��F12/Fn+F12���������߹��ߡ�\n" +
                "4. �ڿ����߹��߶������ҵ�������<����(Internet)>�\n5. ���ɸѡ���Ҳ��<Fetch/XHR>ɸѡ��ť����ɸѡ�����Ĺ���������������� like ��\n" +
                "6. ������˳�����鿴�Ҳ�<��ͷ>��������ͷ-Cookie��\n7. ��������Cookie���ֵ�����̨�м��ɡ�");
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
