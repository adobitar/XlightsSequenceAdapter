using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XlightsSequenceAdapter
{
    public partial class frmMain : Form
    {
        frmSettings winSettings;
        frmHelp winHelp;
        ObservableCollection<Form> appWindows;

        public frmMain()
        {
            InitializeComponent();

#if DEBUG
            imageBrowserToolStripMenuItem.Visible = true;
#endif

            appWindows = new ObservableCollection<Form>();
            appWindows.CollectionChanged += AppWindows_CollectionChanged;

            menuStrip1.MouseMove += RecaptureFocus;
            toolStrip1.MouseMove += RecaptureFocus;

            foreach (ToolStripItem i in toolStrip1.Items)
                i.MouseMove += RecaptureFocus;
        }

        private void RecaptureFocus(object sender, EventArgs e)
        {
            if (!this.Focused)
                this.Activate();
        }

        private void AppWindows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            windowsToolStripMenuItem.DropDownItems.Clear();

            if (appWindows.Count <= 0)
            {
                windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nothingCurrentlyOpenToolStripMenuItem });
                return;
            }

            ToolStripMenuItem[] items = new ToolStripMenuItem[appWindows.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Text = appWindows[i].Text;
                items[i].Tag = i;
                items[i].Click += WindowsMenuClick;
            }

            windowsToolStripMenuItem.DropDownItems.AddRange(items);
        }

        private void WindowsMenuClick(object sender, EventArgs e)
        {
            Form appWin = appWindows[(int)((ToolStripMenuItem)sender).Tag];

            if (appWin.Visible)
                appWin.Activate();
            else
                appWin.Show(this);
        }

        private void newAppWindow(Form appWindow)
        {
            if (appWindow.Visible)
            { 
                appWindow.Activate();
                return;
            }
            
            appWindow.FormClosing += appWinClosing;
            appWindows.Add(appWindow);

            appWindow.StartPosition = FormStartPosition.Manual;
            appWindow.Top = this.Top + this.Height + appWindows.Count * 10 - 10;
            appWindow.Left = this.Left + appWindows.Count * 10 - 10;

            appWindow.Show(this);
        }

        private void appWinClosing(object sender, FormClosingEventArgs e)
        {
            appWindows.Remove(sender as Form);
        }

        private void newBrowser(object sender, EventArgs e)
        {
            frmBrowser b = new frmBrowser();
            b.TextChanged += appWindowTextChanged;
            newAppWindow(b);
        }

        private void appWindowTextChanged(object sender, EventArgs e)
        {
            AppWindows_CollectionChanged(sender, null);
        }

        private void newAdapter(object sender, EventArgs e)
        {
            newAppWindow(new frmAdapter());
        }

        private void newHelp(object sender, EventArgs e)
        {
            if ((winHelp == null) || (winHelp.IsDisposed))
                winHelp = new frmHelp();

            newAppWindow(winHelp);
        }

        private void sharedFilesBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newBrowser(sender, e);
        }

        private void tsBrowse_Click(object sender, EventArgs e)
        {
            newBrowser(sender, e);
        }

        private void tsAdapt_Click(object sender, EventArgs e)
        {
            newAdapter(sender, e);
        }

        private void sequenceAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAdapter(sender, e);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((winSettings == null) || (winSettings.IsDisposed))
                winSettings = new frmSettings();

            newAppWindow(winSettings);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newHelp(sender, e);   
        }

        private void tsHelp_Click(object sender, EventArgs e)
        {
            newHelp(sender, e);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Settings.AlwaysOpenBrowserOnLoad)
                newBrowser(sender, e);
        }

        private void imageBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAppWindow(new frmVSImageBrowser());
        }
    }
}
