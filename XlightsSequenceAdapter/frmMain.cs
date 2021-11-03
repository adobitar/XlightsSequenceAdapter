using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;
using System.Resources;

namespace XlightsSequenceAdapter
{
    public partial class frmMain : Form
    {
        // TODO: handle shaders in addition to pictures and videos.

        // A list of the models in the reference layout
        List<String> layoutModels = new List<String>();
        string ShowFileToAdapt;
        string ShowPath;
        string layoutPath;
        const string layoutFile = "xlights_rgbeffects.xml";
        const string noselection = "- None Selected -";

        public frmMain()
        {
            InitializeComponent();

            cmdOpenShow.Enabled = false;
            cmdExport.Enabled = false;
            lblRefShow.Text = noselection;
            lblShowName.Text = noselection;

#if DEBUG
            layoutPath = "D:\\Documents\\XLights Show\\2021";
            diagFolderBrowser.SelectedPath = layoutPath;
            diagSaveFile.InitialDirectory = layoutPath;
            loadXRGB(Path.Combine(layoutPath, layoutFile));
#endif
            rtfHelp.LoadFile("xLightsAdapterHelp.rtf");
        }

        private void cmdSelectReference_Click(object sender, EventArgs e)
        {
            DialogResult res = diagFolderBrowser.ShowDialog();

            if (res == DialogResult.Cancel)
            {
                return;
            }

            cmdOpenShow.Enabled = false;
            cmdExport.Enabled = false;
            lblRefShow.Text = noselection;

            layoutPath = diagFolderBrowser.SelectedPath;
            string xrgbpath = Path.Combine(layoutPath, layoutFile);
            if (!File.Exists(xrgbpath))
            {
                MessageBox.Show("Could not find xlights_rgbeffects.xml file in selected location.  Please try again.", "Could not find xlights layout file", MessageBoxButtons.OK);
                return;
            }

            diagSaveFile.InitialDirectory = diagFolderBrowser.SelectedPath;

            loadXRGB(xrgbpath);
        }

        private void loadXRGB(string xrgbpath)
        {
            layoutModels.Clear();

            // Look for xlights_rgbeffects.xml in selected folder
            // read in <xrgb><models><model name="XXXX"> (could get submodels...) 
            // also read in and <xrgb><modelGroups><modelGroup name="">
            XElement xelement = XElement.Load(xrgbpath);

            foreach (XElement xEle in xelement.Descendants("models").Descendants("model"))
            {
                layoutModels.Add(xEle.Attribute("name").Value);
            }

            foreach (XElement xEle in xelement.Descendants("modelGroups").Descendants("modelGroup"))
            {
                layoutModels.Add(xEle.Attribute("name").Value);
            }

            // TODO: Add something like - use constant so  you can compare easily.  This allows us to unmap a mapping.  layoutModels.Add("- None -");

            layoutModels.Sort();

            lblRefShow.Text = diagFolderBrowser.SelectedPath;
            cmdOpenShow.Enabled = true;

            //MessageBox.Show(String.Format("xlights_rgbeffects.xml file found.  {0} models and model groups found.  " + 
            //        "Ready to adapt a show to your layout.", layoutModels.Count.ToString()), "Layout found.",MessageBoxButtons.OK);

        }

        private void cmdOpenShow_Click(object sender, EventArgs e)
        {
            cmdExport.Enabled = false;

            diagOpenFile.Filter = "Sequence files (*.xml, *.xsq) | *.xml; *.xsq|All files (*.*) | *.*";
            DialogResult res = diagOpenFile.ShowDialog();

            if (res == DialogResult.Cancel)
                return;

            // TODO: Need to check that the show is valid somehow...

            ShowFileToAdapt = diagOpenFile.FileName;
            ShowPath = Path.GetDirectoryName(ShowFileToAdapt);
            diagSaveFile.FileName = "Adapted-" + diagOpenFile.SafeFileName;
            lblShowName.Text = diagOpenFile.SafeFileName;
            dgvModels.Rows.Clear();
            listShowAssets.Nodes.Clear();

            // Look for xlights_rgbeffects.xml in selected folder
            // read in <xrgb><models><model name="XXXX"> (could get submodels...) 
            // also read in and <xrgb><modelGroups><modelGroup name="">

            List<String> models = new List<String>();
            XElement doc = XElement.Load(ShowFileToAdapt);

            // Sample xsequence file
            //<?xml version="1.0" encoding="UTF-8"?>
            //<xsequence BaseChannel="0" ChanCtrlBasic="0" ChanCtrlColor="0" FixedPointTiming="1" ModelBlending="true">      
            //  <DisplayElements>          
            //    <Element collapsed="0" type="timing" name="bells" visible="1" views="Song sequencing" active="0"/>
            //    <Element collapsed="0" type="model" name="Canes Right" visible="1"/>
            //    <Element collapsed="0" type="model" name="Canes Left" visible="1"/>
            //    <Element collapsed="0" type="model" name="Horizontals" visible="1"/>
            //  </DisplayElements>
            //  <ElementEffects>
            //    <Element type="timing" name="bells">
            //      <EffectLayer>
            //        <Effect label="" startTime="0" endTime="224675"></Effect>
            //        <Effect label="" startTime="224675" endTime="225300"></Effect>
            //      </EffectLayer>
            //    </Element>
            //    <Element type="model" name="Canes Right">
            //      <EffectLayer/>
            //    </Element>
            //    <Element type="model" name="Canes Left">
            //      <EffectLayer/>
            //    </Element>
            //    <Element type="model" name= "Megatree" >
            //      <EffectLayer>
            //        <Effect ref="218" name="Morph" startTime="54800" endTime="57725" palette="102"/>
            //        <Effect ref="218" name="Morph" id="1" startTime="205250" endTime="206525" palette="102"/>
            //      </EffectLayer>
            //      <EffectLayer>
            //        <Effect ref="219" name="Morph" startTime="54950" endTime="58425" palette="102"/>
            //        <Effect ref="219" name="Morph" id="1" startTime="205400" endTime="206675" palette="102"/>
            //      </EffectLayer>
            //    </Element>
            //  <ElementEffects>
            //</xsequence>

            // put effect details, count, duration, etc, in table
            var demodels = from model in doc.Elements("ElementEffects").Elements("Element")
                           where (string)model.Attribute("type") == "model"
                           select model;

            int indx, fxcount;
            long fxduration, fxstart, fxend;
            List<String> fx = new List<string>();
            foreach (XElement displayElement in demodels)
            {
                // create row for model in table
                //  this.dgvModels = new System.Windows.Forms.DataGridView();
                //  this.colShowModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //  this.colModelFXLayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //  this.colModelFXCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //  this.colModelFXDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //  this.colModelFX = new System.Windows.Forms.DataGridViewComboBoxColumn();
                //  this.colMapTo = new System.Windows.Forms.DataGridViewComboBoxColumn();


                indx = dgvModels.Rows.Add();
                dgvModels.Rows[indx].Cells[colShowModel.Index].Value = displayElement.Attribute("name").Value;

                var fxlayers = from layers in displayElement.Elements("EffectLayer")
                               select layers;
                dgvModels.Rows[indx].Cells[colModelFXLayers.Index].Value = fxlayers.Count();

                // Count of FX
                fx.Clear();
                fxcount = 0;
                fxduration = 0;
                foreach (XElement fxlayer in fxlayers)
                {
                    var effects = from effect in fxlayer.Elements("Effect")
                                  select effect;

                    fxcount += effects.Count();
                    foreach (XElement effect in effects)
                    {
                        fxstart = fxend = 0;
                        long.TryParse(effect.Attribute("startTime").Value.ToString(), out fxstart);
                        long.TryParse(effect.Attribute("endTime").Value.ToString(), out fxend);
                        fxduration += fxend - fxstart;
                        fx.Add(effect.Attribute("name").Value.ToString());
                    }

                }

                dgvModels.Rows[indx].Cells[colModelFXDuration.Index].Value = fxduration;
                dgvModels.Rows[indx].Cells[colModelFXCount.Index].Value = fxcount;
                // fxcount = fx.Count();       // Should be the same - just checking; should be able to remove manual count stuff...

                DataGridViewComboBoxCell fxCell = new DataGridViewComboBoxCell();
                fxCell.Items.AddRange(fx.ToArray());
                dgvModels.Rows[indx].Cells[colModelFX.Index] = fxCell;

                DataGridViewComboBoxCell mapCell = new DataGridViewComboBoxCell();
                mapCell.Items.AddRange(layoutModels.ToArray());
                dgvModels.Rows[indx].Cells[colMapTo.Index] = mapCell;

                // TODO: save a mapping file so if you open it again, you can tweak instead of starting over.
                // if we have a model in our layout that matches the name of the model from the show, put our name in colMapTo
                if (layoutModels.Contains(displayElement.Attribute("name").Value))
                    dgvModels.Rows[indx].Cells[colMapTo.Index].Value = displayElement.Attribute("name").Value;
            }

            // Grab mediafile and drop it in the assets list
            string filename = "";
            int imgindex;
            filename = doc.Element("head").Element("mediaFile").Value.Replace("/", "\\");
            imgindex = File.Exists(filename) ? 1 : 0;
            listShowAssets.Nodes.Add(new TreeNode(filename, imgindex, imgindex));

            // Finally, go through file and look for any of the following:
            //  E_FILEPICKERCTRL_Video_Filename
            //  E_FILEPICKER_Pictures_Filename
            //  Shaders?
            // Add these to the listShowAssets control

            var assets = from show in doc.Elements("EffectDB").Elements("Effect")
                         where show.Value.Contains("E_FILEPICKERCTRL_Video_Filename") ||
                               show.Value.Contains("E_FILEPICKER_Pictures_Filename")
                         select show;

            // parse out the file name from the matching string.
            foreach (XElement asset in assets)
            {
                filename = getAssetFullFilePathFromEffect(asset.Value);
                
                // Only add the file to the list if it's not already there.
                if (!nodeExists(filename, listShowAssets.Nodes))
                {
                    imgindex = File.Exists(filename.Replace("/","\\")) ? 1 : 0;
                    listShowAssets.Nodes.Add(new TreeNode(filename, imgindex, imgindex));
                }
            }

            cmdExport.Enabled = true;
        }

        private string getAssetFullFilePathFromEffect(string effectDefinition)
        {
            string effectAssetType = "";
            if (effectDefinition.Contains("E_FILEPICKERCTRL_Video_Filename"))
                effectAssetType = "E_FILEPICKERCTRL_Video_Filename";
            else if (effectDefinition.Contains("E_FILEPICKER_Pictures_Filename"))
                effectAssetType = "E_FILEPICKER_Pictures_Filename";

            return effectDefinition.Substring(effectDefinition.IndexOf(effectAssetType) + effectAssetType.Length + 1,
                effectDefinition.IndexOf(",", effectDefinition.IndexOf(effectAssetType)) - effectDefinition.IndexOf(effectAssetType) - effectAssetType.Length - 1);
        }

        private bool nodeExists(string nodeText, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == nodeText) return true;
            }

            return false;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            // Must have at least one mapping to export
            bool noMapping = true;
            DataGridViewComboBoxCell cell;
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                cell = (DataGridViewComboBoxCell) row.Cells[colMapTo.Index];
                if (cell.Value != null)
                {
                    noMapping = false;
                    break;
                }
            }

            if (noMapping)
            {
                MessageBox.Show("Please make at least one mapping selection in the Map To column to create a show adaptation.  " +
                    "You may want to map any models that have effects associated with them to models in your layout and then adjust in xLights.",
                    "No mappings found.", MessageBoxButtons.OK);
                return;
            }

            DialogResult res = diagSaveFile.ShowDialog();
            if (res == DialogResult.Cancel)
                return;

            // Open show and begin writing out every node to a new file other than DisplayElements and ElementEffects.
            // Create a DisplayElements node including all original timing elements:
            //  <Element collapsed="0" type="timing" name="Main Lyrics" visible="1" views="Master View,Faces,Song sequencing" active="1"/>
            // Do not add their models, instead, add any MapTo models
            //  <Element collapsed="0" type="model" name="XXX" visible="1"/>
            // Next...
            // Create ElementEffects, add all of the show timing elements:
            //  <ElementEffects>
            //    <Element type="timing" name="Beats">
            //      <EffectLayer>
            //        <Effect label="1" startTime="375" endTime="825"></Effect>
            //        <Effect label="2" startTime="825" endTime="1300"></Effect>
            //      </EffectLayer>
            //    </Element>
            //  </ElementEffects>
            // Finally, iterate over mapto models and create a node for that model and then the effectLayer and effects from anything being mapped
            //  <ElementEffects>
            //    <Element type="model" name="Cane 4">
            //      <EffectLayer>
            //        <Effect ref="220" name="Morph" startTime="64875" endTime="65625" palette="101"/>
            //        <Effect ref="122" name="Morph" id="1" startTime="67050" endTime="67800" palette="66"/>
            //        <Effect ref="79" name="On" id="2" startTime="107900" endTime="108550" palette="14"/>
            //      </EffectLayer>
            //      <EffectLayer>
            //        <Effect ref="219" name="Morph" startTime="54950" endTime="58425" palette="102"/>
            //        <Effect ref="219" name="Morph" id="1" startTime="205400" endTime="206675" palette="102"/>
            //    </Element>
            //  </ElementEffects>

            // Actually, xLights handles duplicate models gracefully - we can just remove their models, put ours in and then rename their elementeffect model references with our mappings...
            XElement doc = XElement.Load(ShowFileToAdapt);

            // Writes all nodes out to console
            //IEnumerable<XElement> childList =
            //    from el in doc.Elements()
            //    select el;

            //foreach (XElement l in childList)
            //    Console.WriteLine(l);

            // Replace Element effects of type model with our list
            var demodels = from model in doc.Element("DisplayElements").Elements("Element")
                           where (string)model.Attribute("type") == "model"
                           select model;
            demodels.Remove();

            foreach(string model in layoutModels)
            {
                doc.Element("DisplayElements").Add(
                    new XElement("Element", 
                        new XAttribute("collapsed", "0"),
                        new XAttribute("type", "model"),
                        new XAttribute("name", model),
                        new XAttribute("visible", "1")
                    ));
            }

            // Go through the show models and if they are mapped, update them, otherwise remove them
            string showModel;
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                showModel = row.Cells[colShowModel.Index].Value.ToString();
                cell = (DataGridViewComboBoxCell)row.Cells[colMapTo.Index];
                if (cell.Value != null)
                {
                    doc.Elements("ElementEffects").Elements("Element").Where(X => X.Attribute("name").Value == showModel).FirstOrDefault().AddBeforeSelf(new XComment("Adapted from: " + showModel));
                    doc.Elements("ElementEffects").Elements("Element").Where(X => X.Attribute("name").Value == showModel).FirstOrDefault().SetAttributeValue("name", cell.Value);
                }
                else
                {
                    doc.Elements("ElementEffects").Elements("Element").Where(X => X.Attribute("name").Value == showModel).FirstOrDefault().AddBeforeSelf(new XComment(showModel + " model removed during adaptation."));
                    doc.Elements("ElementEffects").Elements("Element").Where(X => X.Attribute("name").Value == showModel).FirstOrDefault().Remove();
                }
            }

            // TODO: bug here - putting adapted folder in show directory and not with selected save file.
            string adaptedShowPath = Path.Combine(layoutPath, Path.GetFileNameWithoutExtension(diagSaveFile.FileName));

            if (chkRemapAssets.Checked)
            {
                foreach (TreeNode asset in listShowAssets.Nodes)
                {
                    // look for all EffectDB entries containing one of the asset types (Video or Pictures) and my filename
                    var effects = from show in doc.Elements("EffectDB").Elements("Effect")
                                 where ((show.Value.Contains("E_FILEPICKERCTRL_Video_Filename") ||
                                       show.Value.Contains("E_FILEPICKER_Pictures_Filename")) && 
                                       (show.Value.Contains(Path.GetFileName(asset.Text))))
                                 select show;

                    // update all references to matching files with new show directory location
                    foreach (XElement effect in effects)
                    {
                        effect.Value = effect.Value.Replace(getAssetFullFilePathFromEffect(effect.Value), Path.Combine(adaptedShowPath, Path.GetFileName(asset.Text)));
                    }

                    // Check for the MediaFile as well
                    if (doc.Element("head").Element("mediaFile").Value.Contains(Path.GetFileName(asset.Text)))
                        doc.Element("head").Element("mediaFile").Value = Path.Combine(adaptedShowPath, Path.GetFileName(asset.Text));
                }
            }

            doc.Save(diagSaveFile.FileName);

            // create folder and copy asset files if any are found; if directory already exists, will not overwrite.
            if (chkCopyAssets.Checked)
            {
                res = MessageBox.Show("A directory folder will be created with the adapted show file to place a copy of assets that were found.  No existing files will be overwritten or modified.  Ok to continue or cancel to skip.", "Create directory and copy assets?", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                {
                    string assetFile;
                    if (!Directory.Exists(adaptedShowPath))
                        Directory.CreateDirectory(adaptedShowPath);

                    foreach (TreeNode file in listShowAssets.Nodes)
                    {
                        assetFile = Path.Combine(adaptedShowPath, Path.GetFileName(file.Text));
                        if ((File.Exists(file.Text)) && (!File.Exists(assetFile)))
                        {
                            File.Copy(file.Text, assetFile);
                        }
                    }
                }
            }

            MessageBox.Show("Show adapted with your mappings.",
                    "Done!", MessageBoxButtons.OK);
            
            Process.Start("explorer.exe", layoutPath);
        }

        private void cmdFindAssetFiles_Click(object sender, EventArgs e)
        {
            // look in show directory and below for files listed in listShowAssets

            string filename;
            string[] files;
            List<string> assets = new List<string>();
            foreach (TreeNode file in listShowAssets.Nodes)
            {
                filename = Path.GetFileName(file.Text);

                // TODO: Need to handle duplicate files (same filename in different directories).
                files = Directory.GetFiles(ShowPath, filename, SearchOption.AllDirectories);

                if (files.Length > 0)
                    assets.AddRange(files);
                else
                    assets.Add(file.Text);
            }

            listShowAssets.Nodes.Clear();

            // parse out the file name from the matching string.
            int imgindex;
            foreach (string file in assets)
            {
                imgindex = File.Exists(file) ? 1 : 0;
                listShowAssets.Nodes.Add(new TreeNode(file, imgindex, imgindex));
            }

        }

        private void rtfHelp_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
