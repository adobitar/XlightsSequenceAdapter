
namespace XlightsSequenceAdapter
{
    partial class frmHelp
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
            this.rtfHelp = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtfHelp
            // 
            this.rtfHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfHelp.Location = new System.Drawing.Point(0, 0);
            this.rtfHelp.Name = "rtfHelp";
            this.rtfHelp.ReadOnly = true;
            this.rtfHelp.Size = new System.Drawing.Size(800, 450);
            this.rtfHelp.TabIndex = 11;
            this.rtfHelp.Text = "";
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtfHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHelp";
            this.Text = "xLights Sequence Adapter Help...";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfHelp;
    }
}