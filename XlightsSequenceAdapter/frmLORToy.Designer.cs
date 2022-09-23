namespace XlightsSequenceAdapter
{
    partial class frmLORToy
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
            this.listBoxFoundSeqs = new System.Windows.Forms.ListBox();
            this.txtProps = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxFoundSeqs
            // 
            this.listBoxFoundSeqs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFoundSeqs.FormattingEnabled = true;
            this.listBoxFoundSeqs.ItemHeight = 16;
            this.listBoxFoundSeqs.Location = new System.Drawing.Point(12, 12);
            this.listBoxFoundSeqs.Name = "listBoxFoundSeqs";
            this.listBoxFoundSeqs.Size = new System.Drawing.Size(261, 260);
            this.listBoxFoundSeqs.TabIndex = 0;
            this.listBoxFoundSeqs.SelectedIndexChanged += new System.EventHandler(this.listBoxFoundSeqs_SelectedIndexChanged);
            // 
            // txtProps
            // 
            this.txtProps.AcceptsReturn = true;
            this.txtProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProps.Location = new System.Drawing.Point(279, 12);
            this.txtProps.Multiline = true;
            this.txtProps.Name = "txtProps";
            this.txtProps.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProps.Size = new System.Drawing.Size(304, 260);
            this.txtProps.TabIndex = 1;
            // 
            // frmLORToy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 287);
            this.Controls.Add(this.txtProps);
            this.Controls.Add(this.listBoxFoundSeqs);
            this.Name = "frmLORToy";
            this.Text = "frmLORToy";
            this.Load += new System.EventHandler(this.frmLORToy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFoundSeqs;
        private System.Windows.Forms.TextBox txtProps;
    }
}