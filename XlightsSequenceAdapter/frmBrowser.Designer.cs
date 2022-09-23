
namespace XlightsSequenceAdapter
{
    partial class frmBrowser
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
            this.cmdGetList = new System.Windows.Forms.Button();
            this.lnklblWorkingPath = new System.Windows.Forms.LinkLabel();
            this.txtPizPath = new System.Windows.Forms.TextBox();
            this.dgvFileList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripXSeq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenInXLights = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewColsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.cmdPersonalize = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdAnalyze = new System.Windows.Forms.Button();
            this.cmdMoveFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).BeginInit();
            this.contextMenuStripXSeq.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGetList
            // 
            this.cmdGetList.Location = new System.Drawing.Point(16, 44);
            this.cmdGetList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetList.Name = "cmdGetList";
            this.cmdGetList.Size = new System.Drawing.Size(129, 28);
            this.cmdGetList.TabIndex = 19;
            this.cmdGetList.Text = "Get Show List";
            this.cmdGetList.UseVisualStyleBackColor = true;
            this.cmdGetList.Click += new System.EventHandler(this.cmdGetList_Click);
            // 
            // lnklblWorkingPath
            // 
            this.lnklblWorkingPath.AutoSize = true;
            this.lnklblWorkingPath.Location = new System.Drawing.Point(15, 16);
            this.lnklblWorkingPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnklblWorkingPath.Name = "lnklblWorkingPath";
            this.lnklblWorkingPath.Size = new System.Drawing.Size(87, 16);
            this.lnklblWorkingPath.TabIndex = 18;
            this.lnklblWorkingPath.TabStop = true;
            this.lnklblWorkingPath.Text = "Working Path";
            this.lnklblWorkingPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblWorkingPath_LinkClicked);
            // 
            // txtPizPath
            // 
            this.txtPizPath.Location = new System.Drawing.Point(119, 12);
            this.txtPizPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPizPath.Name = "txtPizPath";
            this.txtPizPath.Size = new System.Drawing.Size(356, 22);
            this.txtPizPath.TabIndex = 17;
            this.txtPizPath.Text = "E:\\xLightsShow\\Shared Shows";
            // 
            // dgvFileList
            // 
            this.dgvFileList.AllowUserToAddRows = false;
            this.dgvFileList.AllowUserToDeleteRows = false;
            this.dgvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileList.ContextMenuStrip = this.contextMenuStripXSeq;
            this.dgvFileList.Location = new System.Drawing.Point(16, 80);
            this.dgvFileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.ReadOnly = true;
            this.dgvFileList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvFileList.Size = new System.Drawing.Size(1212, 887);
            this.dgvFileList.TabIndex = 16;
            this.dgvFileList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileList_CellDoubleClick);
            this.dgvFileList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFileList_CellMouseDown);
            this.dgvFileList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileList_CellValueChanged);
            this.dgvFileList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFileList_ColumnHeaderMouseClick);
            this.dgvFileList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFileList_RowHeaderMouseClick);
            this.dgvFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvFileList_MouseMove);
            // 
            // contextMenuStripXSeq
            // 
            this.contextMenuStripXSeq.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripXSeq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenInXLights,
            this.openFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewColsToolStripMenuItem});
            this.contextMenuStripXSeq.Name = "contextMenuStripXSeq";
            this.contextMenuStripXSeq.Size = new System.Drawing.Size(181, 82);
            // 
            // toolStripMenuItemOpenInXLights
            // 
            this.toolStripMenuItemOpenInXLights.Name = "toolStripMenuItemOpenInXLights";
            this.toolStripMenuItemOpenInXLights.Size = new System.Drawing.Size(180, 24);
            this.toolStripMenuItemOpenInXLights.Text = "Open In xLights";
            this.toolStripMenuItemOpenInXLights.Click += new System.EventHandler(this.toolStripMenuItemOpenInXLights_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // viewColsToolStripMenuItem
            // 
            this.viewColsToolStripMenuItem.Name = "viewColsToolStripMenuItem";
            this.viewColsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.viewColsToolStripMenuItem.Text = "View Cols";
            // 
            // progBar
            // 
            this.progBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBar.Location = new System.Drawing.Point(484, 10);
            this.progBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(744, 28);
            this.progBar.TabIndex = 25;
            this.progBar.Visible = false;
            // 
            // cmdPersonalize
            // 
            this.cmdPersonalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPersonalize.Location = new System.Drawing.Point(1099, 44);
            this.cmdPersonalize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPersonalize.Name = "cmdPersonalize";
            this.cmdPersonalize.Size = new System.Drawing.Size(129, 28);
            this.cmdPersonalize.TabIndex = 26;
            this.cmdPersonalize.Text = "Personalize";
            this.cmdPersonalize.UseVisualStyleBackColor = true;
            this.cmdPersonalize.Click += new System.EventHandler(this.cmdPersonalize_Click);
            // 
            // cmdAnalyze
            // 
            this.cmdAnalyze.Location = new System.Drawing.Point(153, 44);
            this.cmdAnalyze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAnalyze.Name = "cmdAnalyze";
            this.cmdAnalyze.Size = new System.Drawing.Size(129, 28);
            this.cmdAnalyze.TabIndex = 27;
            this.cmdAnalyze.Text = "Zip/PIZ Report";
            this.cmdAnalyze.UseVisualStyleBackColor = true;
            this.cmdAnalyze.Click += new System.EventHandler(this.cmdAnalyze_Click);
            // 
            // cmdMoveFiles
            // 
            this.cmdMoveFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMoveFiles.Location = new System.Drawing.Point(1099, 44);
            this.cmdMoveFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMoveFiles.Name = "cmdMoveFiles";
            this.cmdMoveFiles.Size = new System.Drawing.Size(129, 28);
            this.cmdMoveFiles.TabIndex = 28;
            this.cmdMoveFiles.Text = "Move Files";
            this.cmdMoveFiles.UseVisualStyleBackColor = true;
            this.cmdMoveFiles.Click += new System.EventHandler(this.cmdMoveFiles_Click);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 982);
            this.Controls.Add(this.cmdMoveFiles);
            this.Controls.Add(this.cmdAnalyze);
            this.Controls.Add(this.cmdPersonalize);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.cmdGetList);
            this.Controls.Add(this.lnklblWorkingPath);
            this.Controls.Add(this.txtPizPath);
            this.Controls.Add(this.dgvFileList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(927, 420);
            this.Name = "frmBrowser";
            this.Text = "Sequence and File Browser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).EndInit();
            this.contextMenuStripXSeq.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetList;
        private System.Windows.Forms.LinkLabel lnklblWorkingPath;
        private System.Windows.Forms.TextBox txtPizPath;
        private System.Windows.Forms.DataGridView dgvFileList;
        private System.Windows.Forms.FolderBrowserDialog diagFolderBrowser;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Button cmdPersonalize;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdAnalyze;
        private System.Windows.Forms.Button cmdMoveFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripXSeq;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenInXLights;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem viewColsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
    }
}