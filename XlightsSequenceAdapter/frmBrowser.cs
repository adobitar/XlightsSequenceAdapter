using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XlightsSequenceAdapter
{
    public partial class frmBrowser : Form
    {
        private class PersonalizationStatus : INotifyPropertyChanged
        {
            public string _fullPath;
            public string _file;
            public string _folder;
            public string _status;

            [DisplayName("Full Path")]
            public string FullPath
            {
                get { return _fullPath; }

                set
                {
                    if (_fullPath != value)
                    {
                        _fullPath = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string File
            {
                get { return _file; }

                set
                {
                    if (_file != value)
                    {
                        _file = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string Folder
            {
                get { return _folder; }

                set
                {
                    if (_folder != value)
                    {
                        _folder = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string Status
            {
                get { return _status; }

                set
                {
                    if (_status != value)
                    {
                        _status = value;
                        OnPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public frmBrowser()
        {
            InitializeComponent();
            txtPizPath.Text = Settings.sharedPath;
            this.Text = "Shared Sequences Browser - " + txtPizPath.Text;
            toolTip.SetToolTip(txtPizPath, txtPizPath.Text);

            cmdPersonalize.Visible = false;
            cmdMoveFiles.Visible = false;

            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMain));
            this.Icon = Core.ToIcon((Image)resources.GetObject("tsBrowse.Image"));
        }

        private List<XSEQ> seqs;
        private BindingList<XSEQ> seqList;
        private async void cmdGetList_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtPizPath.Text))
            {
                MessageBox.Show(this, "Please check sequence path and try again.", "Invalid Path...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UseWaitCursor = true;

            // Just grab names and paths - very fast, show progress during meta capture which is longer running
            List<string> seqNames = Core.GetXSEQNames(txtPizPath.Text);

            UseWaitCursor = false;

            if ((seqNames == null) || (seqNames.Count <= 0))
            {
                MessageBox.Show(this, "No sequences found for selected root path.", "No results...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UseWaitCursor = true;

            progBar.Minimum = 0;
            progBar.Maximum = seqNames.Count();
            progBar.Value = 0;
            progBar.Visible = true;

            cmdMoveFiles.Visible = false;
            cmdPersonalize.Visible = true;

            var progress = new Progress<int>(p => progBar.Value = p);
            seqs = await Task.Factory.StartNew(() => Core.GetXSEQList(seqNames, progress), TaskCreationOptions.LongRunning);

            seqList = new BindingList<XSEQ>(seqs);
            BindingSource bindableSeqs = new BindingSource(seqList, null);
            dgvFileList.DataSource = bindableSeqs;

            progBar.Visible = false;

            dgvFileList.ReadOnly = false;

            dgvFileList.Columns["FileFullname"].Visible = false;
            dgvFileList.Columns["XLightsVersion"].Visible = false;
            dgvFileList.Columns["AuthorEmail"].Visible = false;
            dgvFileList.Columns["AuthorWebsite"].Visible = false;
            dgvFileList.Columns["AuthorComment"].Visible = false;
            dgvFileList.Columns["SequenceTiming"].Visible = false;
            dgvFileList.Columns["SequenceType"].Visible = false;
            dgvFileList.Columns["MediaFile"].Visible = false;
            dgvFileList.Columns["SequenceDuration"].Visible = false;
            dgvFileList.Columns["ImageDir"].Visible = false;
            dgvFileList.Columns["XLAFile"].Visible = false;
            dgvFileList.Columns["Artist"].Visible = false;
            dgvFileList.Columns["Album"].Visible = false;
            dgvFileList.Columns["MusicURL"].Visible = false;
            dgvFileList.Columns["ParseWarning"].Visible = false;
            //dgvFileList.Columns["ModelDisplayelements"].Visible = false;

            foreach (var prop in typeof(XSEQ).GetProperties())
            {
                if (prop.PropertyType != typeof(String))
                    continue;
                else if (prop.Name == "ParseWarning")
                    continue;

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = prop.Name;
                item.CheckOnClick = true;
                item.Click += ToggleColVisibilityOnItem_Click;

                switch (prop.Name)
                {
                    case "FileFullname":
                    case "XLightsVersion":
                    case "AuthorEmail":
                    case "AuthorWebsite":
                    case "AuthorComment":
                    case "SequenceTiming":
                    case "SequenceType":
                    case "MediaFile":
                    case "SequenceDuration":
                    case "ImageDir":
                    case "XLAFile":
                    case "Artist":
                    case "Album":
                    case "MusicURL":
                        item.Checked = false;
                        break;
                    default:
                        item.Checked = true;
                        break;
                }

                viewColsToolStripMenuItem.DropDownItems.Add(item);
            }

            foreach (DataGridViewColumn c in dgvFileList.Columns)
            { 
                c.ReadOnly = true;
                c.DefaultCellStyle.BackColor = SystemColors.Control;
            }

            dgvFileList.Columns["Category"].ReadOnly = false;
            dgvFileList.Columns["Category"].DefaultCellStyle.BackColor = Color.White;

            dgvFileList.Columns["Credit"].ReadOnly = false;
            dgvFileList.Columns["Credit"].DefaultCellStyle.BackColor = Color.White;

            dgvFileList.Columns["VideoURL"].ReadOnly = false;
            dgvFileList.Columns["VideoURL"].DefaultCellStyle.BackColor = Color.White;

            dgvFileList.Columns["ShareSource"].ReadOnly = false;
            dgvFileList.Columns["ShareSource"].DefaultCellStyle.BackColor = Color.White;

            dgvFileList.Columns["ShareURL"].ReadOnly = false;
            dgvFileList.Columns["ShareURL"].DefaultCellStyle.BackColor = Color.White;

            dgvFileList.Columns["Notes"].ReadOnly = false;
            dgvFileList.Columns["Notes"].DefaultCellStyle.BackColor = Color.White;

            cmdPersonalize.Visible = true;

            UseWaitCursor = false;
        }

        private void sortBy(Func<XSEQ, IComparable> getProp)
        {
            // call like sortBy(x => x.Property)
            seqs = seqs.OrderBy(x => getProp(x)).ToList();
        }

        private void sortBy(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(String))
            {
                seqs.Sort((x, y) => string.Compare((string)prop.GetValue(x), (string)prop.GetValue(y), true));
            }
        }

        private void searchBy(PropertyInfo prop, string query)
        {
            if (string.IsNullOrEmpty(query))
                return;

            UseWaitCursor = true;

            List<XSEQ> filteredseqs = new List<XSEQ>();
            List<XSEQ> filteredseqs2 = new List<XSEQ>();
            if (prop == null)
            {
                foreach (PropertyInfo p in typeof(XSEQ).GetProperties())
                {
                    if (p.PropertyType != typeof(String))
                        continue;

                    filteredseqs = filteredseqs.Union(seqs.Where(s => (p.GetValue(s) + "").ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList()).ToList();

                }
            }
            else
            {
                if (prop.PropertyType != typeof(String))
                    return;

                filteredseqs = seqs.Where(s => (prop.GetValue(s) + "").ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            showingSearchResults = true;
            picboxClearSearchResults.Visible = true;

            seqList = new BindingList<XSEQ>(filteredseqs);
            BindingSource bindableSeqs = new BindingSource(seqList, null);
            dgvFileList.DataSource = bindableSeqs;

            UseWaitCursor = false;
        }

        private void ToggleColVisibilityOnItem_Click(object sender, EventArgs e)
        {
            dgvFileList.Columns[sender.ToString()].Visible = !dgvFileList.Columns[sender.ToString()].Visible;
        }

        private void lnklblWorkingPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(txtPizPath.Text))
                diagFolderBrowser.SelectedPath = txtPizPath.Text;
            
            DialogResult ret = diagFolderBrowser.ShowDialog();
            if (ret == DialogResult.Cancel)
                return; 

            txtPizPath.Text = diagFolderBrowser.SelectedPath;
            this.Text = "Shared Sequences Browser - " + txtPizPath.Text;
            toolTip.SetToolTip(txtPizPath, txtPizPath.Text);
            cmdPersonalize.Visible = false;
            cmdMoveFiles.Visible = false;
        }

        private void dgvFileList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UseWaitCursor = true;
            XSEQ seq = dgvFileList.Rows[e.RowIndex].DataBoundItem as XSEQ;
            Core.saveXLA(seq);
            UseWaitCursor = false;
        }

        private async void cmdPersonalize_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(Settings.layoutPath))
            {
                MessageBox.Show("Unable to find the location of your show directory.  Please check the location set in File->Preferences to continue.", "No show directory selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UseWaitCursor = true;

            // This function would take the copy the xlights_rgbeffects.xml to xlights_rgbeffects.bak and replace the perspectives element with our own and then save the xml file.
            // It also replaces the xlights_keybindings.xml file.

            dgvFileList.DataSource = null;
            dgvFileList.Columns.Clear();
            dgvFileList.Rows.Clear();

            var myFiles = Directory
                .EnumerateFiles(txtPizPath.Text, "*.xml", SearchOption.AllDirectories);

            progBar.Value = 0;
            progBar.Maximum = myFiles.Count();
            progBar.Visible = true;

            var progress = new Progress<int>(p => progBar.Value = p);
            List<PersonalizationStatus> resultsRpt = await Task.Factory.StartNew(() => personalizeSharedSequences(myFiles, progress), TaskCreationOptions.LongRunning);

            BindingList<PersonalizationStatus> l = new BindingList<PersonalizationStatus>(resultsRpt);
            BindingSource s = new BindingSource(l, null);
            dgvFileList.DataSource = s;
            s.ResetBindings(true);

            cmdPersonalize.Visible = false;
            progBar.Visible = false;

            UseWaitCursor = false;
        }

        private List<PersonalizationStatus> personalizeSharedSequences(IEnumerable<string> myFiles, IProgress<int> progress)
        {
            UseWaitCursor = false;

            if (progress == null)
                progress = new Progress<int>();

            XElement myPerspectives;
            XElement xelement = XElement.Load(Path.Combine(Settings.layoutPath, Settings.LAYOUTFILE));
            myPerspectives = xelement.Descendants("perspectives").FirstOrDefault();

            List<PersonalizationStatus> resultsReport = new List<PersonalizationStatus>();
            int i = 0;
            string canFile;
            foreach (string file in myFiles)
            {
                progress.Report(++i);
                canFile = Path.GetFileName(file);
                if ((file.Contains("\\Backup\\")) || (file.Contains("\\__MACOSX\\")))
                {
                    // ignore it
                }
                else if (canFile == "xlights_rgbeffects.xml")
                {
                    try
                    {
                        // If there's a keybindings file, back it up and replace it with ours.
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(file), "xlights_keybindings.xml")))
                            File.Move(Path.Combine(Path.GetDirectoryName(file), "xlights_keybindings.xml"), Path.Combine(Path.GetDirectoryName(file), "xlights_keybindings" + DateTime.Now.ToString(".yyyyMMddHHmmssf") + ".bak"));
                        File.Copy(Path.Combine(Settings.layoutPath, "xlights_keybindings.xml"), Path.Combine(Path.GetDirectoryName(file), "xlights_keybindings.xml"));

                        // make a backup of the rgbeffects file before modifying
                        File.Copy(file, Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString(".yyyyMMddHHmmssf") + ".bak"));

                        // open and replace perspectives element with ours.
                        XElement doc = XElement.Load(file);
                        doc.Descendants("perspectives").Remove();
                        doc.Add(myPerspectives);
                        doc.Save(file);

                        resultsReport.Add(new PersonalizationStatus { 
                            FullPath = "Success",
                            Folder = Path.GetDirectoryName(file), 
                            File = "Key Bindings and Perspectives", 
                            Status = "Personalization complete."
                        });
                    }
                    catch (Exception ex)
                    {
                        resultsReport.Add(new PersonalizationStatus {
                            FullPath = "Error",
                            Folder = Path.GetDirectoryName(file),
                            File = ex.Message,
                            Status = "Try opening this sequence in xlights then save, close and try to personalize again."
                        });

                    }
                }
            }

            UseWaitCursor = false;
            
            return resultsReport;
        }

        private void cmdAnalyze_Click(object sender, EventArgs e)
        {
            dgvFileList.Rows.Clear();
            cmdMoveFiles.Visible = true;
            pizLook(false);
        }

        private void cmdMoveFiles_Click(object sender, EventArgs e)
        {
            dgvFileList.Rows.Clear();
            cmdMoveFiles.Visible = true;
            pizLook(true);
        }

        private void pizLook(bool andMove)
        {
            UseWaitCursor = true;

            // Look at path in txtPizPath and find files matching folder names and map them up
            // Would be nice to show archives that are not extracted
            // Would also be nice to show folders missing their archive copy
            List<string> dirs = Directory.EnumerateDirectories(txtPizPath.Text).ToList();
            List<string> files = Directory.EnumerateFiles(txtPizPath.Text).ToList();

            dgvFileList.Columns.Clear();
            dgvFileList.Rows.Clear();

            string canDir, canFile;
            List<PersonalizationStatus> resultsReport = new List<PersonalizationStatus>();
            foreach (string file in files)
            {
                canFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file).Trim());
                canDir = dirs.Find(s => s == canFile);
                if (canDir != null)
                {
                    if (andMove)
                    {
                        File.Move(file, Path.Combine(canDir, Path.GetFileName(file)));
                        // dgvFileList.Rows.Add(new string[] { canDir, "Consolidated" });

                        resultsReport.Add(new PersonalizationStatus
                        {
                            FullPath = "Success",
                            Folder = canDir,
                            File = Path.GetFileName(file),
                            Status = "ZIP/PIZ file moved to folder of same name."
                        });

                    }
                    else
                    {
                        //dgvFileList.Rows.Add(new string[] { canDir, file });
                        resultsReport.Add(new PersonalizationStatus
                        {
                            FullPath = "Could move file",
                            Folder = canDir,
                            File = Path.GetFileName(file),
                            Status = "ZIP/PIZ could be moved under folder of the same name."
                        });
                    }
                }

            }

            dgvFileList.DataSource = new BindingSource(new BindingList<PersonalizationStatus>(resultsReport), null);

            UseWaitCursor = false;
        }

        private void dgvFileList_MouseMove(object sender, MouseEventArgs e)
        {
            //// See which row is currently under the mouse:
            //int newHoveredIndex = dgvFileList.IndexFromPoint(e.Location);

            //// If the row has changed since last moving the mouse:
            //if (hoveredIndex != newHoveredIndex)
            //{
            //    // Change the variable for the next time we move the mouse:
            //    hoveredIndex = newHoveredIndex;

            //    // If over a row showing data (rather than blank space):
            //    if (hoveredIndex > -1)
            //    {
            //        //Set tooltip text for the row now under the mouse:
            //        tt1.Active = false;
            //        tt1.SetToolTip(lstCars, ((Car)lstCars.Items[hoveredIndex]).Info);
            //        tt1.Active = true;
            //    }
            //}

        }

        private void dgvFileList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private int dgvFileListRowContext = 0;
        private int dgvFileListColContext = 0;
        private void dgvFileList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvFileListRowContext = e.RowIndex;
            dgvFileListColContext = e.ColumnIndex;
        }

        private void toolStripMenuItemOpenInXLights_Click(object sender, EventArgs e)
        {
            XSEQ seq = dgvFileList.Rows[dgvFileListRowContext].DataBoundItem as XSEQ;

            System.Diagnostics.Process.Start(seq.FileFullname);
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XSEQ seq = dgvFileList.Rows[dgvFileListRowContext].DataBoundItem as XSEQ;

            System.Diagnostics.Process.Start(seq.Filepath);
        }

        private void dgvFileList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvFileList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UseWaitCursor = true;
            Cursor.Position = Cursor.Position;

            // sort data grid by this col
            //e.ColumnIndex
            if (e.Button == MouseButtons.Left)
            {
                // sort by e.ColumnIndex
                // sortBy(x => x.FileFullname);
                Task.Factory.StartNew(() =>
                    sortBy(typeof(XSEQ).GetProperty(dgvFileList.Columns[e.ColumnIndex].DataPropertyName)),
                    TaskCreationOptions.LongRunning);
            }
            else if (e.Button == MouseButtons.Right)
            {
                // display sort/search context menu
            }

            seqList.ResetBindings();
            UseWaitCursor = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                txtSearch.Focus();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                clearSearchResults();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void searchfieldToolStripMenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            // stop the ding
            e.SuppressKeyPress = true;

            searchBy(
                typeof(XSEQ).GetProperty(dgvFileList.Columns[dgvFileListColContext].DataPropertyName),
                searchfieldToolStripMenuItem.Text
                );

            txtSearch.Text = searchfieldToolStripMenuItem.Text;
            picboxClearSearchResults.Visible = true;
            searchfieldToolStripMenuItem.Text = "";
            contextMenuStripXSeq.Visible = false;
        }


        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            // stop the ding
            e.SuppressKeyPress = true;

            if (string.IsNullOrEmpty(txtSearch.Text))
                return;

            searchBy(null, txtSearch.Text);
            picboxClearSearchResults.Visible = true;
            txtSearch.SelectAll();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void picboxClearSearchResults_Click(object sender, EventArgs e)
        {
            clearSearchResults();
        }

        bool showingSearchResults = false;
        private void clearSearchResults()
        {
            if (!showingSearchResults)
                return;

            UseWaitCursor = true;

            seqList = new BindingList<XSEQ>(seqs);
            BindingSource bindableSeqs = new BindingSource(seqList, null);
            dgvFileList.DataSource = bindableSeqs;

            txtSearch.Text = "";
            picboxClearSearchResults.Visible = false;
            showingSearchResults = false;

            UseWaitCursor = false;
        }
    }
}
