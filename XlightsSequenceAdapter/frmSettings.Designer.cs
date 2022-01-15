
namespace XlightsSequenceAdapter
{
    partial class frmSettings
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
            this.cmdSelectShowPath = new System.Windows.Forms.Button();
            this.lblRefShow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSelectPIZPath = new System.Windows.Forms.Button();
            this.lblPIZPath = new System.Windows.Forms.Label();
            this.chkOpenBrowser = new System.Windows.Forms.CheckBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.diagFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmdSelectShowPath
            // 
            this.cmdSelectShowPath.Location = new System.Drawing.Point(215, 12);
            this.cmdSelectShowPath.Name = "cmdSelectShowPath";
            this.cmdSelectShowPath.Size = new System.Drawing.Size(101, 23);
            this.cmdSelectShowPath.TabIndex = 5;
            this.cmdSelectShowPath.Text = "Browse...";
            this.cmdSelectShowPath.UseVisualStyleBackColor = true;
            this.cmdSelectShowPath.Click += new System.EventHandler(this.cmdSelectShowPath_Click);
            // 
            // lblRefShow
            // 
            this.lblRefShow.AutoSize = true;
            this.lblRefShow.Location = new System.Drawing.Point(322, 17);
            this.lblRefShow.Name = "lblRefShow";
            this.lblRefShow.Size = new System.Drawing.Size(90, 13);
            this.lblRefShow.TabIndex = 4;
            this.lblRefShow.Text = "- None Selected -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location of Your xLights Show Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Default Shared Sequences Directory";
            // 
            // cmdSelectPIZPath
            // 
            this.cmdSelectPIZPath.Location = new System.Drawing.Point(215, 41);
            this.cmdSelectPIZPath.Name = "cmdSelectPIZPath";
            this.cmdSelectPIZPath.Size = new System.Drawing.Size(101, 23);
            this.cmdSelectPIZPath.TabIndex = 7;
            this.cmdSelectPIZPath.Text = "Browse...";
            this.cmdSelectPIZPath.UseVisualStyleBackColor = true;
            this.cmdSelectPIZPath.Click += new System.EventHandler(this.cmdSelectPIZPath_Click);
            // 
            // lblPIZPath
            // 
            this.lblPIZPath.AutoSize = true;
            this.lblPIZPath.Location = new System.Drawing.Point(322, 46);
            this.lblPIZPath.Name = "lblPIZPath";
            this.lblPIZPath.Size = new System.Drawing.Size(90, 13);
            this.lblPIZPath.TabIndex = 8;
            this.lblPIZPath.Text = "- None Selected -";
            // 
            // chkOpenBrowser
            // 
            this.chkOpenBrowser.AutoSize = true;
            this.chkOpenBrowser.Checked = global::XlightsSequenceAdapter.Properties.Settings.Default.AlwaysOpenBrowserOnLaunch;
            this.chkOpenBrowser.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::XlightsSequenceAdapter.Properties.Settings.Default, "AlwaysOpenBrowserOnLaunch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkOpenBrowser.Location = new System.Drawing.Point(16, 82);
            this.chkOpenBrowser.Name = "chkOpenBrowser";
            this.chkOpenBrowser.Size = new System.Drawing.Size(242, 17);
            this.chkOpenBrowser.TabIndex = 9;
            this.chkOpenBrowser.Text = "Always open sequence browser when starting";
            this.chkOpenBrowser.UseVisualStyleBackColor = true;
            this.chkOpenBrowser.CheckedChanged += new System.EventHandler(this.chkOpenBrowser_CheckedChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(497, 108);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 143);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.chkOpenBrowser);
            this.Controls.Add(this.lblPIZPath);
            this.Controls.Add(this.cmdSelectPIZPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSelectShowPath);
            this.Controls.Add(this.lblRefShow);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Preferences...";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSelectShowPath;
        private System.Windows.Forms.Label lblRefShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSelectPIZPath;
        private System.Windows.Forms.Label lblPIZPath;
        private System.Windows.Forms.CheckBox chkOpenBrowser;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.FolderBrowserDialog diagFolderBrowser;
    }
}