namespace TAMDownload.GUI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            uiStyleManager1 = new Sunny.UI.UIStyleManager(components);
            uiPanel2 = new Sunny.UI.UIPanel();
            uiButton1 = new Sunny.UI.UIButton();
            txtSavePath = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiPanel3 = new Sunny.UI.UIPanel();
            rdoAllType = new Sunny.UI.UIRadioButton();
            rdoLikes = new Sunny.UI.UIRadioButton();
            rdoBookMarks = new Sunny.UI.UIRadioButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiPanel4 = new Sunny.UI.UIPanel();
            rdoVideo = new Sunny.UI.UIRadioButton();
            rdoAllDownload = new Sunny.UI.UIRadioButton();
            rdoGif = new Sunny.UI.UIRadioButton();
            rdoPhoto = new Sunny.UI.UIRadioButton();
            uiLabel4 = new Sunny.UI.UILabel();
            uiPanel5 = new Sunny.UI.UIPanel();
            uiLabel6 = new Sunny.UI.UILabel();
            txtHttpsProxy = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            cbEnableProxy = new Sunny.UI.UICheckBox();
            txtHttpProxy = new Sunny.UI.UITextBox();
            uiPanel6 = new Sunny.UI.UIPanel();
            rtxtUA = new Sunny.UI.UIRichTextBox();
            uiLabel7 = new Sunny.UI.UILabel();
            uiPanel7 = new Sunny.UI.UIPanel();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel8 = new Sunny.UI.UILabel();
            uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            uiLinkLabel2 = new Sunny.UI.UILinkLabel();
            uiPanel2.SuspendLayout();
            uiPanel3.SuspendLayout();
            uiPanel4.SuspendLayout();
            uiPanel5.SuspendLayout();
            uiPanel6.SuspendLayout();
            uiPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // uiStyleManager1
            // 
            uiStyleManager1.DPIScale = true;
            uiStyleManager1.GlobalFont = true;
            uiStyleManager1.GlobalFontName = "微软雅黑";
            uiStyleManager1.GlobalFontScale = 125;
            // 
            // uiPanel2
            // 
            uiPanel2.Controls.Add(uiButton1);
            uiPanel2.Controls.Add(txtSavePath);
            uiPanel2.Controls.Add(uiLabel2);
            uiPanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel2.Location = new Point(18, 57);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Size = new Size(963, 123);
            uiPanel2.TabIndex = 3;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 13F);
            uiButton1.Location = new Point(809, 54);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(135, 57);
            uiButton1.TabIndex = 3;
            uiButton1.Text = "选择路径";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // txtSavePath
            // 
            txtSavePath.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtSavePath.Location = new Point(20, 54);
            txtSavePath.Margin = new Padding(4, 5, 4, 5);
            txtSavePath.MinimumSize = new Size(1, 16);
            txtSavePath.Name = "txtSavePath";
            txtSavePath.Padding = new Padding(5);
            txtSavePath.ReadOnly = true;
            txtSavePath.ShowText = false;
            txtSavePath.Size = new Size(782, 57);
            txtSavePath.TabIndex = 2;
            txtSavePath.TextAlignment = ContentAlignment.MiddleLeft;
            txtSavePath.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 13F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(20, 8);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(436, 41);
            uiLabel2.TabIndex = 1;
            uiLabel2.Text = "下载媒体保存路径：";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel3
            // 
            uiPanel3.Controls.Add(rdoAllType);
            uiPanel3.Controls.Add(rdoLikes);
            uiPanel3.Controls.Add(rdoBookMarks);
            uiPanel3.Controls.Add(uiLabel3);
            uiPanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel3.Location = new Point(18, 190);
            uiPanel3.Margin = new Padding(4, 5, 4, 5);
            uiPanel3.MinimumSize = new Size(1, 1);
            uiPanel3.Name = "uiPanel3";
            uiPanel3.Size = new Size(593, 123);
            uiPanel3.TabIndex = 3;
            uiPanel3.Text = null;
            uiPanel3.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rdoAllType
            // 
            rdoAllType.Font = new Font("微软雅黑", 13F);
            rdoAllType.Location = new Point(352, 62);
            rdoAllType.MinimumSize = new Size(1, 1);
            rdoAllType.Name = "rdoAllType";
            rdoAllType.RadioButtonSize = 20;
            rdoAllType.Size = new Size(160, 46);
            rdoAllType.TabIndex = 4;
            rdoAllType.Text = "全部内容";
            // 
            // rdoLikes
            // 
            rdoLikes.Font = new Font("微软雅黑", 13F);
            rdoLikes.Location = new Point(186, 62);
            rdoLikes.MinimumSize = new Size(1, 1);
            rdoLikes.Name = "rdoLikes";
            rdoLikes.RadioButtonSize = 20;
            rdoLikes.Size = new Size(160, 46);
            rdoLikes.TabIndex = 3;
            rdoLikes.Text = "点赞内容";
            // 
            // rdoBookMarks
            // 
            rdoBookMarks.Checked = true;
            rdoBookMarks.Font = new Font("微软雅黑", 13F);
            rdoBookMarks.Location = new Point(20, 62);
            rdoBookMarks.MinimumSize = new Size(1, 1);
            rdoBookMarks.Name = "rdoBookMarks";
            rdoBookMarks.RadioButtonSize = 20;
            rdoBookMarks.Size = new Size(160, 46);
            rdoBookMarks.TabIndex = 2;
            rdoBookMarks.Text = "书签内容";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 13F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(20, 18);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(219, 41);
            uiLabel3.TabIndex = 1;
            uiLabel3.Text = "获取内容类型：";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel4
            // 
            uiPanel4.Controls.Add(rdoVideo);
            uiPanel4.Controls.Add(rdoAllDownload);
            uiPanel4.Controls.Add(rdoGif);
            uiPanel4.Controls.Add(rdoPhoto);
            uiPanel4.Controls.Add(uiLabel4);
            uiPanel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel4.Location = new Point(619, 190);
            uiPanel4.Margin = new Padding(4, 5, 4, 5);
            uiPanel4.MinimumSize = new Size(1, 1);
            uiPanel4.Name = "uiPanel4";
            uiPanel4.Size = new Size(362, 174);
            uiPanel4.TabIndex = 4;
            uiPanel4.Text = null;
            uiPanel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rdoVideo
            // 
            rdoVideo.Font = new Font("微软雅黑", 13F);
            rdoVideo.Location = new Point(186, 62);
            rdoVideo.MinimumSize = new Size(1, 1);
            rdoVideo.Name = "rdoVideo";
            rdoVideo.RadioButtonSize = 20;
            rdoVideo.Size = new Size(157, 46);
            rdoVideo.TabIndex = 5;
            rdoVideo.Text = "仅视频";
            // 
            // rdoAllDownload
            // 
            rdoAllDownload.Checked = true;
            rdoAllDownload.Font = new Font("微软雅黑", 13F);
            rdoAllDownload.Location = new Point(186, 114);
            rdoAllDownload.MinimumSize = new Size(1, 1);
            rdoAllDownload.Name = "rdoAllDownload";
            rdoAllDownload.RadioButtonSize = 20;
            rdoAllDownload.Size = new Size(157, 46);
            rdoAllDownload.TabIndex = 4;
            rdoAllDownload.Text = "全部下载";
            // 
            // rdoGif
            // 
            rdoGif.Font = new Font("微软雅黑", 13F);
            rdoGif.Location = new Point(20, 114);
            rdoGif.MinimumSize = new Size(1, 1);
            rdoGif.Name = "rdoGif";
            rdoGif.RadioButtonSize = 20;
            rdoGif.Size = new Size(132, 46);
            rdoGif.TabIndex = 3;
            rdoGif.Text = "仅动图";
            // 
            // rdoPhoto
            // 
            rdoPhoto.Font = new Font("微软雅黑", 13F);
            rdoPhoto.Location = new Point(20, 62);
            rdoPhoto.MinimumSize = new Size(1, 1);
            rdoPhoto.Name = "rdoPhoto";
            rdoPhoto.RadioButtonSize = 20;
            rdoPhoto.Size = new Size(132, 46);
            rdoPhoto.TabIndex = 2;
            rdoPhoto.Text = "仅图片";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 13F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(20, 18);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(219, 41);
            uiLabel4.TabIndex = 1;
            uiLabel4.Text = "下载内容类型：";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel5
            // 
            uiPanel5.Controls.Add(uiLabel6);
            uiPanel5.Controls.Add(txtHttpsProxy);
            uiPanel5.Controls.Add(uiLabel5);
            uiPanel5.Controls.Add(cbEnableProxy);
            uiPanel5.Controls.Add(txtHttpProxy);
            uiPanel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel5.Location = new Point(18, 323);
            uiPanel5.Margin = new Padding(4, 5, 4, 5);
            uiPanel5.MinimumSize = new Size(1, 1);
            uiPanel5.Name = "uiPanel5";
            uiPanel5.Size = new Size(593, 243);
            uiPanel5.TabIndex = 5;
            uiPanel5.Text = null;
            uiPanel5.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("微软雅黑", 13F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(20, 172);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(154, 57);
            uiLabel6.TabIndex = 6;
            uiLabel6.Text = "Https地址:";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtHttpsProxy
            // 
            txtHttpsProxy.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtHttpsProxy.Location = new Point(181, 172);
            txtHttpsProxy.Margin = new Padding(4, 5, 4, 5);
            txtHttpsProxy.MinimumSize = new Size(1, 16);
            txtHttpsProxy.Name = "txtHttpsProxy";
            txtHttpsProxy.Padding = new Padding(5);
            txtHttpsProxy.ShowText = false;
            txtHttpsProxy.Size = new Size(382, 57);
            txtHttpsProxy.TabIndex = 5;
            txtHttpsProxy.TextAlignment = ContentAlignment.MiddleLeft;
            txtHttpsProxy.Watermark = "";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 13F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(20, 88);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(154, 57);
            uiLabel5.TabIndex = 4;
            uiLabel5.Text = "Http地址:";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbEnableProxy
            // 
            cbEnableProxy.CheckBoxSize = 20;
            cbEnableProxy.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbEnableProxy.ForeColor = Color.FromArgb(48, 48, 48);
            cbEnableProxy.Location = new Point(20, 15);
            cbEnableProxy.MinimumSize = new Size(1, 1);
            cbEnableProxy.Name = "cbEnableProxy";
            cbEnableProxy.Size = new Size(543, 65);
            cbEnableProxy.TabIndex = 3;
            cbEnableProxy.Text = "启用代理连接：";
            // 
            // txtHttpProxy
            // 
            txtHttpProxy.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtHttpProxy.Location = new Point(181, 88);
            txtHttpProxy.Margin = new Padding(4, 5, 4, 5);
            txtHttpProxy.MinimumSize = new Size(1, 16);
            txtHttpProxy.Name = "txtHttpProxy";
            txtHttpProxy.Padding = new Padding(5);
            txtHttpProxy.ShowText = false;
            txtHttpProxy.Size = new Size(382, 57);
            txtHttpProxy.TabIndex = 2;
            txtHttpProxy.TextAlignment = ContentAlignment.MiddleLeft;
            txtHttpProxy.Watermark = "";
            // 
            // uiPanel6
            // 
            uiPanel6.Controls.Add(rtxtUA);
            uiPanel6.Controls.Add(uiLabel7);
            uiPanel6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel6.Location = new Point(619, 374);
            uiPanel6.Margin = new Padding(4, 5, 4, 5);
            uiPanel6.MinimumSize = new Size(1, 1);
            uiPanel6.Name = "uiPanel6";
            uiPanel6.Size = new Size(362, 192);
            uiPanel6.TabIndex = 6;
            uiPanel6.Text = null;
            uiPanel6.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rtxtUA
            // 
            rtxtUA.FillColor = Color.White;
            rtxtUA.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rtxtUA.Location = new Point(20, 54);
            rtxtUA.Margin = new Padding(4, 5, 4, 5);
            rtxtUA.MinimumSize = new Size(1, 1);
            rtxtUA.Name = "rtxtUA";
            rtxtUA.Padding = new Padding(2);
            rtxtUA.ShowText = false;
            rtxtUA.Size = new Size(323, 124);
            rtxtUA.TabIndex = 2;
            rtxtUA.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("微软雅黑", 13F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(20, 8);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(232, 41);
            uiLabel7.TabIndex = 1;
            uiLabel7.Text = "UA：";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel7
            // 
            uiPanel7.Controls.Add(uiButton3);
            uiPanel7.Controls.Add(uiButton2);
            uiPanel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel7.Location = new Point(18, 576);
            uiPanel7.Margin = new Padding(4, 5, 4, 5);
            uiPanel7.MinimumSize = new Size(1, 1);
            uiPanel7.Name = "uiPanel7";
            uiPanel7.Size = new Size(963, 123);
            uiPanel7.TabIndex = 7;
            uiPanel7.Text = null;
            uiPanel7.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton3
            // 
            uiButton3.FillColor = Color.FromArgb(0, 150, 136);
            uiButton3.FillColor2 = Color.FromArgb(0, 150, 136);
            uiButton3.FillHoverColor = Color.FromArgb(51, 171, 160);
            uiButton3.FillPressColor = Color.FromArgb(0, 120, 109);
            uiButton3.FillSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton3.Font = new Font("微软雅黑", 13F);
            uiButton3.LightColor = Color.FromArgb(238, 248, 248);
            uiButton3.Location = new Point(115, 26);
            uiButton3.MinimumSize = new Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = Color.FromArgb(0, 150, 136);
            uiButton3.RectHoverColor = Color.FromArgb(51, 171, 160);
            uiButton3.RectPressColor = Color.FromArgb(0, 120, 109);
            uiButton3.RectSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton3.Size = new Size(270, 72);
            uiButton3.Style = Sunny.UI.UIStyle.Custom;
            uiButton3.TabIndex = 5;
            uiButton3.Text = "导入Cookies教程";
            uiButton3.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiButton2
            // 
            uiButton2.Font = new Font("微软雅黑", 13F);
            uiButton2.Location = new Point(391, 26);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new Size(457, 72);
            uiButton2.TabIndex = 4;
            uiButton2.Text = "开始下载";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiLabel8
            // 
            uiLabel8.Dock = DockStyle.Bottom;
            uiLabel8.Font = new Font("微软雅黑", 10F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(0, 708);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(998, 35);
            uiLabel8.TabIndex = 8;
            uiLabel8.Text = "CopyRight";
            uiLabel8.TextAlign = ContentAlignment.TopCenter;
            // 
            // uiLinkLabel1
            // 
            uiLinkLabel1.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            uiLinkLabel1.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLinkLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLinkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            uiLinkLabel1.LinkColor = Color.DodgerBlue;
            uiLinkLabel1.Location = new Point(840, 708);
            uiLinkLabel1.Name = "uiLinkLabel1";
            uiLinkLabel1.Size = new Size(141, 30);
            uiLinkLabel1.TabIndex = 6;
            uiLinkLabel1.TabStop = true;
            uiLinkLabel1.Text = "Github地址";
            uiLinkLabel1.TextAlign = ContentAlignment.TopRight;
            uiLinkLabel1.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            uiLinkLabel1.Click += uiLinkLabel1_Click;
            // 
            // uiLinkLabel2
            // 
            uiLinkLabel2.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            uiLinkLabel2.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLinkLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLinkLabel2.LinkBehavior = LinkBehavior.AlwaysUnderline;
            uiLinkLabel2.LinkColor = Color.DodgerBlue;
            uiLinkLabel2.Location = new Point(18, 708);
            uiLinkLabel2.Name = "uiLinkLabel2";
            uiLinkLabel2.Size = new Size(123, 30);
            uiLinkLabel2.TabIndex = 9;
            uiLinkLabel2.TabStop = true;
            uiLinkLabel2.Text = "B站地址";
            uiLinkLabel2.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            uiLinkLabel2.Click += uiLinkLabel2_Click;
            // 
            // FormMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(998, 743);
            Controls.Add(uiLinkLabel2);
            Controls.Add(uiLinkLabel1);
            Controls.Add(uiLabel8);
            Controls.Add(uiPanel7);
            Controls.Add(uiPanel6);
            Controls.Add(uiPanel5);
            Controls.Add(uiPanel4);
            Controls.Add(uiPanel3);
            Controls.Add(uiPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMain";
            Text = "KCN-Server";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += FormMain_Load;
            uiPanel2.ResumeLayout(false);
            uiPanel3.ResumeLayout(false);
            uiPanel4.ResumeLayout(false);
            uiPanel5.ResumeLayout(false);
            uiPanel6.ResumeLayout(false);
            uiPanel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIStyleManager uiStyleManager1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UITextBox txtSavePath;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIRadioButton rdoAllType;
        private Sunny.UI.UIRadioButton rdoLikes;
        private Sunny.UI.UIRadioButton rdoBookMarks;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UIRadioButton rdoAllDownload;
        private Sunny.UI.UIRadioButton rdoGif;
        private Sunny.UI.UIRadioButton rdoPhoto;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIRadioButton rdoVideo;
        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtHttpsProxy;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UICheckBox cbEnableProxy;
        private Sunny.UI.UITextBox txtHttpProxy;
        private Sunny.UI.UIPanel uiPanel6;
        private Sunny.UI.UIRichTextBox rtxtUA;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIPanel uiPanel7;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private Sunny.UI.UILinkLabel uiLinkLabel2;
    }
}
