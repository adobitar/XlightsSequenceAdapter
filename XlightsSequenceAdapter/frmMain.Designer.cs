
namespace XlightsSequenceAdapter
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharedFilesBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceAdapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nothingCurrentlyOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBrowse = new System.Windows.Forms.ToolStripButton();
            this.tsAdapt = new System.Windows.Forms.ToolStripButton();
            this.tsHelp = new System.Windows.Forms.ToolStripButton();
            this.imageBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharedFilesBrowserToolStripMenuItem,
            this.sequenceAdapterToolStripMenuItem,
            this.toolStripMenuItem1,
            this.preferencesToolStripMenuItem,
            this.imageBrowserToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "&Tools";
            // 
            // sharedFilesBrowserToolStripMenuItem
            // 
            this.sharedFilesBrowserToolStripMenuItem.Name = "sharedFilesBrowserToolStripMenuItem";
            this.sharedFilesBrowserToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sharedFilesBrowserToolStripMenuItem.Text = "&Shared Files Browser...";
            this.sharedFilesBrowserToolStripMenuItem.Click += new System.EventHandler(this.sharedFilesBrowserToolStripMenuItem_Click);
            // 
            // sequenceAdapterToolStripMenuItem
            // 
            this.sequenceAdapterToolStripMenuItem.Name = "sequenceAdapterToolStripMenuItem";
            this.sequenceAdapterToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sequenceAdapterToolStripMenuItem.Text = "Sequence &Adapter...";
            this.sequenceAdapterToolStripMenuItem.Click += new System.EventHandler(this.sequenceAdapterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nothingCurrentlyOpenToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // nothingCurrentlyOpenToolStripMenuItem
            // 
            this.nothingCurrentlyOpenToolStripMenuItem.Name = "nothingCurrentlyOpenToolStripMenuItem";
            this.nothingCurrentlyOpenToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.nothingCurrentlyOpenToolStripMenuItem.Text = "Nothing currently open...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.helpToolStripMenuItem1.Text = "&Help...";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBrowse,
            this.tsAdapt,
            this.tsHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBrowse
            // 
            this.tsBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBrowse.Image = ((System.Drawing.Image)(resources.GetObject("tsBrowse.Image")));
            this.tsBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBrowse.Name = "tsBrowse";
            this.tsBrowse.Size = new System.Drawing.Size(23, 22);
            this.tsBrowse.Text = "&Open";
            this.tsBrowse.ToolTipText = "Shared Sequences Browser";
            this.tsBrowse.Click += new System.EventHandler(this.tsBrowse_Click);
            // 
            // tsAdapt
            // 
            this.tsAdapt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdapt.Image = ((System.Drawing.Image)(resources.GetObject("tsAdapt.Image")));
            this.tsAdapt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdapt.Name = "tsAdapt";
            this.tsAdapt.Size = new System.Drawing.Size(23, 22);
            this.tsAdapt.Text = "&New";
            this.tsAdapt.ToolTipText = "Sequence Adapter";
            this.tsAdapt.Click += new System.EventHandler(this.tsAdapt_Click);
            // 
            // tsHelp
            // 
            this.tsHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsHelp.Image")));
            this.tsHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(23, 22);
            this.tsHelp.Text = "He&lp";
            this.tsHelp.Click += new System.EventHandler(this.tsHelp_Click);
            // 
            // imageBrowserToolStripMenuItem
            // 
            this.imageBrowserToolStripMenuItem.Name = "imageBrowserToolStripMenuItem";
            this.imageBrowserToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.imageBrowserToolStripMenuItem.Text = "Image Browser";
            this.imageBrowserToolStripMenuItem.Visible = false;
            this.imageBrowserToolStripMenuItem.Click += new System.EventHandler(this.imageBrowserToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 54);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "xLights Sequence Adapter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharedFilesBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceAdapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsBrowse;
        private System.Windows.Forms.ToolStripButton tsAdapt;
        private System.Windows.Forms.ToolStripButton tsHelp;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nothingCurrentlyOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageBrowserToolStripMenuItem;
    }
}