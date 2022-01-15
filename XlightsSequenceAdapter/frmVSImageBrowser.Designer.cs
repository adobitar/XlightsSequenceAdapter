
namespace XlightsSequenceAdapter
{
    partial class frmVSImageBrowser
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
            this.components = new System.ComponentModel.Container();
            this.cmdDisplayImages = new System.Windows.Forms.Button();
            this.lnkImgPath = new System.Windows.Forms.LinkLabel();
            this.txtLibraryPath = new System.Windows.Forms.TextBox();
            this.diagFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cmdDisplayImages
            // 
            this.cmdDisplayImages.Location = new System.Drawing.Point(475, 10);
            this.cmdDisplayImages.Name = "cmdDisplayImages";
            this.cmdDisplayImages.Size = new System.Drawing.Size(97, 23);
            this.cmdDisplayImages.TabIndex = 22;
            this.cmdDisplayImages.Text = "Display Images";
            this.cmdDisplayImages.UseVisualStyleBackColor = true;
            this.cmdDisplayImages.Click += new System.EventHandler(this.cmdDisplayImages_Click);
            // 
            // lnkImgPath
            // 
            this.lnkImgPath.AutoSize = true;
            this.lnkImgPath.Location = new System.Drawing.Point(8, 15);
            this.lnkImgPath.Name = "lnkImgPath";
            this.lnkImgPath.Size = new System.Drawing.Size(61, 13);
            this.lnkImgPath.TabIndex = 21;
            this.lnkImgPath.TabStop = true;
            this.lnkImgPath.Text = "Image Path";
            this.lnkImgPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkImgPath_LinkClicked);
            // 
            // txtLibraryPath
            // 
            this.txtLibraryPath.Location = new System.Drawing.Point(75, 12);
            this.txtLibraryPath.Name = "txtLibraryPath";
            this.txtLibraryPath.Size = new System.Drawing.Size(394, 20);
            this.txtLibraryPath.TabIndex = 20;
            this.txtLibraryPath.Text = "E:\\Adonis\\Documents\\Visual Studio 2019\\VS2019 Image Library\\vswin2019";
            // 
            // pnlFlow
            // 
            this.pnlFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFlow.AutoScroll = true;
            this.pnlFlow.Location = new System.Drawing.Point(12, 39);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(710, 350);
            this.pnlFlow.TabIndex = 23;
            // 
            // progBar
            // 
            this.progBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBar.Location = new System.Drawing.Point(579, 10);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(143, 23);
            this.progBar.TabIndex = 24;
            this.progBar.Visible = false;
            // 
            // frmVSImageBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 401);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.pnlFlow);
            this.Controls.Add(this.cmdDisplayImages);
            this.Controls.Add(this.lnkImgPath);
            this.Controls.Add(this.txtLibraryPath);
            this.MinimumSize = new System.Drawing.Size(750, 440);
            this.Name = "frmVSImageBrowser";
            this.Text = "Visual Studio Image Library Browser";
            this.Load += new System.EventHandler(this.frmVSImageBrowser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDisplayImages;
        private System.Windows.Forms.LinkLabel lnkImgPath;
        private System.Windows.Forms.TextBox txtLibraryPath;
        private System.Windows.Forms.FolderBrowserDialog diagFolderBrowser;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FlowLayoutPanel pnlFlow;
        private System.Windows.Forms.ProgressBar progBar;
    }
}