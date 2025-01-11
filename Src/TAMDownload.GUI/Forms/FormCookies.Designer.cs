namespace TAMDownload.GUI.Forms
{
    partial class FormCookies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxAccounts = new Sunny.UI.UIListBox();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            richTextBoxCookies = new Sunny.UI.UIRichTextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            textBoxAccountName = new Sunny.UI.UITextBox();
            uiPanel2 = new Sunny.UI.UIPanel();
            uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            uiPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxAccounts
            // 
            listBoxAccounts.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            listBoxAccounts.HoverColor = Color.FromArgb(155, 200, 255);
            listBoxAccounts.ItemHeight = 35;
            listBoxAccounts.ItemSelectForeColor = Color.White;
            listBoxAccounts.Location = new Point(19, 51);
            listBoxAccounts.Margin = new Padding(4, 5, 4, 5);
            listBoxAccounts.MinimumSize = new Size(1, 1);
            listBoxAccounts.Name = "listBoxAccounts";
            listBoxAccounts.Padding = new Padding(2);
            listBoxAccounts.ShowText = false;
            listBoxAccounts.Size = new Size(341, 396);
            listBoxAccounts.TabIndex = 0;
            listBoxAccounts.Text = "uiListBox1";
            listBoxAccounts.SelectedIndexChanged += listBoxAccounts_SelectedIndexChanged;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiButton1);
            uiPanel1.Controls.Add(uiButton2);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(richTextBoxCookies);
            uiPanel1.Controls.Add(uiLabel4);
            uiPanel1.Controls.Add(textBoxAccountName);
            uiPanel1.Font = new Font("微软雅黑", 13F);
            uiPanel1.Location = new Point(368, 51);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(415, 477);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F);
            uiButton1.Location = new Point(237, 406);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(157, 57);
            uiButton1.TabIndex = 9;
            uiButton1.Text = "说明文档";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.FillColor = Color.FromArgb(0, 150, 136);
            uiButton2.FillColor2 = Color.FromArgb(0, 150, 136);
            uiButton2.FillHoverColor = Color.FromArgb(51, 171, 160);
            uiButton2.FillPressColor = Color.FromArgb(0, 120, 109);
            uiButton2.FillSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton2.Font = new Font("微软雅黑", 12F);
            uiButton2.LightColor = Color.FromArgb(238, 248, 248);
            uiButton2.Location = new Point(21, 406);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = Color.FromArgb(0, 150, 136);
            uiButton2.RectHoverColor = Color.FromArgb(51, 171, 160);
            uiButton2.RectPressColor = Color.FromArgb(0, 120, 109);
            uiButton2.RectSelectedColor = Color.FromArgb(0, 120, 109);
            uiButton2.Size = new Size(210, 57);
            uiButton2.Style = Sunny.UI.UIStyle.Custom;
            uiButton2.TabIndex = 8;
            uiButton2.Text = "保存并使用";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 13F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(21, 111);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(373, 41);
            uiLabel1.TabIndex = 7;
            uiLabel1.Text = "Cookies：";
            uiLabel1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // richTextBoxCookies
            // 
            richTextBoxCookies.FillColor = Color.White;
            richTextBoxCookies.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            richTextBoxCookies.Location = new Point(21, 157);
            richTextBoxCookies.Margin = new Padding(4, 5, 4, 5);
            richTextBoxCookies.MinimumSize = new Size(1, 1);
            richTextBoxCookies.Name = "richTextBoxCookies";
            richTextBoxCookies.Padding = new Padding(2);
            richTextBoxCookies.ShowText = false;
            richTextBoxCookies.Size = new Size(373, 216);
            richTextBoxCookies.TabIndex = 6;
            richTextBoxCookies.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 13F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(21, 9);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(373, 41);
            uiLabel4.TabIndex = 5;
            uiLabel4.Text = "Twitter用户名：";
            uiLabel4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Font = new Font("微软雅黑", 12F);
            textBoxAccountName.Location = new Point(21, 55);
            textBoxAccountName.Margin = new Padding(4, 5, 4, 5);
            textBoxAccountName.MinimumSize = new Size(1, 16);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Padding = new Padding(5);
            textBoxAccountName.ShowText = false;
            textBoxAccountName.Size = new Size(373, 51);
            textBoxAccountName.TabIndex = 4;
            textBoxAccountName.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxAccountName.Watermark = "";
            // 
            // uiPanel2
            // 
            uiPanel2.Controls.Add(uiSymbolButton2);
            uiPanel2.Controls.Add(uiSymbolButton1);
            uiPanel2.Font = new Font("微软雅黑", 13F);
            uiPanel2.Location = new Point(19, 457);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Size = new Size(341, 71);
            uiPanel2.TabIndex = 2;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton2
            // 
            uiSymbolButton2.FillColor = Color.FromArgb(220, 155, 40);
            uiSymbolButton2.FillColor2 = Color.FromArgb(220, 155, 40);
            uiSymbolButton2.FillHoverColor = Color.FromArgb(227, 175, 83);
            uiSymbolButton2.FillPressColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.FillSelectedColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton2.LightColor = Color.FromArgb(253, 249, 241);
            uiSymbolButton2.Location = new Point(186, 14);
            uiSymbolButton2.MinimumSize = new Size(1, 1);
            uiSymbolButton2.Name = "uiSymbolButton2";
            uiSymbolButton2.RectColor = Color.FromArgb(220, 155, 40);
            uiSymbolButton2.RectHoverColor = Color.FromArgb(227, 175, 83);
            uiSymbolButton2.RectPressColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.RectSelectedColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.Size = new Size(135, 43);
            uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton2.Symbol = 361453;
            uiSymbolButton2.TabIndex = 1;
            uiSymbolButton2.Text = "Del";
            uiSymbolButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton2.Click += uiSymbolButton2_Click;
            // 
            // uiSymbolButton1
            // 
            uiSymbolButton1.FillColor = Color.FromArgb(110, 190, 40);
            uiSymbolButton1.FillColor2 = Color.FromArgb(110, 190, 40);
            uiSymbolButton1.FillHoverColor = Color.FromArgb(139, 203, 83);
            uiSymbolButton1.FillPressColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.FillSelectedColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton1.LightColor = Color.FromArgb(245, 251, 241);
            uiSymbolButton1.Location = new Point(19, 14);
            uiSymbolButton1.MinimumSize = new Size(1, 1);
            uiSymbolButton1.Name = "uiSymbolButton1";
            uiSymbolButton1.RectColor = Color.FromArgb(110, 190, 40);
            uiSymbolButton1.RectHoverColor = Color.FromArgb(139, 203, 83);
            uiSymbolButton1.RectPressColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.RectSelectedColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.Size = new Size(135, 43);
            uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton1.TabIndex = 0;
            uiSymbolButton1.Text = "Add";
            uiSymbolButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton1.Click += uiSymbolButton1_Click;
            // 
            // FormCookies
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 548);
            Controls.Add(uiPanel2);
            Controls.Add(uiPanel1);
            Controls.Add(listBoxAccounts);
            MaximizeBox = false;
            Name = "FormCookies";
            Text = "FormCookies";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            FormClosed += FormCookies_FormClosed;
            Load += FormCookies_Load;
            uiPanel1.ResumeLayout(false);
            uiPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIListBox listBoxAccounts;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox textBoxAccountName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIRichTextBox richTextBoxCookies;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UIButton uiButton1;
    }
}