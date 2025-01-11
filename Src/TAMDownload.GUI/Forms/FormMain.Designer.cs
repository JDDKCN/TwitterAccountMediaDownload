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
            uiStyleManager1 = new Sunny.UI.UIStyleManager(components);
            uiPanel2 = new Sunny.UI.UIPanel();
            uiButton1 = new Sunny.UI.UIButton();
            txtSavePath = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiPanel3 = new Sunny.UI.UIPanel();
            uiButton7 = new Sunny.UI.UIButton();
            uiLabel6 = new Sunny.UI.UILabel();
            rdoTweet = new Sunny.UI.UIRadioButton();
            txtGetType = new Sunny.UI.UITextBox();
            rdoAccount = new Sunny.UI.UIRadioButton();
            rdoAllType = new Sunny.UI.UIRadioButton();
            rdoLikes = new Sunny.UI.UIRadioButton();
            rdoBookMarks = new Sunny.UI.UIRadioButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiPanel4 = new Sunny.UI.UIPanel();
            cbGIF = new Sunny.UI.UICheckBox();
            cbVideo = new Sunny.UI.UICheckBox();
            cbPhoto = new Sunny.UI.UICheckBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiPanel5 = new Sunny.UI.UIPanel();
            txtHttpProxy = new Sunny.UI.UITextBox();
            cbEnableProxy = new Sunny.UI.UICheckBox();
            uiPanel7 = new Sunny.UI.UIPanel();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiLabel8 = new Sunny.UI.UILabel();
            uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            uiLinkLabel2 = new Sunny.UI.UILinkLabel();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiButton6 = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            txtRetryTime = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtTimeOut = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiPanel8 = new Sunny.UI.UIPanel();
            uiLine1 = new Sunny.UI.UILine();
            uiLabel7 = new Sunny.UI.UILabel();
            uiPanel9 = new Sunny.UI.UIPanel();
            uiPanel2.SuspendLayout();
            uiPanel3.SuspendLayout();
            uiPanel4.SuspendLayout();
            uiPanel5.SuspendLayout();
            uiPanel7.SuspendLayout();
            uiPanel1.SuspendLayout();
            uiPanel8.SuspendLayout();
            uiPanel9.SuspendLayout();
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
            uiPanel2.Size = new Size(593, 123);
            uiPanel2.TabIndex = 3;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 13F);
            uiButton1.Location = new Point(438, 54);
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
            txtSavePath.Size = new Size(411, 57);
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
            uiPanel3.Controls.Add(uiButton7);
            uiPanel3.Controls.Add(uiLabel6);
            uiPanel3.Controls.Add(rdoTweet);
            uiPanel3.Controls.Add(txtGetType);
            uiPanel3.Controls.Add(rdoAccount);
            uiPanel3.Controls.Add(rdoAllType);
            uiPanel3.Controls.Add(rdoLikes);
            uiPanel3.Controls.Add(rdoBookMarks);
            uiPanel3.Controls.Add(uiLabel3);
            uiPanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel3.Location = new Point(18, 190);
            uiPanel3.Margin = new Padding(4, 5, 4, 5);
            uiPanel3.MinimumSize = new Size(1, 1);
            uiPanel3.Name = "uiPanel3";
            uiPanel3.Size = new Size(593, 346);
            uiPanel3.TabIndex = 3;
            uiPanel3.Text = null;
            uiPanel3.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton7
            // 
            uiButton7.Font = new Font("微软雅黑", 13F);
            uiButton7.Location = new Point(438, 251);
            uiButton7.MinimumSize = new Size(1, 1);
            uiButton7.Name = "uiButton7";
            uiButton7.Size = new Size(135, 57);
            uiButton7.TabIndex = 9;
            uiButton7.Text = "帮助文档";
            uiButton7.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton7.Click += uiButton7_Click;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("微软雅黑", 13F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(20, 205);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(553, 41);
            uiLabel6.TabIndex = 8;
            uiLabel6.Text = "用户名或推文ID：";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rdoTweet
            // 
            rdoTweet.Font = new Font("微软雅黑", 13F);
            rdoTweet.Location = new Point(297, 134);
            rdoTweet.MinimumSize = new Size(1, 1);
            rdoTweet.Name = "rdoTweet";
            rdoTweet.RadioButtonSize = 20;
            rdoTweet.Size = new Size(276, 57);
            rdoTweet.TabIndex = 7;
            rdoTweet.Text = "单推文媒体内容";
            // 
            // txtGetType
            // 
            txtGetType.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtGetType.Location = new Point(20, 251);
            txtGetType.Margin = new Padding(4, 5, 4, 5);
            txtGetType.MinimumSize = new Size(1, 16);
            txtGetType.Name = "txtGetType";
            txtGetType.Padding = new Padding(5);
            txtGetType.ShowText = false;
            txtGetType.Size = new Size(411, 57);
            txtGetType.TabIndex = 6;
            txtGetType.TextAlignment = ContentAlignment.MiddleLeft;
            txtGetType.Watermark = "@UserName / Tweet ID";
            // 
            // rdoAccount
            // 
            rdoAccount.Font = new Font("微软雅黑", 13F);
            rdoAccount.Location = new Point(20, 134);
            rdoAccount.MinimumSize = new Size(1, 1);
            rdoAccount.Name = "rdoAccount";
            rdoAccount.RadioButtonSize = 20;
            rdoAccount.Size = new Size(271, 57);
            rdoAccount.TabIndex = 5;
            rdoAccount.Text = "单用户媒体内容";
            rdoAccount.CheckedChanged += RBCheckedChanged;
            // 
            // rdoAllType
            // 
            rdoAllType.Font = new Font("微软雅黑", 13F);
            rdoAllType.Location = new Point(385, 62);
            rdoAllType.MinimumSize = new Size(1, 1);
            rdoAllType.Name = "rdoAllType";
            rdoAllType.RadioButtonSize = 20;
            rdoAllType.Size = new Size(188, 46);
            rdoAllType.TabIndex = 4;
            rdoAllType.Text = "全部内容";
            rdoAllType.CheckedChanged += RBCheckedChanged;
            // 
            // rdoLikes
            // 
            rdoLikes.Font = new Font("微软雅黑", 13F);
            rdoLikes.Location = new Point(199, 62);
            rdoLikes.MinimumSize = new Size(1, 1);
            rdoLikes.Name = "rdoLikes";
            rdoLikes.RadioButtonSize = 20;
            rdoLikes.Size = new Size(180, 46);
            rdoLikes.TabIndex = 3;
            rdoLikes.Text = "点赞内容";
            rdoLikes.CheckedChanged += RBCheckedChanged;
            // 
            // rdoBookMarks
            // 
            rdoBookMarks.Checked = true;
            rdoBookMarks.Font = new Font("微软雅黑", 13F);
            rdoBookMarks.Location = new Point(20, 62);
            rdoBookMarks.MinimumSize = new Size(1, 1);
            rdoBookMarks.Name = "rdoBookMarks";
            rdoBookMarks.RadioButtonSize = 20;
            rdoBookMarks.Size = new Size(172, 46);
            rdoBookMarks.TabIndex = 2;
            rdoBookMarks.Text = "书签内容";
            rdoBookMarks.CheckedChanged += RBCheckedChanged;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 13F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(20, 18);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(553, 41);
            uiLabel3.TabIndex = 1;
            uiLabel3.Text = "获取内容类型：";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel4
            // 
            uiPanel4.Controls.Add(cbGIF);
            uiPanel4.Controls.Add(cbVideo);
            uiPanel4.Controls.Add(cbPhoto);
            uiPanel4.Controls.Add(uiLabel4);
            uiPanel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel4.Location = new Point(18, 546);
            uiPanel4.Margin = new Padding(4, 5, 4, 5);
            uiPanel4.MinimumSize = new Size(1, 1);
            uiPanel4.Name = "uiPanel4";
            uiPanel4.Size = new Size(593, 132);
            uiPanel4.TabIndex = 4;
            uiPanel4.Text = null;
            uiPanel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cbGIF
            // 
            cbGIF.CheckBoxSize = 20;
            cbGIF.Font = new Font("微软雅黑", 13F);
            cbGIF.ForeColor = Color.FromArgb(48, 48, 48);
            cbGIF.Location = new Point(352, 66);
            cbGIF.MinimumSize = new Size(1, 1);
            cbGIF.Name = "cbGIF";
            cbGIF.Size = new Size(160, 38);
            cbGIF.TabIndex = 4;
            cbGIF.Text = "动图";
            // 
            // cbVideo
            // 
            cbVideo.CheckBoxSize = 20;
            cbVideo.Font = new Font("微软雅黑", 13F);
            cbVideo.ForeColor = Color.FromArgb(48, 48, 48);
            cbVideo.Location = new Point(186, 66);
            cbVideo.MinimumSize = new Size(1, 1);
            cbVideo.Name = "cbVideo";
            cbVideo.Size = new Size(160, 38);
            cbVideo.TabIndex = 3;
            cbVideo.Text = "视频";
            // 
            // cbPhoto
            // 
            cbPhoto.CheckBoxSize = 20;
            cbPhoto.Font = new Font("微软雅黑", 13F);
            cbPhoto.ForeColor = Color.FromArgb(48, 48, 48);
            cbPhoto.Location = new Point(20, 66);
            cbPhoto.MinimumSize = new Size(1, 1);
            cbPhoto.Name = "cbPhoto";
            cbPhoto.Size = new Size(160, 38);
            cbPhoto.TabIndex = 2;
            cbPhoto.Text = "图片";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 13F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(20, 13);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(553, 41);
            uiLabel4.TabIndex = 1;
            uiLabel4.Text = "下载内容类型：";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel5
            // 
            uiPanel5.Controls.Add(txtHttpProxy);
            uiPanel5.Controls.Add(cbEnableProxy);
            uiPanel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel5.Location = new Point(18, 688);
            uiPanel5.Margin = new Padding(4, 5, 4, 5);
            uiPanel5.MinimumSize = new Size(1, 1);
            uiPanel5.Name = "uiPanel5";
            uiPanel5.Size = new Size(593, 144);
            uiPanel5.TabIndex = 5;
            uiPanel5.Text = null;
            uiPanel5.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txtHttpProxy
            // 
            txtHttpProxy.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtHttpProxy.Location = new Point(20, 65);
            txtHttpProxy.Margin = new Padding(4, 5, 4, 5);
            txtHttpProxy.MinimumSize = new Size(1, 16);
            txtHttpProxy.Name = "txtHttpProxy";
            txtHttpProxy.Padding = new Padding(5);
            txtHttpProxy.ShowText = false;
            txtHttpProxy.Size = new Size(553, 57);
            txtHttpProxy.TabIndex = 2;
            txtHttpProxy.TextAlignment = ContentAlignment.MiddleLeft;
            txtHttpProxy.Watermark = "";
            // 
            // cbEnableProxy
            // 
            cbEnableProxy.CheckBoxSize = 20;
            cbEnableProxy.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbEnableProxy.ForeColor = Color.FromArgb(48, 48, 48);
            cbEnableProxy.Location = new Point(20, 14);
            cbEnableProxy.MinimumSize = new Size(1, 1);
            cbEnableProxy.Name = "cbEnableProxy";
            cbEnableProxy.Size = new Size(553, 43);
            cbEnableProxy.TabIndex = 3;
            cbEnableProxy.Text = "启用代理：";
            // 
            // uiPanel7
            // 
            uiPanel7.Controls.Add(uiButton2);
            uiPanel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel7.Location = new Point(619, 190);
            uiPanel7.Margin = new Padding(4, 5, 4, 5);
            uiPanel7.MinimumSize = new Size(1, 1);
            uiPanel7.Name = "uiPanel7";
            uiPanel7.Size = new Size(362, 123);
            uiPanel7.TabIndex = 7;
            uiPanel7.Text = null;
            uiPanel7.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton2
            // 
            uiButton2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiButton2.FillColor = Color.FromArgb(110, 190, 40);
            uiButton2.FillColor2 = Color.FromArgb(110, 190, 40);
            uiButton2.FillHoverColor = Color.FromArgb(139, 203, 83);
            uiButton2.FillPressColor = Color.FromArgb(88, 152, 32);
            uiButton2.FillSelectedColor = Color.FromArgb(88, 152, 32);
            uiButton2.Font = new Font("微软雅黑", 13F);
            uiButton2.LightColor = Color.FromArgb(245, 251, 241);
            uiButton2.Location = new Point(24, 22);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = Color.FromArgb(110, 190, 40);
            uiButton2.RectHoverColor = Color.FromArgb(139, 203, 83);
            uiButton2.RectPressColor = Color.FromArgb(88, 152, 32);
            uiButton2.RectSelectedColor = Color.FromArgb(88, 152, 32);
            uiButton2.Size = new Size(312, 80);
            uiButton2.Style = Sunny.UI.UIStyle.Custom;
            uiButton2.TabIndex = 4;
            uiButton2.Text = "开始下载";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiButton3
            // 
            uiButton3.FillColor = Color.FromArgb(0, 150, 136);
            uiButton3.FillColor2 = Color.FromArgb(0, 150, 136);
            uiButton3.FillHoverColor = Color.FromArgb(51, 171, 160);
            uiButton3.FillPressColor = Color.FromArgb(0, 120, 109);
            uiButton3.FillSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton3.Font = new Font("微软雅黑", 12F);
            uiButton3.LightColor = Color.FromArgb(238, 248, 248);
            uiButton3.Location = new Point(24, 19);
            uiButton3.MinimumSize = new Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = Color.FromArgb(0, 150, 136);
            uiButton3.RectHoverColor = Color.FromArgb(51, 171, 160);
            uiButton3.RectPressColor = Color.FromArgb(0, 120, 109);
            uiButton3.RectSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton3.Size = new Size(312, 57);
            uiButton3.Style = Sunny.UI.UIStyle.Custom;
            uiButton3.TabIndex = 5;
            uiButton3.Text = "Cookies设置菜单";
            uiButton3.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiLabel8
            // 
            uiLabel8.Dock = DockStyle.Bottom;
            uiLabel8.Font = new Font("微软雅黑", 10F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(0, 843);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(998, 35);
            uiLabel8.TabIndex = 8;
            uiLabel8.Text = "CopyRight";
            uiLabel8.TextAlign = ContentAlignment.TopCenter;
            // 
            // uiLinkLabel1
            // 
            uiLinkLabel1.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            uiLinkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            uiLinkLabel1.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLinkLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLinkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            uiLinkLabel1.LinkColor = Color.DodgerBlue;
            uiLinkLabel1.Location = new Point(840, 843);
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
            uiLinkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            uiLinkLabel2.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLinkLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLinkLabel2.LinkBehavior = LinkBehavior.AlwaysUnderline;
            uiLinkLabel2.LinkColor = Color.DodgerBlue;
            uiLinkLabel2.Location = new Point(18, 843);
            uiLinkLabel2.Name = "uiLinkLabel2";
            uiLinkLabel2.Size = new Size(123, 30);
            uiLinkLabel2.TabIndex = 9;
            uiLinkLabel2.TabStop = true;
            uiLinkLabel2.Text = "B站地址";
            uiLinkLabel2.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            uiLinkLabel2.Click += uiLinkLabel2_Click;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiButton6);
            uiPanel1.Controls.Add(uiButton5);
            uiPanel1.Controls.Add(uiButton3);
            uiPanel1.Controls.Add(uiButton4);
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.Location = new Point(619, 324);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(362, 286);
            uiPanel1.TabIndex = 4;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton6
            // 
            uiButton6.FillColor = Color.FromArgb(0, 150, 136);
            uiButton6.FillColor2 = Color.FromArgb(0, 150, 136);
            uiButton6.FillHoverColor = Color.FromArgb(51, 171, 160);
            uiButton6.FillPressColor = Color.FromArgb(0, 120, 109);
            uiButton6.FillSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton6.Font = new Font("微软雅黑", 12F);
            uiButton6.LightColor = Color.FromArgb(238, 248, 248);
            uiButton6.Location = new Point(24, 145);
            uiButton6.MinimumSize = new Size(1, 1);
            uiButton6.Name = "uiButton6";
            uiButton6.RectColor = Color.FromArgb(0, 150, 136);
            uiButton6.RectHoverColor = Color.FromArgb(51, 171, 160);
            uiButton6.RectPressColor = Color.FromArgb(0, 120, 109);
            uiButton6.RectSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton6.Size = new Size(312, 57);
            uiButton6.Style = Sunny.UI.UIStyle.Custom;
            uiButton6.TabIndex = 7;
            uiButton6.Text = "MetaData数据管理";
            uiButton6.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton6.Click += uiButton6_Click;
            // 
            // uiButton5
            // 
            uiButton5.FillColor = Color.FromArgb(0, 150, 136);
            uiButton5.FillColor2 = Color.FromArgb(0, 150, 136);
            uiButton5.FillHoverColor = Color.FromArgb(51, 171, 160);
            uiButton5.FillPressColor = Color.FromArgb(0, 120, 109);
            uiButton5.FillSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton5.Font = new Font("微软雅黑", 12F);
            uiButton5.LightColor = Color.FromArgb(238, 248, 248);
            uiButton5.Location = new Point(24, 82);
            uiButton5.MinimumSize = new Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.RectColor = Color.FromArgb(0, 150, 136);
            uiButton5.RectHoverColor = Color.FromArgb(51, 171, 160);
            uiButton5.RectPressColor = Color.FromArgb(0, 120, 109);
            uiButton5.RectSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton5.Size = new Size(312, 57);
            uiButton5.Style = Sunny.UI.UIStyle.Custom;
            uiButton5.TabIndex = 6;
            uiButton5.Text = "推文过滤设置菜单";
            uiButton5.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton5.Click += uiButton5_Click;
            // 
            // uiButton4
            // 
            uiButton4.Font = new Font("微软雅黑", 12F);
            uiButton4.Location = new Point(24, 208);
            uiButton4.MinimumSize = new Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new Size(312, 57);
            uiButton4.TabIndex = 3;
            uiButton4.Text = "语言 / Language";
            uiButton4.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // txtRetryTime
            // 
            txtRetryTime.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRetryTime.Location = new Point(24, 147);
            txtRetryTime.Margin = new Padding(4, 5, 4, 5);
            txtRetryTime.MinimumSize = new Size(1, 16);
            txtRetryTime.Name = "txtRetryTime";
            txtRetryTime.Padding = new Padding(5);
            txtRetryTime.ShowText = false;
            txtRetryTime.Size = new Size(312, 44);
            txtRetryTime.TabIndex = 5;
            txtRetryTime.TextAlignment = ContentAlignment.MiddleLeft;
            txtRetryTime.Watermark = "";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 13F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(24, 101);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(312, 41);
            uiLabel5.TabIndex = 4;
            uiLabel5.Text = "失败重试次数：";
            uiLabel5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtTimeOut
            // 
            txtTimeOut.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtTimeOut.Location = new Point(24, 52);
            txtTimeOut.Margin = new Padding(4, 5, 4, 5);
            txtTimeOut.MinimumSize = new Size(1, 16);
            txtTimeOut.Name = "txtTimeOut";
            txtTimeOut.Padding = new Padding(5);
            txtTimeOut.ShowText = false;
            txtTimeOut.Size = new Size(312, 44);
            txtTimeOut.TabIndex = 3;
            txtTimeOut.TextAlignment = ContentAlignment.MiddleLeft;
            txtTimeOut.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 13F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(24, 6);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(312, 41);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "TimeOut时间(s)：";
            uiLabel1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // uiPanel8
            // 
            uiPanel8.Controls.Add(uiLine1);
            uiPanel8.Controls.Add(uiLabel7);
            uiPanel8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel8.Location = new Point(619, 57);
            uiPanel8.Margin = new Padding(4, 5, 4, 5);
            uiPanel8.MinimumSize = new Size(1, 1);
            uiPanel8.Name = "uiPanel8";
            uiPanel8.Size = new Size(362, 123);
            uiPanel8.TabIndex = 6;
            uiPanel8.Text = null;
            uiPanel8.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("微软雅黑", 13F);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.LineSize = 2;
            uiLine1.Location = new Point(20, 8);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(316, 41);
            uiLine1.TabIndex = 10;
            uiLine1.Text = " 当前使用账户 ";
            // 
            // uiLabel7
            // 
            uiLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uiLabel7.Font = new Font("微软雅黑", 12F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(20, 54);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(316, 57);
            uiLabel7.TabIndex = 3;
            uiLabel7.Text = "剧毒的KCN";
            uiLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel9
            // 
            uiPanel9.Controls.Add(txtRetryTime);
            uiPanel9.Controls.Add(uiLabel1);
            uiPanel9.Controls.Add(uiLabel5);
            uiPanel9.Controls.Add(txtTimeOut);
            uiPanel9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel9.Location = new Point(619, 619);
            uiPanel9.Margin = new Padding(4, 5, 4, 5);
            uiPanel9.MinimumSize = new Size(1, 1);
            uiPanel9.Name = "uiPanel9";
            uiPanel9.Size = new Size(362, 213);
            uiPanel9.TabIndex = 10;
            uiPanel9.Text = null;
            uiPanel9.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(998, 878);
            Controls.Add(uiPanel9);
            Controls.Add(uiPanel8);
            Controls.Add(uiPanel1);
            Controls.Add(uiLinkLabel2);
            Controls.Add(uiLinkLabel1);
            Controls.Add(uiLabel8);
            Controls.Add(uiPanel7);
            Controls.Add(uiPanel5);
            Controls.Add(uiPanel4);
            Controls.Add(uiPanel3);
            Controls.Add(uiPanel2);
            MaximizeBox = false;
            Name = "FormMain";
            Text = "KCN-Server";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += FormMain_Load;
            uiPanel2.ResumeLayout(false);
            uiPanel3.ResumeLayout(false);
            uiPanel4.ResumeLayout(false);
            uiPanel5.ResumeLayout(false);
            uiPanel7.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            uiPanel8.ResumeLayout(false);
            uiPanel9.ResumeLayout(false);
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
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UICheckBox cbEnableProxy;
        private Sunny.UI.UITextBox txtHttpProxy;
        private Sunny.UI.UIPanel uiPanel7;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private Sunny.UI.UILinkLabel uiLinkLabel2;
        private Sunny.UI.UICheckBox cbGIF;
        private Sunny.UI.UICheckBox cbVideo;
        private Sunny.UI.UICheckBox cbPhoto;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtRetryTime;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtTimeOut;
        private Sunny.UI.UIPanel uiPanel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIPanel uiPanel9;
        private Sunny.UI.UITextBox txtGetType;
        private Sunny.UI.UIRadioButton rdoAccount;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIRadioButton rdoTweet;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton uiButton7;
    }
}
