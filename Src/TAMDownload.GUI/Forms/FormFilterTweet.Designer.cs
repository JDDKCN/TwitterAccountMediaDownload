namespace TAMDownload.GUI.Forms
{
    partial class FormFilterTweet
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
            uiPanel5 = new Sunny.UI.UIPanel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiSwitch1 = new Sunny.UI.UISwitch();
            txtWord = new Sunny.UI.UITextBox();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiSwitch2 = new Sunny.UI.UISwitch();
            uiLabel2 = new Sunny.UI.UILabel();
            listBoxWords = new Sunny.UI.UIListBox();
            uiPanel3 = new Sunny.UI.UIPanel();
            uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            uiPanel4 = new Sunny.UI.UIPanel();
            pictureBox1 = new PictureBox();
            uiPanel6 = new Sunny.UI.UIPanel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiDatetimePicker2 = new Sunny.UI.UIDatetimePicker();
            uiLabel4 = new Sunny.UI.UILabel();
            uiDatetimePicker1 = new Sunny.UI.UIDatetimePicker();
            uiPanel5.SuspendLayout();
            uiPanel1.SuspendLayout();
            uiPanel3.SuspendLayout();
            uiPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            uiPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel5
            // 
            uiPanel5.Controls.Add(uiLabel1);
            uiPanel5.Controls.Add(uiSwitch1);
            uiPanel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel5.Location = new Point(18, 50);
            uiPanel5.Margin = new Padding(4, 5, 4, 5);
            uiPanel5.MinimumSize = new Size(1, 1);
            uiPanel5.Name = "uiPanel5";
            uiPanel5.Size = new Size(413, 82);
            uiPanel5.TabIndex = 6;
            uiPanel5.Text = null;
            uiPanel5.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 13F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(141, 19);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(250, 44);
            uiLabel1.TabIndex = 8;
            uiLabel1.Text = "启用屏蔽词过滤";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiSwitch1
            // 
            uiSwitch1.ActiveText = "";
            uiSwitch1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSwitch1.InActiveText = "";
            uiSwitch1.Location = new Point(19, 19);
            uiSwitch1.MinimumSize = new Size(1, 1);
            uiSwitch1.Name = "uiSwitch1";
            uiSwitch1.Size = new Size(116, 44);
            uiSwitch1.TabIndex = 7;
            uiSwitch1.ValueChanged += uiSwitch1_ValueChanged;
            // 
            // txtWord
            // 
            txtWord.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtWord.Location = new Point(19, 52);
            txtWord.Margin = new Padding(4, 5, 4, 5);
            txtWord.MinimumSize = new Size(1, 16);
            txtWord.Name = "txtWord";
            txtWord.Padding = new Padding(5);
            txtWord.ShowText = false;
            txtWord.Size = new Size(371, 50);
            txtWord.TabIndex = 2;
            txtWord.TextAlignment = ContentAlignment.MiddleLeft;
            txtWord.Watermark = "";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiSwitch2);
            uiPanel1.Controls.Add(uiLabel2);
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.Location = new Point(439, 50);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(413, 82);
            uiPanel1.TabIndex = 9;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiSwitch2
            // 
            uiSwitch2.ActiveText = "";
            uiSwitch2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSwitch2.InActiveText = "";
            uiSwitch2.Location = new Point(20, 19);
            uiSwitch2.MinimumSize = new Size(1, 1);
            uiSwitch2.Name = "uiSwitch2";
            uiSwitch2.Size = new Size(116, 44);
            uiSwitch2.TabIndex = 7;
            uiSwitch2.ValueChanged += uiSwitch2_ValueChanged;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 13F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(142, 19);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(249, 44);
            uiLabel2.TabIndex = 8;
            uiLabel2.Text = "启用时间段过滤";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBoxWords
            // 
            listBoxWords.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            listBoxWords.HoverColor = Color.FromArgb(155, 200, 255);
            listBoxWords.ItemHeight = 35;
            listBoxWords.ItemSelectForeColor = Color.White;
            listBoxWords.Location = new Point(18, 142);
            listBoxWords.Margin = new Padding(4, 5, 4, 5);
            listBoxWords.MinimumSize = new Size(1, 1);
            listBoxWords.Name = "listBoxWords";
            listBoxWords.Padding = new Padding(2);
            listBoxWords.ShowText = false;
            listBoxWords.Size = new Size(413, 327);
            listBoxWords.TabIndex = 10;
            listBoxWords.Text = "uiListBox1";
            listBoxWords.SelectedIndexChanged += listBoxWords_SelectedIndexChanged;
            // 
            // uiPanel3
            // 
            uiPanel3.Controls.Add(uiSymbolButton2);
            uiPanel3.Controls.Add(uiLabel3);
            uiPanel3.Controls.Add(uiSymbolButton1);
            uiPanel3.Controls.Add(txtWord);
            uiPanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel3.Location = new Point(18, 479);
            uiPanel3.Margin = new Padding(4, 5, 4, 5);
            uiPanel3.MinimumSize = new Size(1, 1);
            uiPanel3.Name = "uiPanel3";
            uiPanel3.Size = new Size(413, 181);
            uiPanel3.TabIndex = 11;
            uiPanel3.Text = null;
            uiPanel3.TextAlignment = ContentAlignment.MiddleLeft;
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
            uiSymbolButton2.Location = new Point(220, 115);
            uiSymbolButton2.MinimumSize = new Size(1, 1);
            uiSymbolButton2.Name = "uiSymbolButton2";
            uiSymbolButton2.RectColor = Color.FromArgb(220, 155, 40);
            uiSymbolButton2.RectHoverColor = Color.FromArgb(227, 175, 83);
            uiSymbolButton2.RectPressColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.RectSelectedColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.Size = new Size(170, 50);
            uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton2.Symbol = 361453;
            uiSymbolButton2.TabIndex = 1;
            uiSymbolButton2.Text = "Del";
            uiSymbolButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton2.Click += uiSymbolButton2_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 13F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(19, 10);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(250, 37);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "屏蔽词：";
            uiLabel3.TextAlign = ContentAlignment.BottomLeft;
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
            uiSymbolButton1.Location = new Point(19, 115);
            uiSymbolButton1.MinimumSize = new Size(1, 1);
            uiSymbolButton1.Name = "uiSymbolButton1";
            uiSymbolButton1.RectColor = Color.FromArgb(110, 190, 40);
            uiSymbolButton1.RectHoverColor = Color.FromArgb(139, 203, 83);
            uiSymbolButton1.RectPressColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.RectSelectedColor = Color.FromArgb(88, 152, 32);
            uiSymbolButton1.Size = new Size(170, 50);
            uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton1.TabIndex = 0;
            uiSymbolButton1.Text = "Add";
            uiSymbolButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton1.Click += uiSymbolButton1_Click;
            // 
            // uiPanel4
            // 
            uiPanel4.Controls.Add(pictureBox1);
            uiPanel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel4.Location = new Point(439, 479);
            uiPanel4.Margin = new Padding(4, 5, 4, 5);
            uiPanel4.MinimumSize = new Size(1, 1);
            uiPanel4.Name = "uiPanel4";
            uiPanel4.Size = new Size(413, 181);
            uiPanel4.TabIndex = 12;
            uiPanel4.Text = null;
            uiPanel4.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // uiPanel6
            // 
            uiPanel6.Controls.Add(uiLabel5);
            uiPanel6.Controls.Add(uiDatetimePicker2);
            uiPanel6.Controls.Add(uiLabel4);
            uiPanel6.Controls.Add(uiDatetimePicker1);
            uiPanel6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel6.Location = new Point(439, 142);
            uiPanel6.Margin = new Padding(4, 5, 4, 5);
            uiPanel6.MinimumSize = new Size(1, 1);
            uiPanel6.Name = "uiPanel6";
            uiPanel6.Size = new Size(413, 327);
            uiPanel6.TabIndex = 14;
            uiPanel6.Text = null;
            uiPanel6.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 13F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(20, 169);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(250, 37);
            uiLabel5.TabIndex = 12;
            uiLabel5.Text = "设置截止日期：";
            uiLabel5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // uiDatetimePicker2
            // 
            uiDatetimePicker2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            uiDatetimePicker2.FillColor = Color.White;
            uiDatetimePicker2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDatetimePicker2.Location = new Point(20, 211);
            uiDatetimePicker2.Margin = new Padding(4, 5, 4, 5);
            uiDatetimePicker2.MaxLength = 19;
            uiDatetimePicker2.MinimumSize = new Size(63, 0);
            uiDatetimePicker2.Name = "uiDatetimePicker2";
            uiDatetimePicker2.Padding = new Padding(0, 0, 30, 2);
            uiDatetimePicker2.Size = new Size(371, 50);
            uiDatetimePicker2.SymbolDropDown = 61555;
            uiDatetimePicker2.SymbolNormal = 61555;
            uiDatetimePicker2.SymbolSize = 24;
            uiDatetimePicker2.TabIndex = 11;
            uiDatetimePicker2.Text = "2025-01-01 00:00:00";
            uiDatetimePicker2.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatetimePicker2.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            uiDatetimePicker2.Watermark = "";
            uiDatetimePicker2.ValueChanged += uiDatetimePicker2_ValueChanged;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 13F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(20, 46);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(250, 37);
            uiLabel4.TabIndex = 10;
            uiLabel4.Text = "设置起始日期：";
            uiLabel4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // uiDatetimePicker1
            // 
            uiDatetimePicker1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            uiDatetimePicker1.FillColor = Color.White;
            uiDatetimePicker1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDatetimePicker1.Location = new Point(20, 88);
            uiDatetimePicker1.Margin = new Padding(4, 5, 4, 5);
            uiDatetimePicker1.MaxLength = 19;
            uiDatetimePicker1.MinimumSize = new Size(63, 0);
            uiDatetimePicker1.Name = "uiDatetimePicker1";
            uiDatetimePicker1.Padding = new Padding(0, 0, 30, 2);
            uiDatetimePicker1.Size = new Size(371, 50);
            uiDatetimePicker1.SymbolDropDown = 61555;
            uiDatetimePicker1.SymbolNormal = 61555;
            uiDatetimePicker1.SymbolSize = 24;
            uiDatetimePicker1.TabIndex = 0;
            uiDatetimePicker1.Text = "2025-01-01 00:00:00";
            uiDatetimePicker1.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatetimePicker1.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            uiDatetimePicker1.Watermark = "";
            uiDatetimePicker1.ValueChanged += uiDatetimePicker1_ValueChanged;
            // 
            // FormFilterTweet
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(872, 676);
            Controls.Add(uiPanel6);
            Controls.Add(uiPanel4);
            Controls.Add(uiPanel3);
            Controls.Add(listBoxWords);
            Controls.Add(uiPanel1);
            Controls.Add(uiPanel5);
            MaximizeBox = false;
            Name = "FormFilterTweet";
            Text = "推文过滤";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += FormFilterTweet_Load;
            uiPanel5.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            uiPanel3.ResumeLayout(false);
            uiPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            uiPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UITextBox txtWord;
        private Sunny.UI.UISwitch uiSwitch1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UISwitch uiSwitch2;
        private Sunny.UI.UIListBox listBoxWords;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UIPanel uiPanel6;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker2;
        private Sunny.UI.UILabel uiLabel4;
        private PictureBox pictureBox1;
    }
}