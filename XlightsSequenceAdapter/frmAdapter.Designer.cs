
namespace XlightsSequenceAdapter
{
    partial class frmAdapter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdapter));
            this.diagOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.diagFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRefShow = new System.Windows.Forms.Label();
            this.cmdSelectReference = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdOpenShow = new System.Windows.Forms.Button();
            this.lblShowName = new System.Windows.Forms.Label();
            this.diagSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabAssets = new System.Windows.Forms.TabPage();
            this.cmdFindAssetFiles = new System.Windows.Forms.Button();
            this.cmdExportShowSAF = new System.Windows.Forms.Button();
            this.listShowAssets = new System.Windows.Forms.TreeView();
            this.chkCopyAssets = new System.Windows.Forms.CheckBox();
            this.chkRemapAssets = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabLayout = new System.Windows.Forms.TabPage();
            this.chkShowMapToSubs = new System.Windows.Forms.CheckBox();
            this.chkHideNoEffects = new System.Windows.Forms.CheckBox();
            this.cmdExportShowLM = new System.Windows.Forms.Button();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.colShowModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelFXLayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelFXCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelFXDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelFX = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMapTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.linkAssetLocation = new System.Windows.Forms.LinkLabel();
            this.lblAssetLocation = new System.Windows.Forms.Label();
            this.tabAssets.SuspendLayout();
            this.tabLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagFolderBrowser
            // 
            this.diagFolderBrowser.Description = resources.GetString("diagFolderBrowser.Description");
            this.diagFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.diagFolderBrowser.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location of your show directory";
            // 
            // lblRefShow
            // 
            this.lblRefShow.AutoSize = true;
            this.lblRefShow.Location = new System.Drawing.Point(279, 9);
            this.lblRefShow.Name = "lblRefShow";
            this.lblRefShow.Size = new System.Drawing.Size(90, 13);
            this.lblRefShow.TabIndex = 1;
            this.lblRefShow.Text = "- None Selected -";
            // 
            // cmdSelectReference
            // 
            this.cmdSelectReference.Location = new System.Drawing.Point(172, 4);
            this.cmdSelectReference.Name = "cmdSelectReference";
            this.cmdSelectReference.Size = new System.Drawing.Size(101, 23);
            this.cmdSelectReference.TabIndex = 2;
            this.cmdSelectReference.Text = "Select Reference";
            this.cmdSelectReference.UseVisualStyleBackColor = true;
            this.cmdSelectReference.Click += new System.EventHandler(this.cmdSelectReference_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Show to adapt";
            // 
            // cmdOpenShow
            // 
            this.cmdOpenShow.Location = new System.Drawing.Point(172, 34);
            this.cmdOpenShow.Name = "cmdOpenShow";
            this.cmdOpenShow.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenShow.TabIndex = 4;
            this.cmdOpenShow.Text = "Open Show";
            this.cmdOpenShow.UseVisualStyleBackColor = true;
            this.cmdOpenShow.Click += new System.EventHandler(this.cmdOpenShow_Click);
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.Location = new System.Drawing.Point(279, 39);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(93, 13);
            this.lblShowName.TabIndex = 5;
            this.lblShowName.Text = "- None Selected - ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "filenotfound.png");
            this.imageList1.Images.SetKeyName(1, "filefound.png");
            // 
            // tabAssets
            // 
            this.tabAssets.Controls.Add(this.lblAssetLocation);
            this.tabAssets.Controls.Add(this.linkAssetLocation);
            this.tabAssets.Controls.Add(this.cmdFindAssetFiles);
            this.tabAssets.Controls.Add(this.cmdExportShowSAF);
            this.tabAssets.Controls.Add(this.listShowAssets);
            this.tabAssets.Controls.Add(this.chkCopyAssets);
            this.tabAssets.Controls.Add(this.chkRemapAssets);
            this.tabAssets.Controls.Add(this.label4);
            this.tabAssets.Location = new System.Drawing.Point(4, 22);
            this.tabAssets.Name = "tabAssets";
            this.tabAssets.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssets.Size = new System.Drawing.Size(923, 589);
            this.tabAssets.TabIndex = 1;
            this.tabAssets.Text = "Show Asset Files";
            this.tabAssets.UseVisualStyleBackColor = true;
            // 
            // cmdFindAssetFiles
            // 
            this.cmdFindAssetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFindAssetFiles.Location = new System.Drawing.Point(564, 535);
            this.cmdFindAssetFiles.Name = "cmdFindAssetFiles";
            this.cmdFindAssetFiles.Size = new System.Drawing.Size(123, 23);
            this.cmdFindAssetFiles.TabIndex = 18;
            this.cmdFindAssetFiles.Text = "Search for files";
            this.cmdFindAssetFiles.UseVisualStyleBackColor = true;
            this.cmdFindAssetFiles.Click += new System.EventHandler(this.cmdFindAssetFiles_Click);
            // 
            // cmdExportShowSAF
            // 
            this.cmdExportShowSAF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExportShowSAF.Location = new System.Drawing.Point(842, 560);
            this.cmdExportShowSAF.Name = "cmdExportShowSAF";
            this.cmdExportShowSAF.Size = new System.Drawing.Size(75, 23);
            this.cmdExportShowSAF.TabIndex = 7;
            this.cmdExportShowSAF.Text = "Export Show";
            this.cmdExportShowSAF.UseVisualStyleBackColor = true;
            this.cmdExportShowSAF.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // listShowAssets
            // 
            this.listShowAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listShowAssets.ImageIndex = 0;
            this.listShowAssets.ImageList = this.imageList1;
            this.listShowAssets.Location = new System.Drawing.Point(6, 19);
            this.listShowAssets.Name = "listShowAssets";
            this.listShowAssets.SelectedImageIndex = 0;
            this.listShowAssets.Size = new System.Drawing.Size(911, 510);
            this.listShowAssets.TabIndex = 17;
            // 
            // chkCopyAssets
            // 
            this.chkCopyAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCopyAssets.AutoSize = true;
            this.chkCopyAssets.Checked = true;
            this.chkCopyAssets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAssets.Location = new System.Drawing.Point(693, 539);
            this.chkCopyAssets.Name = "chkCopyAssets";
            this.chkCopyAssets.Size = new System.Drawing.Size(225, 17);
            this.chkCopyAssets.TabIndex = 16;
            this.chkCopyAssets.Text = "Copy assets that were found (green icon)?";
            this.chkCopyAssets.UseVisualStyleBackColor = true;
            // 
            // chkRemapAssets
            // 
            this.chkRemapAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRemapAssets.AutoSize = true;
            this.chkRemapAssets.Checked = true;
            this.chkRemapAssets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemapAssets.Location = new System.Drawing.Point(10, 539);
            this.chkRemapAssets.Name = "chkRemapAssets";
            this.chkRemapAssets.Size = new System.Drawing.Size(163, 17);
            this.chkRemapAssets.TabIndex = 14;
            this.chkRemapAssets.Text = "Remap assets during export?";
            this.chkRemapAssets.UseVisualStyleBackColor = true;
            this.chkRemapAssets.CheckedChanged += new System.EventHandler(this.chkRemapAssets_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Show Asset Files:";
            // 
            // tabLayout
            // 
            this.tabLayout.Controls.Add(this.chkShowMapToSubs);
            this.tabLayout.Controls.Add(this.chkHideNoEffects);
            this.tabLayout.Controls.Add(this.cmdExportShowLM);
            this.tabLayout.Controls.Add(this.dgvModels);
            this.tabLayout.Location = new System.Drawing.Point(4, 22);
            this.tabLayout.Name = "tabLayout";
            this.tabLayout.Padding = new System.Windows.Forms.Padding(3);
            this.tabLayout.Size = new System.Drawing.Size(923, 589);
            this.tabLayout.TabIndex = 0;
            this.tabLayout.Text = "Layout Mapping";
            this.tabLayout.UseVisualStyleBackColor = true;
            // 
            // chkShowMapToSubs
            // 
            this.chkShowMapToSubs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMapToSubs.AutoSize = true;
            this.chkShowMapToSubs.Location = new System.Drawing.Point(656, 564);
            this.chkShowMapToSubs.Name = "chkShowMapToSubs";
            this.chkShowMapToSubs.Size = new System.Drawing.Size(170, 17);
            this.chkShowMapToSubs.TabIndex = 10;
            this.chkShowMapToSubs.Text = "Show submodels in map to list.";
            this.chkShowMapToSubs.UseVisualStyleBackColor = true;
            this.chkShowMapToSubs.CheckedChanged += new System.EventHandler(this.chkShowMapToSubs_CheckedChanged);
            // 
            // chkHideNoEffects
            // 
            this.chkHideNoEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHideNoEffects.AutoSize = true;
            this.chkHideNoEffects.Location = new System.Drawing.Point(6, 564);
            this.chkHideNoEffects.Name = "chkHideNoEffects";
            this.chkHideNoEffects.Size = new System.Drawing.Size(159, 17);
            this.chkHideNoEffects.TabIndex = 9;
            this.chkHideNoEffects.Text = "Hide models with no effects.";
            this.chkHideNoEffects.UseVisualStyleBackColor = true;
            this.chkHideNoEffects.CheckedChanged += new System.EventHandler(this.chkHideNoEffects_CheckedChanged);
            // 
            // cmdExportShowLM
            // 
            this.cmdExportShowLM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExportShowLM.Location = new System.Drawing.Point(842, 560);
            this.cmdExportShowLM.Name = "cmdExportShowLM";
            this.cmdExportShowLM.Size = new System.Drawing.Size(75, 23);
            this.cmdExportShowLM.TabIndex = 8;
            this.cmdExportShowLM.Text = "Export Show";
            this.cmdExportShowLM.UseVisualStyleBackColor = true;
            this.cmdExportShowLM.Click += new System.EventHandler(this.cmdExportShowLM_Click);
            // 
            // dgvModels
            // 
            this.dgvModels.AllowUserToAddRows = false;
            this.dgvModels.AllowUserToDeleteRows = false;
            this.dgvModels.AllowUserToResizeRows = false;
            this.dgvModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShowModel,
            this.colModelFXLayers,
            this.colModelFXCount,
            this.colModelFXDuration,
            this.colModelFX,
            this.colMapTo});
            this.dgvModels.Location = new System.Drawing.Point(3, 3);
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.RowHeadersVisible = false;
            this.dgvModels.Size = new System.Drawing.Size(914, 551);
            this.dgvModels.TabIndex = 6;
            // 
            // colShowModel
            // 
            this.colShowModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShowModel.FillWeight = 25F;
            this.colShowModel.HeaderText = "Show Models";
            this.colShowModel.Name = "colShowModel";
            // 
            // colModelFXLayers
            // 
            this.colModelFXLayers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelFXLayers.FillWeight = 10F;
            this.colModelFXLayers.HeaderText = "Layers";
            this.colModelFXLayers.Name = "colModelFXLayers";
            // 
            // colModelFXCount
            // 
            this.colModelFXCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelFXCount.FillWeight = 10F;
            this.colModelFXCount.HeaderText = "Effect Count";
            this.colModelFXCount.Name = "colModelFXCount";
            // 
            // colModelFXDuration
            // 
            this.colModelFXDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelFXDuration.FillWeight = 15F;
            this.colModelFXDuration.HeaderText = "Effect Duration";
            this.colModelFXDuration.Name = "colModelFXDuration";
            // 
            // colModelFX
            // 
            this.colModelFX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelFX.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colModelFX.FillWeight = 25F;
            this.colModelFX.HeaderText = "Model Effects";
            this.colModelFX.Name = "colModelFX";
            // 
            // colMapTo
            // 
            this.colMapTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMapTo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colMapTo.FillWeight = 25F;
            this.colMapTo.HeaderText = "Map To";
            this.colMapTo.Name = "colMapTo";
            this.colMapTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMapTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLayout);
            this.tabControl1.Controls.Add(this.tabAssets);
            this.tabControl1.Location = new System.Drawing.Point(12, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 615);
            this.tabControl1.TabIndex = 12;
            // 
            // linkAssetLocation
            // 
            this.linkAssetLocation.AutoSize = true;
            this.linkAssetLocation.Location = new System.Drawing.Point(33, 560);
            this.linkAssetLocation.Name = "linkAssetLocation";
            this.linkAssetLocation.Size = new System.Drawing.Size(145, 13);
            this.linkAssetLocation.TabIndex = 19;
            this.linkAssetLocation.TabStop = true;
            this.linkAssetLocation.Text = "Copy assets to new folder in: ";
            this.linkAssetLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAssetLocation_LinkClicked);
            // 
            // lblAssetLocation
            // 
            this.lblAssetLocation.AutoSize = true;
            this.lblAssetLocation.Location = new System.Drawing.Point(185, 560);
            this.lblAssetLocation.Name = "lblAssetLocation";
            this.lblAssetLocation.Size = new System.Drawing.Size(83, 13);
            this.lblAssetLocation.TabIndex = 20;
            this.lblAssetLocation.Text = "[Asset Location]";
            // 
            // frmAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 682);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblShowName);
            this.Controls.Add(this.cmdOpenShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSelectReference);
            this.Controls.Add(this.lblRefShow);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(795, 370);
            this.Name = "frmAdapter";
            this.Text = "xLights Show Adapter";
            this.tabAssets.ResumeLayout(false);
            this.tabAssets.PerformLayout();
            this.tabLayout.ResumeLayout(false);
            this.tabLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog diagOpenFile;
        private System.Windows.Forms.FolderBrowserDialog diagFolderBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRefShow;
        private System.Windows.Forms.Button cmdSelectReference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdOpenShow;
        private System.Windows.Forms.Label lblShowName;
        private System.Windows.Forms.SaveFileDialog diagSaveFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabAssets;
        private System.Windows.Forms.Button cmdFindAssetFiles;
        private System.Windows.Forms.Button cmdExportShowSAF;
        private System.Windows.Forms.TreeView listShowAssets;
        private System.Windows.Forms.CheckBox chkCopyAssets;
        private System.Windows.Forms.CheckBox chkRemapAssets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabLayout;
        private System.Windows.Forms.CheckBox chkShowMapToSubs;
        private System.Windows.Forms.CheckBox chkHideNoEffects;
        private System.Windows.Forms.Button cmdExportShowLM;
        private System.Windows.Forms.DataGridView dgvModels;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelFXLayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelFXCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelFXDuration;
        private System.Windows.Forms.DataGridViewComboBoxColumn colModelFX;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMapTo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lblAssetLocation;
        private System.Windows.Forms.LinkLabel linkAssetLocation;
    }
}

