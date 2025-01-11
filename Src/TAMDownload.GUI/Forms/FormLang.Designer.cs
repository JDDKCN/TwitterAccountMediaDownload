namespace TAMDownload.GUI.Forms
{
    partial class FormLang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLang));
            uiComboBox1 = new Sunny.UI.UIComboBox();
            uiButton4 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiComboBox1
            // 
            uiComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiComboBox1.DataSource = null;
            uiComboBox1.DropDownAutoWidth = true;
            uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.FilterIgnoreCase = true;
            uiComboBox1.Font = new Font("微软雅黑", 13F);
            uiComboBox1.ItemHeight = 35;
            uiComboBox1.ItemHoverColor = Color.FromArgb(155, 200, 255);
            uiComboBox1.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            uiComboBox1.Location = new Point(44, 80);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(449, 62);
            uiComboBox1.SymbolSize = 24;
            uiComboBox1.TabIndex = 0;
            uiComboBox1.Text = "default";
            uiComboBox1.TextAlignment = ContentAlignment.MiddleCenter;
            uiComboBox1.Watermark = "";
            // 
            // uiButton4
            // 
            uiButton4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiButton4.Font = new Font("微软雅黑", 13F);
            uiButton4.Location = new Point(44, 150);
            uiButton4.MinimumSize = new Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new Size(449, 62);
            uiButton4.TabIndex = 4;
            uiButton4.Text = "确认 / OK";
            uiButton4.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // FormLang
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(538, 265);
            Controls.Add(uiButton4);
            Controls.Add(uiComboBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLang";
            Text = "选择您的语言 / Select your language";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += FormLang_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIButton uiButton4;
    }
}