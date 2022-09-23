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
using System.Xml.Linq;

namespace XlightsSequenceAdapter
{
    public partial class frmLORToy : Form
    {
        private const string _allSeqs = "All Props from All Seqs";
        private const string _seqPath = "E:\\xLightsShow\\2022.bjones-Conversion\\SeqRaw\\Audio\\reducedseqs";
        public frmLORToy()
        {
            InitializeComponent();
        }

        private void frmLORToy_Load(object sender, EventArgs e)
        {
            listBoxFoundSeqs.Items.Clear();
            //listBoxProps.Items.Clear();
            txtProps.Text = "";

            listBoxFoundSeqs.Items.Add(_allSeqs);
            getSeqNames(_seqPath);
        }

        private void getSeqNames(string seqPath)
        {
            List<string> lorseqs = Core.FindFiles(seqPath, new List<string> { "loredit" });
            lorseqs.Sort();

            foreach (string lorseq in lorseqs)
            {
                listBoxFoundSeqs.Items.Add(lorseq);
            }
        }

        private void getPropNames(string seqPath)
        {
            List<string> lorseqs;
            if (File.Exists(seqPath))
            {
                lorseqs = new List<string>();
                lorseqs.Add(seqPath);
            }
            else
                lorseqs = Core.FindFiles(_seqPath, new List<string> { "loredit" });

            XElement doc;
            List<String> layoutModels = new List<String>();
            foreach (string lorseq in lorseqs)
            {
                doc = XElement.Load(lorseq);
                foreach(XElement xEle in doc.Descendants("SeqProp"))
                {
                    if (!layoutModels.Contains(xEle.Attribute("name").Value))
                        layoutModels.Add(xEle.Attribute("name").Value);
                }
            }

            layoutModels.Sort();
            txtProps.Text = "";
            foreach (string lorseq in layoutModels)
            {
                txtProps.AppendText($"{(String)lorseq}\r\n");
                //txtProps.AppendText();
                //txtProps.AppendText(Environment.NewLine);
            }
        }

        private void listBoxFoundSeqs_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPropNames(listBoxFoundSeqs.SelectedItem.ToString());
        }
    }
}
