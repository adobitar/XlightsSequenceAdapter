using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XlightsSequenceAdapter
{
    public partial class frmVSImageBrowser : Form
    {
        public frmVSImageBrowser()
        {
            InitializeComponent();
        }

        private void frmVSImageBrowser_Load(object sender, EventArgs e)
        {
        }

        private void lnkImgPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(txtLibraryPath.Text))
                diagFolderBrowser.SelectedPath = txtLibraryPath.Text;

            diagFolderBrowser.ShowDialog();
            txtLibraryPath.Text = diagFolderBrowser.SelectedPath;
            Settings.vsimglibpath = diagFolderBrowser.SelectedPath;
        }

        private async void cmdDisplayImages_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtLibraryPath.Text))
            {
                MessageBox.Show(this, "Please check image path and try again.", "Invalid Path...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> Images = getImages(txtLibraryPath.Text);

            if ((Images == null) || (Images.Count <= 0))
            {
                MessageBox.Show(this, "No images found for selected root path.", "No results...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progBar.Minimum = 0;
            progBar.Maximum = Images.Count();
            progBar.Value = 0;
            progBar.Visible = true;

            //imageDisplayInvoker(Images);
            var progress = new Progress<int>(s => progBar.Value = s);
            await Task.Factory.StartNew(() => displayImages(Images, progress),
                                        TaskCreationOptions.LongRunning);

            progBar.Visible = false;
        }

        private List<string> getImages(string path)
        {
            var images = Directory.EnumerateFiles(path, "*.png", SearchOption.AllDirectories);

            return images.ToList<string>();
        }

        private void displayImages(List<string> allImgs, IProgress<int> progress)
        {
            int i = 0;
            foreach (string filename in allImgs)
            {
                progress.Report(++i);

                pnlFlow.Invoke((MethodInvoker)delegate {
                    Button btn = new Button
                    {
                        Parent = pnlFlow,
                        Image = new Bitmap(filename),
                        Size = new Size(32, 32)
                    };

                    FileInfo file_info = new FileInfo(filename);
                    toolTip.SetToolTip(btn, file_info.Name);
                });
            }
        }
    }
}
