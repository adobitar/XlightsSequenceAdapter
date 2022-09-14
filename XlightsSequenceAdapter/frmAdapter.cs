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
    public partial class frmAdapter : Form
    {
        // A list of the models in the reference layout
        List<String> layoutModels = new List<String>();
        List<String> layoutModelsAndSubs = new List<String>();
        string ShowFileToAdapt = "";
        string ShowPath = "";
        string layoutPath = Settings.layoutPath;
        string assetsPath = Settings.assetsPath;
        XElement myPerspectives;
        const string layoutFile = Settings.LAYOUTFILE;
        const string noselection = Settings.NOSELECTION;

        public frmAdapter()
        {
            InitializeComponent();

            cmdOpenShow.Enabled = false;
            cmdExportShowSAF.Enabled = false;
            lblRefShow.Text = noselection;
            lblShowName.Text = noselection;

            if (File.Exists(Path.Combine(layoutPath, layoutFile)))
            {
                lblRefShow.Text = layoutPath;
                loadXRGB(Path.Combine(layoutPath, layoutFile));
            }

            if (Directory.Exists(assetsPath))
            {
                lblAssetLocation.Text = assetsPath;
            }
            else
            {
                lblAssetLocation.Text = "Not set...";
                assetsPath = null;
            }
        }

        private void cmdSelectReference_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(layoutPath))
                diagFolderBrowser.SelectedPath = layoutPath;

            diagFolderBrowser.Description = "Please select the folder containing your show layout (xlights_rgbeffects.xml).";

            DialogResult res = diagFolderBrowser.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }

            layoutPath = diagFolderBrowser.SelectedPath;

            cmdOpenShow.Enabled = false;
            cmdExportShowSAF.Enabled = false;

            string xrgbpath = Path.Combine(layoutPath, layoutFile);
            if (!File.Exists(xrgbpath))
            {
                MessageBox.Show("Could not find xlights_rgbeffects.xml file in selected location.  Please try again.", "Could not find xlights layout file", MessageBoxButtons.OK);
                return;
            }

            Settings.layoutPath = layoutPath;
            lblRefShow.Text = layoutPath;

            diagSaveFile.InitialDirectory = diagFolderBrowser.SelectedPath;
            loadXRGB(xrgbpath);
        }

        private void loadXRGB(string xrgbpath)
        {
            layoutModels.Clear();
            layoutModelsAndSubs.Clear();

            // Look for xlights_rgbeffects.xml in selected folder
            // read in <xrgb><models><model name="XXXX"><subModel name="YYYY">
            // also read in and <xrgb><modelGroups><modelGroup name="">
            XElement xelement = XElement.Load(xrgbpath);

            foreach (XElement xEle in xelement.Descendants("models").Descendants("model"))
            {
                layoutModels.Add(xEle.Attribute("name").Value);
                layoutModelsAndSubs.Add(xEle.Attribute("name").Value);

                foreach (XElement sub in xEle.Descendants("subModel"))
                    layoutModelsAndSubs.Add(xEle.Attribute("name").Value + "/" + sub.Attribute("name").Value);
            }

            foreach (XElement xEle in xelement.Descendants("modelGroups").Descendants("modelGroup"))
            {
                layoutModels.Add(xEle.Attribute("name").Value);
                layoutModelsAndSubs.Add(xEle.Attribute("name").Value);
            }

            myPerspectives = xelement.Descendants("perspectives").FirstOrDefault();

            // Add a "No Selection" option to remove a mapping.
            layoutModels.Add(noselection);
            layoutModelsAndSubs.Add(noselection);

            layoutModels.Sort();
            layoutModelsAndSubs.Sort();
            cmdOpenShow.Enabled = true;

            //MessageBox.Show(String.Format("xlights_rgbeffects.xml file found.  {0} models and model groups found.  " + 
            //        "Ready to adapt a show to your layout.", layoutModels.Count.ToString()), "Layout found.",MessageBoxButtons.OK);

        }

        private void cmdOpenShow_Click(object sender, EventArgs e)
        {
            cmdExportShowSAF.Enabled = false;

            diagOpenFile.Filter = "Sequence files (*.xml, *.xsq) | *.xml; *.xsq|All files (*.*) | *.*";
            diagOpenFile.InitialDirectory = Settings.sharedPath;
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
            //    <Element type="model" name="Wreath">
            //      <EffectLayer/>
            //      <SubModelEffectLayer name="Ring1">
            //        <Effect ref="3" name="On" startTime="650" endTime="1650" palette="3"/>
            //        <Effect ref="4" name="On" id="1" startTime="15250" endTime="16250" palette="3"/>
            //      </SubModelEffectLayer>
            //      <SubModelEffectLayer layer="1" name="Ring1">
            //        <Effect ref="4" name="On" startTime="2475" endTime="3475" palette="3"/>
            //      </SubModelEffectLayer>
            //      <SubModelEffectLayer name="Ring2">
            //        <Effect ref="5" name="Video" startTime="6375" endTime="7375" palette="3"/>
            //      </SubModelEffectLayer>
            //      <SubModelEffectLayer name="Ring3">
            //        <Effect ref="6" name="Pictures" startTime="7575" endTime="8575" palette="3"/>
            //      </SubModelEffectLayer>
            //      <Strand index="0">
            //        <Effect ref="4" name="On" startTime="23675" endTime="24675" palette="3"/>
            //        <Node index="4" name="Node 5">
            //          <Effect ref="3" name="On" startTime="4500" endTime="5500" palette="3"/>
            //        </Node>
            //        <Node index="176" name="Node 177">
            //          <Effect ref="7" name="Shader" startTime="2400" endTime="5700" palette="3"/>
            //        </Node>
            //      </Strand>
            //      <Strand index="0" layer="1">
            //        <Effect ref="4" name="On" startTime="23875" endTime="24875" palette="3"/>
            //      </Strand>
            //      <Strand index="0" layer="2">
            //        <Effect ref="4" name="On" startTime="24425" endTime="25425" palette="3"/>
            //      </Strand>
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

            int fxcount;
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

                // First EffectLayers for this model
                var fxlayers = from layers in displayElement.Elements("EffectLayer")
                               select layers;

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

                addModelRow(displayElement.Attribute("name").Value, fx, fxduration, fxcount, fxlayers.Count());
                
                // Next SubModelEffectLayers for this model
                fxlayers = from layers in displayElement.Elements("SubModelEffectLayer")
                               select layers;

                // Get list of all submodels that are displayed and then process them one by one.  Submodel layers are a little different than model layers.
                //  Each layer carries the submodel name and gets a layer attribute that gets incrimented.  When we get a list of all of the submodeleffectlayers,
                //  we should combine all of the submodels with the same name.
                List<String> subs = new List<string>();
                foreach (XElement fxlayer in fxlayers)
                {
                    if (!subs.Contains(fxlayer.Attribute("name").Value))
                        subs.Add(fxlayer.Attribute("name").Value);
                }

                foreach (string sub in subs)
                {
                    // get all of the submodeleffectlayers for the submodel named sub in the list of submodels
                    fxlayers = from layers in displayElement.Elements("SubModelEffectLayer")
                               where (string)layers.Attribute("name") == sub
                               select layers;

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

                    addModelRow(displayElement.Attribute("name").Value + "/" + sub, fx, fxduration, fxcount, fxlayers.Count());
                }

            }

            // Process Assets

            // Grab mediafile and drop it in the assets list
            string filename = "";
            int imgindex;
            filename = doc.Element("head").Element("mediaFile").Value.Replace("/", "\\");
            imgindex = File.Exists(filename) ? 1 : 0;
            listShowAssets.Nodes.Add(new TreeNode(filename, imgindex, imgindex));

            // Finally, go through file and look for any of the following (videos, pictures, shaders):
            //  E_FILEPICKERCTRL_Video_Filename
            //  E_FILEPICKER_Pictures_Filename
            //  E_0FILEPICKERCTRL_IFS
            // Add these to the listShowAssets control

            var assets = from show in doc.Elements("EffectDB").Elements("Effect")
                         where show.Value.Contains("E_FILEPICKERCTRL_Video_Filename") ||
                               show.Value.Contains("E_FILEPICKER_Pictures_Filename") ||
                               show.Value.Contains("E_0FILEPICKERCTRL_IFS")
                         select show;

            // parse out the file name from the matching string.
            foreach (XElement asset in assets)
            {
                filename = getAssetFullFilePathFromEffect(asset.Value);

                // Only add the file to the list if it's not already there.
                if (!nodeExists(filename, listShowAssets.Nodes))
                {
                    imgindex = File.Exists(filename.Replace("/", "\\")) ? 1 : 0;
                    listShowAssets.Nodes.Add(new TreeNode(filename, imgindex, imgindex));
                }
            }

            cmdExportShowSAF.Enabled = true;
        }

        private void addModelRow(string modelName, List<String> fx, long fxduration, long fxcount, int layerCount)
        {
            int indx = dgvModels.Rows.Add();
            dgvModels.Rows[indx].Cells[colShowModel.Index].Value = modelName;

            dgvModels.Rows[indx].Cells[colModelFXDuration.Index].Value = fxduration;
            dgvModels.Rows[indx].Cells[colModelFXCount.Index].Value = fxcount;
            dgvModels.Rows[indx].Cells[colModelFXLayers.Index].Value = layerCount;

            DataGridViewComboBoxCell fxCell = new DataGridViewComboBoxCell();
            fxCell.Items.AddRange(fx.ToArray());
            dgvModels.Rows[indx].Cells[colModelFX.Index] = fxCell;

            DataGridViewComboBoxCell mapCell = new DataGridViewComboBoxCell();
            mapCell.Items.AddRange(layoutModels.ToArray());
            dgvModels.Rows[indx].Cells[colMapTo.Index] = mapCell;

            // if we have a model in our layout that matches the name of the model from the show, put our name in colMapTo
            if (layoutModels.Contains(modelName))
                dgvModels.Rows[indx].Cells[colMapTo.Index].Value = modelName;
        }

        private void chkHideNoEffects_CheckedChanged(object sender, EventArgs e)
        {
            int fxc;
            // Hide models with no effects on model, submodels, or strands/nodes (if we add support for that).
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                fxc = 0;
                // check to see if the subs of this model also have 0 before hiding model
                foreach (DataGridViewRow subrow in dgvModels.Rows)
                {
                    // if inner loop model matches outer loop model, add to the effect count.
                    // also, if the inner loop is a submodel (has a / in it's value) of the outer loop model, count it's effects as well.
                    if ((subrow.Cells[colShowModel.Index].Value.ToString() == row.Cells[colShowModel.Index].Value.ToString()) ||
                        ((subrow.Cells[colShowModel.Index].Value.ToString().Contains("/")) &&
                        subrow.Cells[colShowModel.Index].Value.ToString().StartsWith(row.Cells[colShowModel.Index].Value.ToString())))
                        fxc += int.Parse(subrow.Cells[colModelFXCount.Index].Value.ToString());
                }

                if (fxc == 0)
                    row.Visible = !chkHideNoEffects.Checked;
            }
        }

        private void chkShowMapToSubs_CheckedChanged(object sender, EventArgs e)
        {
            object curValue;
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                curValue = row.Cells[colMapTo.Index].Value;
                ((DataGridViewComboBoxCell)row.Cells[colMapTo.Index]).Items.Clear();

                if (chkShowMapToSubs.Checked)
                    ((DataGridViewComboBoxCell)row.Cells[colMapTo.Index]).Items.AddRange(layoutModelsAndSubs.ToArray());
                else
                {
                    if ((curValue != null) && (!layoutModels.Contains(curValue)))
                        ((DataGridViewComboBoxCell)row.Cells[colMapTo.Index]).Items.Add(curValue.ToString());

                    ((DataGridViewComboBoxCell)row.Cells[colMapTo.Index]).Items.AddRange(layoutModels.ToArray());
                }
            }
        }

        private string getAssetFullFilePathFromEffect(string effectDefinition)
        {
            string effectAssetType = "";
            if (effectDefinition.Contains("E_FILEPICKERCTRL_Video_Filename"))
                effectAssetType = "E_FILEPICKERCTRL_Video_Filename";
            else if (effectDefinition.Contains("E_FILEPICKER_Pictures_Filename"))
                effectAssetType = "E_FILEPICKER_Pictures_Filename";
            else if (effectDefinition.Contains("E_0FILEPICKERCTRL_IFS"))
                effectAssetType = "E_0FILEPICKERCTRL_IFS";

            return effectDefinition.Substring(effectDefinition.IndexOf(effectAssetType) + effectAssetType.Length + 1,
                effectDefinition.IndexOf(",", effectDefinition.IndexOf(effectAssetType)) - effectDefinition.IndexOf(effectAssetType) - effectAssetType.Length - 1);
        }

        private bool nodeExists(string nodeText, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == nodeText) return true;
                if (node.Text == nodeText) return true;
            }

            return false;
        }

        private void cmdExportShowLM_Click(object sender, EventArgs e)
        {
            ExportShow(sender, e);
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            ExportShow(sender, e);
        }

        private void ExportShow(object sender, EventArgs e)
        {
            // Must have at least one mapping to export
            int i;
            XElement mod;
            string showModel;
            bool noMapping = true;
            IEnumerable<XElement> fx;
            IEnumerable<XElement> fullModel;
            DataGridViewComboBoxCell mapTo;
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                mapTo = (DataGridViewComboBoxCell)row.Cells[colMapTo.Index];
                if (mapTo.Value != null)
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

            // Open show to remap
            // Replace DisplayElements (original models) with models in target show.
            // Remove ElementEffects that are models
            // Add mapped models and submodels back

            //   <Element type="model" name="RosaWreath 2">
            //     <EffectLayer>
            //       <Effect ref="174" name="Shockwave" startTime="16350" endTime="22000" palette="33"/>
            //       <Effect ref="161" name="Shockwave" id="1" startTime="174125" endTime="174600" palette="1"/>
            //       <Effect ref="161" name="Shockwave" id="2" startTime="174600" endTime="175075" palette="1"/>
            //       <Effect ref="161" name="Shockwave" id="3" startTime="175125" endTime="175600" palette="1"/>
            //       <Effect ref="161" name="Shockwave" id="4" startTime="175600" endTime="176075" palette="1"/>
            //     </EffectLayer>
            //     <EffectLayer>
            //       <Effect ref="175" name="Shader" startTime="173175" endTime="175650" palette="1"/>
            //     </EffectLayer>
            //     <SubModelEffectLayer name="Balls Outer">
            //       <Effect ref="90" name="On" startTime="130600" endTime="132550" palette="64"/>
            //       <Effect ref="90" name="On" id="1" startTime="132550" endTime="134450" palette="65"/>
            //       <Effect ref="90" name="On" id="2" startTime="134450" endTime="136375" palette="66"/>
            //       <Effect ref="90" name="On" id="3" startTime="136375" endTime="137325" palette="67"/>
            //       <Effect ref="90" name="On" id="4" startTime="137325" endTime="138275" palette="68"/>
            //     </SubModelEffectLayer>
            //     <SubModelEffectLayer layer="1" name="Balls Outer">
            //       <Effect ref="88" name="On" startTime="6275" endTime="7700" palette="34"/>
            //       <Effect ref="176" name="VU Meter" id="1" startTime="130600" endTime="145950" palette="91"/>
            //     </SubModelEffectLayer>

            // Actually, xLights handles duplicate models gracefully - we can just remove their models, put ours in and then rename their elementeffect model references with our mappings...
            XElement doc = XElement.Load(ShowFileToAdapt);
            XElement rodoc = XElement.Load(ShowFileToAdapt);

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

            foreach (string model in layoutModels)
            {
                doc.Element("DisplayElements").Add(
                    new XElement("Element",
                        new XAttribute("collapsed", "0"),
                        new XAttribute("type", "model"),
                        new XAttribute("name", model),
                        new XAttribute("visible", "1")
                    ));
            }

            var eemodels = from model in doc.Element("ElementEffects").Elements("Element")
                           where (string)model.Attribute("type") == "model"
                           select model;
            eemodels.Remove();

            // Go through the mapped show models and add them
            // Don't need to check for duplicate models - xlights handles this well (at this time).  We can just create a duplicate and let xlights do it's magic.
            foreach (DataGridViewRow row in dgvModels.Rows)
            {
                showModel = row.Cells[colShowModel.Index].Value.ToString();
                mapTo = (DataGridViewComboBoxCell)row.Cells[colMapTo.Index];
                if ((mapTo.Value != null) && (((string)mapTo.Value) != noselection))
                {

                    // Element to hold model to be mapped
                    mod = new XElement("Element");
                    mod.SetAttributeValue("type", "model");
                    mod.SetAttributeValue("name", modelPartofModelName(mapTo.Value.ToString()));

                    fullModel = from layers in rodoc.Elements("ElementEffects").Elements("Element")
                                where (string)layers.Attribute("name") == modelPartofModelName(showModel) &&
                                (string)layers.Attribute("type") == "model"
                                select layers;

                    // If source is model, get all EffectLayer elements
                    // If source is a submodel, get all SubModelEffectLayers for that submodel
                    if (isSubmodel(showModel))
                    {
                        // get all SubmodelEffectLayer elements for this source model
                        fx = from layers in fullModel.Elements("SubModelEffectLayer")
                             where (string)layers.Attribute("name") == submodelPartofModelName(showModel)
                             select layers;

                    }
                    else
                    {
                        // source is a model, grab only EffectLayer elements (ignore submodel elements; those would be mapped if wanted)
                        // get all SubmodelEffectLayer elements for this source model
                        fx = from layers in fullModel.Elements("EffectLayer")
                             select layers;
                    }

                    // Now adjust fx as needed:
                    //  From model, to model, add with no changes
                    //  From model to submodel, replace each EffectLayer with SubModelEffectLayer
                    //  From submodel to model, replace each SubModelEffectLayer with EffectLayers
                    //  From submodel to submodel, update name on SubModelEffectLayer with MapTo submodel part

                    i = 0;
                    foreach (var f in fx)
                    {
                        if (!isSubmodel(showModel) && isSubmodel(mapTo.Value.ToString()))
                        {
                            //  From model to submodel, replace each EffectLayer with SubModelEffectLayer
                            f.Name = "SubModelEffectLayer";
                            f.SetAttributeValue("name", submodelPartofModelName(mapTo.Value.ToString()));

                            if (i > 0)
                            {
                                f.SetAttributeValue("layer", i.ToString());
                            }
                            i++;
                        }
                        else if (isSubmodel(showModel) && !isSubmodel(mapTo.Value.ToString()))
                        {
                            //  From submodel to model, replace each SubModelEffectLayer with EffectLayers and remove other attributes (layer)
                            f.Name = "EffectLayers";
                            f.RemoveAttributes();
                        }
                        else if (isSubmodel(showModel) && isSubmodel(mapTo.Value.ToString()))
                        {
                            //  From submodel to submodel, update name on SubModelEffectLayer with MapTo submodel part and leave layer attribute alone
                            f.SetAttributeValue("name", submodelPartofModelName(mapTo.Value.ToString()));
                        }

                        mod.Add(f);
                    }

                    doc.Element("ElementEffects").Add(new XComment("Adapted from: " + showModel));
                    doc.Element("ElementEffects").Add(mod);
                }
            }

            string adaptedShowPath = assetsPath;
            // create folder and copy asset files if any are found; if directory already exists, will not overwrite.
            if ((chkCopyAssets.Checked) && (assetsPath != null))
            {
                res = MessageBox.Show("A directory folder will be created with the adapted show file to place a copy of assets that were found.  No existing files will be overwritten or modified.  Ok to continue or cancel to skip.", "Create directory and copy assets?", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                {
                    string assetFile;
                    adaptedShowPath = Path.Combine(assetsPath, Path.GetFileNameWithoutExtension(diagSaveFile.FileName));
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
            else
            {
                MessageBox.Show("Please set your asset folder location on the Show Asset Files tab to map and save assets.");
                return;
            }

            if (chkRemapAssets.Checked)
            {
                foreach (TreeNode asset in listShowAssets.Nodes)
                {
                    // look for all EffectDB entries containing one of the asset types (Video, Pictures or Shaders) and my filename
                    var effects = from show in doc.Elements("EffectDB").Elements("Effect")
                                  where ((show.Value.Contains("E_FILEPICKERCTRL_Video_Filename") ||
                                        show.Value.Contains("E_FILEPICKER_Pictures_Filename") ||
                                        show.Value.Contains("E_0FILEPICKERCTRL_IFS")) &&
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

            MessageBox.Show("Show adapted with your mappings.",
                    "Done!", MessageBoxButtons.OK);

            Process.Start("explorer.exe", layoutPath);
        }

        bool isSubmodel(string name)
        {
            if (name.Contains("/"))
                return true;
            else
                return false;
        }

        string modelPartofModelName(string fullname)
        {
            if (fullname.Contains("/"))
                return fullname.Substring(0, fullname.IndexOf("/"));
            else
                return fullname;
        }

        string submodelPartofModelName(string fullname)
        {
            if (fullname.Contains("/"))
                return fullname.Substring(fullname.IndexOf("/") + 1, fullname.Length - fullname.IndexOf("/") - 1);
            else
                return null;
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

        private void chkRemapAssets_CheckedChanged(object sender, EventArgs e)
        {
            linkAssetLocation.Enabled = chkRemapAssets.Checked;
        }

        private void linkAssetLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(assetsPath))
                diagFolderBrowser.SelectedPath = assetsPath;

            diagFolderBrowser.Description = "Where would you like to copy assets such as videos, images, and shaders?";

            DialogResult res = diagFolderBrowser.ShowDialog(Owner);
            if (res == DialogResult.Cancel)
            {
                return;
            }

            assetsPath = diagFolderBrowser.SelectedPath;
            Settings.assetsPath = assetsPath;
            lblAssetLocation.Text = assetsPath;

        }
    }
}
