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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Settings.layoutPath))
                lblRefShow.Text = Settings.layoutPath;
            else
                lblRefShow.Text = Settings.NOSELECTION;

            if (Directory.Exists(Settings.sharedPath))
                lblPIZPath.Text = Settings.sharedPath;
            else
                lblPIZPath.Text = Settings.NOSELECTION;

            chkOpenBrowser.Checked = Settings.AlwaysOpenBrowserOnLoad;
        }

        private void chkOpenBrowser_CheckedChanged(object sender, EventArgs e)
        {
            Settings.AlwaysOpenBrowserOnLoad = chkOpenBrowser.Checked;
        }

        private void cmdSelectShowPath_Click(object sender, EventArgs e)
        {
            string layoutPath = Settings.layoutPath;
            if (Directory.Exists(layoutPath))
                diagFolderBrowser.SelectedPath = layoutPath;

            DialogResult res = diagFolderBrowser.ShowDialog();
            if (res == DialogResult.Cancel)
                return;

            layoutPath = diagFolderBrowser.SelectedPath;
            if (!File.Exists(Path.Combine(layoutPath, Settings.LAYOUTFILE)))
            {
                MessageBox.Show("Could not find xlights_rgbeffects.xml file in selected location.  Please try again.", "Could not find xlights layout file", MessageBoxButtons.OK);
                return;
            }

            Settings.layoutPath = layoutPath;
            lblRefShow.Text = layoutPath;
        }

        private void cmdSelectPIZPath_Click(object sender, EventArgs e)
        {
            string sharepath = Settings.sharedPath;
            if (Directory.Exists(sharepath))
                diagFolderBrowser.SelectedPath = sharepath;

            DialogResult r = diagFolderBrowser.ShowDialog();
            if (r == DialogResult.Cancel)
                return;

            Settings.sharedPath = diagFolderBrowser.SelectedPath;
            lblPIZPath.Text = diagFolderBrowser.SelectedPath;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
