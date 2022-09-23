using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        private void lORToyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAppWindow(new frmLORToy());
        }

        private void lORMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose converted show to consolidate RGB channels to xLights models.";
            fileDialog.Filter = "Sequence files (*.xml, *.xsq) | *.xml; *.xsq|All files (*.*) | *.*";
            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.Cancel)
                return;

            string LORBasedShow = fileDialog.FileName;

            // first replace the palet with mine:
            /*
                  <ColorPalettes>
                    <ColorPalette>C_BUTTON_Palette1=#ffffff,C_BUTTON_Palette2=#000000,C_CHECKBOX_Palette1=1,C_CHECKBOX_Palette2=0</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette1=1</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette5=1</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#000000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette1=1</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette2=1</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette3=1</ColorPalette>
                    <ColorPalette>C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette4=1</ColorPalette>
                  </ColorPalettes>
             */

            // need to move the RGB models into the main models as layers:
            // MiniTree-1 (thru 9) gets <EffectLayer> from W Yard 1 (thru 9) (color White = palette 1) + Y Yard 1 (thru 9) (color Yellow = palette 2) + Yard A 1 (thru 9) (color Red = palette 4) + Yard B 1 (thru 9) (color Green = palette 5)
            // Pixel Pole Left 1 (thru 5 and Rights) gets layers from Pixel Pole Left-1R, Pixel Pole Left-1G, Pixel Pole Left-1B (with colors) (blue is palette 6)
            // Pixel Star Left Inner, Mid, Outer, and Rights get layers from Pixel Star Left Inner-R(GB) (with colors)

            XElement doc = XElement.Load(LORBasedShow);

            // lets see if xlights will magically handle just updating each from model to the to model (and not creating layers) - lets see what happens
            List<string[]> instructions = new List<string[]>();
            
            //                             From;      To;          Palette ID
            instructions.Add(new string[] { "W Yard 1", "MiniTree-1", "1" });
            instructions.Add(new string[] { "W Yard 2", "MiniTree-2", "1" });
            instructions.Add(new string[] { "W Yard 3", "MiniTree-3", "1" });
            instructions.Add(new string[] { "W Yard 4", "MiniTree-4", "1" });
            instructions.Add(new string[] { "W Yard 5", "MiniTree-5", "1" });
            instructions.Add(new string[] { "W Yard 6", "MiniTree-6", "1" });
            instructions.Add(new string[] { "W Yard 7", "MiniTree-7", "1" });
            instructions.Add(new string[] { "W Yard 8", "MiniTree-8", "1" });
            instructions.Add(new string[] { "W Yard 9", "MiniTree-9", "1" });
            instructions.Add(new string[] { "Y Yard 1", "MiniTree-1", "2" });
            instructions.Add(new string[] { "Y Yard 2", "MiniTree-2", "2" });
            instructions.Add(new string[] { "Y Yard 3", "MiniTree-3", "2" });
            instructions.Add(new string[] { "Y Yard 4", "MiniTree-4", "2" });
            instructions.Add(new string[] { "Y Yard 5", "MiniTree-5", "2" });
            instructions.Add(new string[] { "Y Yard 6", "MiniTree-6", "2" });
            instructions.Add(new string[] { "Y Yard 7", "MiniTree-7", "2" });
            instructions.Add(new string[] { "Y Yard 8", "MiniTree-8", "2" });
            instructions.Add(new string[] { "Y Yard 9", "MiniTree-9", "2" });
            instructions.Add(new string[] { "Yard A 1", "MiniTree-1", "4" });
            instructions.Add(new string[] { "Yard A 2", "MiniTree-2", "4" });
            instructions.Add(new string[] { "Yard A 3", "MiniTree-3", "4" });
            instructions.Add(new string[] { "Yard A 4", "MiniTree-4", "4" });
            instructions.Add(new string[] { "Yard A 5", "MiniTree-5", "4" });
            instructions.Add(new string[] { "Yard A 6", "MiniTree-6", "4" });
            instructions.Add(new string[] { "Yard A 7", "MiniTree-7", "4" });
            instructions.Add(new string[] { "Yard A 8", "MiniTree-8", "4" });
            instructions.Add(new string[] { "Yard A 9", "MiniTree-9", "4" });
            instructions.Add(new string[] { "Yard B 1", "MiniTree-1", "5" });
            instructions.Add(new string[] { "Yard B 2", "MiniTree-2", "5" });
            instructions.Add(new string[] { "Yard B 3", "MiniTree-3", "5" });
            instructions.Add(new string[] { "Yard B 4", "MiniTree-4", "5" });
            instructions.Add(new string[] { "Yard B 5", "MiniTree-5", "5" });
            instructions.Add(new string[] { "Yard B 6", "MiniTree-6", "5" });
            instructions.Add(new string[] { "Yard B 7", "MiniTree-7", "5" });
            instructions.Add(new string[] { "Yard B 8", "MiniTree-8", "5" });
            instructions.Add(new string[] { "Yard B 9", "MiniTree-9", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-1R", "Pixel Pole Left-1", "4" });
            instructions.Add(new string[] { "Pixel Pole Left-1G", "Pixel Pole Left-1", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-1B", "Pixel Pole Left-1", "6" });
            instructions.Add(new string[] { "Pixel Pole Left-2R", "Pixel Pole Left-2", "4" });
            instructions.Add(new string[] { "Pixel Pole Left-2G", "Pixel Pole Left-2", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-2B", "Pixel Pole Left-2", "6" });
            instructions.Add(new string[] { "Pixel Pole Left-3R", "Pixel Pole Left-3", "4" });
            instructions.Add(new string[] { "Pixel Pole Left-3G", "Pixel Pole Left-3", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-3B", "Pixel Pole Left-3", "6" });
            instructions.Add(new string[] { "Pixel Pole Left-4R", "Pixel Pole Left-4", "4" });
            instructions.Add(new string[] { "Pixel Pole Left-4G", "Pixel Pole Left-4", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-4B", "Pixel Pole Left-4", "6" });
            instructions.Add(new string[] { "Pixel Pole Left-5R", "Pixel Pole Left-5", "4" });
            instructions.Add(new string[] { "Pixel Pole Left-5G", "Pixel Pole Left-5", "5" });
            instructions.Add(new string[] { "Pixel Pole Left-5B", "Pixel Pole Left-5", "6" });
            instructions.Add(new string[] { "Pixel Pole Right-1R", "Pixel Pole Right-1", "4" });
            instructions.Add(new string[] { "Pixel Pole Right-1G", "Pixel Pole Right-1", "5" });
            instructions.Add(new string[] { "Pixel Pole Right-1B", "Pixel Pole Right-1", "6" });
            instructions.Add(new string[] { "Pixel Pole Right-2R", "Pixel Pole Right-2", "4" });
            instructions.Add(new string[] { "Pixel Pole Right-2G", "Pixel Pole Right-2", "5" });
            instructions.Add(new string[] { "Pixel Pole Right-2B", "Pixel Pole Right-2", "6" });
            instructions.Add(new string[] { "Pixel Pole Right-3R", "Pixel Pole Right-3", "4" });
            instructions.Add(new string[] { "Pixel Pole Right-3G", "Pixel Pole Right-3", "5" });
            instructions.Add(new string[] { "Pixel Pole Right-3B", "Pixel Pole Right-3", "6" });
            instructions.Add(new string[] { "Pixel Pole Right-4R", "Pixel Pole Right-4", "4" });
            instructions.Add(new string[] { "Pixel Pole Right-4G", "Pixel Pole Right-4", "5" });
            instructions.Add(new string[] { "Pixel Pole Right-4B", "Pixel Pole Right-4", "6" });
            instructions.Add(new string[] { "Pixel Pole Right-5R", "Pixel Pole Right-5", "4" });
            instructions.Add(new string[] { "Pixel Pole Right-5G", "Pixel Pole Right-5", "5" });
            instructions.Add(new string[] { "Pixel Pole Right-5B", "Pixel Pole Right-5", "6" });

            instructions.Add(new string[] { "Pixel Star Left Inner-R", "Pixel Star Left Inner", "4" });
            instructions.Add(new string[] { "Pixel Star Left Inner-G", "Pixel Star Left Inner", "5" });
            instructions.Add(new string[] { "Pixel Star Left Inner-B", "Pixel Star Left Inner", "6" });
            instructions.Add(new string[] { "Pixel Star Left Mid-R", "Pixel Star Left Mid", "4" });
            instructions.Add(new string[] { "Pixel Star Left Mid-G", "Pixel Star Left Mid", "5" });
            instructions.Add(new string[] { "Pixel Star Left Mid-B", "Pixel Star Left Mid", "6" });
            instructions.Add(new string[] { "Pixel Star Left Outer-R", "Pixel Star Left Outer", "4" });
            instructions.Add(new string[] { "Pixel Star Left Outer-G", "Pixel Star Left Outer", "5" });
            instructions.Add(new string[] { "Pixel Star Left Outer-B", "Pixel Star Left Outer", "6" });

            instructions.Add(new string[] { "Pixel Star Right Inner-R", "Pixel Star Right Inner", "4" });
            instructions.Add(new string[] { "Pixel Star Right Inner-G", "Pixel Star Right Inner", "5" });
            instructions.Add(new string[] { "Pixel Star Right Inner-B", "Pixel Star Right Inner", "6" });
            instructions.Add(new string[] { "Pixel Star Right Mid-R", "Pixel Star Right Mid", "4" });
            instructions.Add(new string[] { "Pixel Star Right Mid-G", "Pixel Star Right Mid", "5" });
            instructions.Add(new string[] { "Pixel Star Right Mid-B", "Pixel Star Right Mid", "6" });
            instructions.Add(new string[] { "Pixel Star Right Outer-R", "Pixel Star Right Outer", "4" });
            instructions.Add(new string[] { "Pixel Star Right Outer-G", "Pixel Star Right Outer", "5" });
            instructions.Add(new string[] { "Pixel Star Right Outer-B", "Pixel Star Right Outer", "6" });

            var palettes = from p in doc.Element("ColorPalettes").Elements("ColorPalette") select p;
            palettes.Remove();

            doc.Element("ColorPalettes").Add(new XComment("ColorPalettes replaced."));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#ffffff,C_BUTTON_Palette2=#000000,C_CHECKBOX_Palette1=1,C_CHECKBOX_Palette2=0"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette1=1"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette5=1"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#000000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette1=1"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette2=1"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette3=1"));
            doc.Element("ColorPalettes").Add(new XElement("ColorPalette", "C_BUTTON_Palette1=#FFFFFF,C_BUTTON_Palette2=#FF0000,C_BUTTON_Palette3=#00FF00,C_BUTTON_Palette4=#0000FF,C_BUTTON_Palette5=#FFFF00,C_BUTTON_Palette6=#000000,C_BUTTON_Palette7=#00FFFF,C_BUTTON_Palette8=#FF00FF,C_CHECKBOX_Palette4=1"));

            IEnumerable<XElement> fx;
            IEnumerable<XElement> models;
            foreach (string[] instruction in instructions)
            {
                models = from model in doc.Element("ElementEffects").Elements("Element")
                      where (string)model.Attribute("name") == instruction[0]
                      select model;

                foreach (var model in models)
                {
                    model.SetAttributeValue("name", instruction[1]);

                    fx = from effects in model.Element("EffectLayer").Elements("Effect")
                         select effects;

                    foreach (var f in fx)
                        f.SetAttributeValue("palette", instruction[2]);

                }
            }

            doc.Save(Path.Combine(Path.GetDirectoryName(LORBasedShow),$"{Path.GetFileNameWithoutExtension(LORBasedShow)}-updated.{Path.GetExtension(LORBasedShow)}"));

            MessageBox.Show("Done.");
        }
    }
}
