namespace TAMDownload.GUI.Forms
{
    partial class FormMetadataManager
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
            listBoxFiles = new Sunny.UI.UIListBox();
            uiPanel3 = new Sunny.UI.UIPanel();
            uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            uiPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxFiles
            // 
            listBoxFiles.Font = new Font("微软雅黑", 13F, FontStyle.Regular, GraphicsUnit.Point, 134);
            listBoxFiles.HoverColor = Color.FromArgb(155, 200, 255);
            listBoxFiles.ItemHeight = 35;
            listBoxFiles.ItemSelectForeColor = Color.White;
            listBoxFiles.Location = new Point(23, 57);
            listBoxFiles.Margin = new Padding(4, 5, 4, 5);
            listBoxFiles.MinimumSize = new Size(1, 1);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Padding = new Padding(2);
            listBoxFiles.ShowText = false;
            listBoxFiles.Size = new Size(413, 452);
            listBoxFiles.TabIndex = 11;
            listBoxFiles.Text = "uiListBox1";
            // 
            // uiPanel3
            // 
            uiPanel3.Controls.Add(uiSymbolButton2);
            uiPanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel3.Location = new Point(23, 519);
            uiPanel3.Margin = new Padding(4, 5, 4, 5);
            uiPanel3.MinimumSize = new Size(1, 1);
            uiPanel3.Name = "uiPanel3";
            uiPanel3.Size = new Size(413, 108);
            uiPanel3.TabIndex = 12;
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
            uiSymbolButton2.Location = new Point(28, 27);
            uiSymbolButton2.MinimumSize = new Size(1, 1);
            uiSymbolButton2.Name = "uiSymbolButton2";
            uiSymbolButton2.RectColor = Color.FromArgb(220, 155, 40);
            uiSymbolButton2.RectHoverColor = Color.FromArgb(227, 175, 83);
            uiSymbolButton2.RectPressColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.RectSelectedColor = Color.FromArgb(176, 124, 32);
            uiSymbolButton2.Size = new Size(356, 56);
            uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton2.Symbol = 361453;
            uiSymbolButton2.TabIndex = 1;
            uiSymbolButton2.Text = "Del";
            uiSymbolButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton2.Click += uiSymbolButton2_Click;
            // 
            // FormMetadataManager
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(460, 643);
            Controls.Add(uiPanel3);
            Controls.Add(listBoxFiles);
            MaximizeBox = false;
            Name = "FormMetadataManager";
            Text = "Metadata管理";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += FormMetadataManager_Load;
            uiPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIListBox listBoxFiles;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
    }
}