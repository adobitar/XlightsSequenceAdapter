
namespace XlightsSequenceAdapter
{
    partial class xSEQRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvXLADetails = new System.Windows.Forms.DataGridView();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShareSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtxtNotes = new System.Windows.Forms.RichTextBox();
            this.dgvSeqMeta = new System.Windows.Forms.DataGridView();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthorEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAuthorWebsite = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colComment = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSequenceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqTiming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMediaFile = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMusicURL = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXLADetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeqMeta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvXLADetails
            // 
            this.dgvXLADetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvXLADetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXLADetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colVideoURL,
            this.colShareSource,
            this.colSourceURL});
            this.dgvXLADetails.Location = new System.Drawing.Point(0, 73);
            this.dgvXLADetails.Name = "dgvXLADetails";
            this.dgvXLADetails.Size = new System.Drawing.Size(603, 64);
            this.dgvXLADetails.TabIndex = 0;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            // 
            // colVideoURL
            // 
            this.colVideoURL.HeaderText = "Video";
            this.colVideoURL.Name = "colVideoURL";
            // 
            // colShareSource
            // 
            this.colShareSource.HeaderText = "Source";
            this.colShareSource.Name = "colShareSource";
            // 
            // colSourceURL
            // 
            this.colSourceURL.HeaderText = "SourceURL";
            this.colSourceURL.Name = "colSourceURL";
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNotes.Location = new System.Drawing.Point(609, 71);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(427, 66);
            this.rtxtNotes.TabIndex = 1;
            this.rtxtNotes.Text = "";
            // 
            // dgvSeqMeta
            // 
            this.dgvSeqMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeqMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeqMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuthor,
            this.colAuthorEmail,
            this.colAuthorWebsite,
            this.colComment,
            this.colSequenceType,
            this.colSeqTiming,
            this.colSeqDuration,
            this.colArtist,
            this.colAlbum,
            this.colSong,
            this.colMediaFile,
            this.colMusicURL});
            this.dgvSeqMeta.Location = new System.Drawing.Point(0, 3);
            this.dgvSeqMeta.Name = "dgvSeqMeta";
            this.dgvSeqMeta.ReadOnly = true;
            this.dgvSeqMeta.Size = new System.Drawing.Size(1036, 64);
            this.dgvSeqMeta.TabIndex = 2;
            // 
            // colAuthor
            // 
            this.colAuthor.HeaderText = "Author";
            this.colAuthor.Name = "colAuthor";
            // 
            // colAuthorEmail
            // 
            this.colAuthorEmail.HeaderText = "Email";
            this.colAuthorEmail.Name = "colAuthorEmail";
            this.colAuthorEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAuthorEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colAuthorWebsite
            // 
            this.colAuthorWebsite.HeaderText = "Website";
            this.colAuthorWebsite.Name = "colAuthorWebsite";
            this.colAuthorWebsite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAuthorWebsite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colComment
            // 
            this.colComment.HeaderText = "Comment";
            this.colComment.Name = "colComment";
            // 
            // colSequenceType
            // 
            this.colSequenceType.HeaderText = "Type";
            this.colSequenceType.Name = "colSequenceType";
            this.colSequenceType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSequenceType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSeqTiming
            // 
            this.colSeqTiming.HeaderText = "Timing";
            this.colSeqTiming.Name = "colSeqTiming";
            // 
            // colSeqDuration
            // 
            this.colSeqDuration.HeaderText = "Duration";
            this.colSeqDuration.Name = "colSeqDuration";
            // 
            // colArtist
            // 
            this.colArtist.HeaderText = "Artist";
            this.colArtist.Name = "colArtist";
            // 
            // colAlbum
            // 
            this.colAlbum.HeaderText = "Album";
            this.colAlbum.Name = "colAlbum";
            // 
            // colSong
            // 
            this.colSong.HeaderText = "Song";
            this.colSong.Name = "colSong";
            // 
            // colMediaFile
            // 
            this.colMediaFile.HeaderText = "Media";
            this.colMediaFile.Name = "colMediaFile";
            // 
            // colMusicURL
            // 
            this.colMusicURL.HeaderText = "MusicURL";
            this.colMusicURL.Name = "colMusicURL";
            // 
            // xSEQRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSeqMeta);
            this.Controls.Add(this.rtxtNotes);
            this.Controls.Add(this.dgvXLADetails);
            this.Name = "xSEQRow";
            this.Size = new System.Drawing.Size(1042, 140);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXLADetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeqMeta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXLADetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShareSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceURL;
        private System.Windows.Forms.RichTextBox rtxtNotes;
        private System.Windows.Forms.DataGridView dgvSeqMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewLinkColumn colAuthorEmail;
        private System.Windows.Forms.DataGridViewLinkColumn colAuthorWebsite;
        private System.Windows.Forms.DataGridViewImageColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequenceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqTiming;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSong;
        private System.Windows.Forms.DataGridViewImageColumn colMediaFile;
        private System.Windows.Forms.DataGridViewLinkColumn colMusicURL;
    }
}
