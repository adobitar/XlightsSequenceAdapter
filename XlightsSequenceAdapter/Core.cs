using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XlightsSequenceAdapter
{
    public static class Settings
    {
        public const string LAYOUTFILE = "xlights_rgbeffects.xml";
        public const string NOSELECTION = "- None Selected -";
        public const string HELPFILE = "xLightsAdapterHelp.rtf";

        public static string layoutPath
        {
            get
            { return getSetting("layoutPath"); }

            set
            { writeSetting("layoutPath", value); }
        }

        public static string sharedPath
        {
            get
            { return getSetting("sharedPath"); }

            set
            { writeSetting("sharedPath", value); }
        }

        public static bool AlwaysOpenBrowserOnLoad
        {
            get
            { 
                string x = getSetting("AlwaysOpenBrowserOnLoad");
                bool r;
                if (!bool.TryParse(x, out r))
                    r = false;

                return r;
            }

            set
            { writeSetting("AlwaysOpenBrowserOnLoad", value.ToString()); }
        }

        public static string vsimglibpath
        {
            get
            { return getSetting("vsimglibpath"); }

            set
            { writeSetting("vsimglibpath", value); }
        }

        private static string getSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? "";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings: " + key);
            }

            return "";
        }

        private static void writeSetting(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings: " + key + " = " + value);
            }
        }
    }

    public class XSEQ : INotifyPropertyChanged
    {
        /// <summary>
        /// Sequence filename with full path and extension
        /// </summary>
        public string FileFullname { get; set; }

        /// <summary>
        /// Sequence file name not including path or extension (same as Path.GetFileName())
        /// </summary>
        public string Filename { get { return Path.GetFileName(FileFullname); } }

        /// <summary>
        /// Sequence file path (same as Path.GetDirectoryName())
        /// </summary>
        public string Filepath { get { return Path.GetDirectoryName(FileFullname); } }

        public string XLightsVersion { get; set; }
        public string Author { get; set; }
        [DisplayName("Author Email")]
        public string AuthorEmail { get; set; }
        [DisplayName("Author Website")]
        public string AuthorWebsite { get; set; }
        public string Song { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        [DisplayName("Music URL")]
        public string MusicURL { get; set; }
        [DisplayName("Author Comment")]
        public string AuthorComment { get; set; }
        [DisplayName("Sequence Timing")]
        public string SequenceTiming { get; set; }
        [DisplayName("Sequence Type")]
        public string SequenceType { get; set; }
        [DisplayName("Media File")]
        public string MediaFile { get; set; }
        [DisplayName("Sequence Duration")]
        public string SequenceDuration { get; set; }
        [DisplayName("Image Dir")]
        public string ImageDir { get; set; }
        public List<string> ModelDisplayElements { get; set; }
        public string ParseWarning { get; set; }

        public string XLAFile { get { return Path.Combine(Path.GetDirectoryName(FileFullname), Path.GetFileNameWithoutExtension(FileFullname)) + ".xla"; } }

        private string _cat;
        private string _credit;
        private string _vidURL;
        private string _shareSource;
        private string _shareURL;
        private string _notes;

        public string Category 
        { 
            get { return _cat; }

            set { 
                if (_cat != value)
                {
                    _cat = value;
                    OnPropertyChanged();
                }
            } 
        }

        public string Credit
        {
            get { return _credit; }

            set
            {
                if (_credit != value)
                {
                    _credit = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Video URL")]
        public string VideoURL
        {
            get { return _vidURL; }

            set
            {
                if (_vidURL != value)
                {
                    _vidURL = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Share Source")]
        public string ShareSource
        {
            get { return _shareSource; }

            set
            {
                if (_shareSource != value)
                {
                    _shareSource = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Share URL")]
        public string ShareURL
        {
            get { return _shareURL; }

            set
            {
                if (_shareURL != value)
                {
                    _shareURL = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Notes
        {
            get { return _notes; }

            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged();
                }
            }
        }

        public XSEQ(string fullFileName)
        {
            ModelDisplayElements = new List<string>();
            FileFullname = fullFileName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class Core
    {
        public static System.Drawing.Icon ToIcon(this System.Drawing.Image instance)
        {
            using (System.Drawing.Bitmap bm = (System.Drawing.Bitmap)instance)
            {
                return System.Drawing.Icon.FromHandle(bm.GetHicon());
            }
        }

        /// <summary>
        /// Return list of files under provide path location matching extension that are not protected xLights files (keybindings, networks, rgbeffects) or in junk directories (backup, MACOSX).
        /// </summary>
        /// <param name="path">The location to start search (c:\shows\shared)</param>
        /// <param name="extensions">ie: var ext = new List<string> { "xml", "xsq" };</param>
        /// <returns></returns>
        public static List<string> FindFiles(string path, List<string> extensions)
        {
            // var ext = new List<string> { "xml", "xsq" };
            var myFiles = Directory
                .EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));

            List<string> ret = new List<string>();

            string canFile;
            foreach (string file in myFiles)
            {
                // Ignore:
                //      xlights_keybindings.xml
                //      xlights_networks.xml
                //      xlights_rgbeffects.xml
                //      containing \Backup\ in path

                canFile = Path.GetFileName(file);

                if ((canFile == "xlights_keybindings.xml") || (canFile == "xlights_rgbeffects.xml") || (canFile == "xlights_networks.xml"))
                {
                    // ignore it
                }
                else if ((file.Contains("\\Backup\\")) || (file.Contains("\\__MACOSX\\")))
                {
                    // ignore it
                }
                else
                    ret.Add(file);
            }

            return ret;
        }

        public static List<string> GetXSEQNames(string path)
        {
            return FindFiles(path, new List<string> { "xml", "xsq" });
        }

        /// <summary>
        /// Refreshes list and metadata for all sequences under provided path.  
        /// </summary>
        /// <param name="path">The location to start search (c:\shows\shared)</param>
        /// <returns></returns>
        public static List<XSEQ> GetXSEQList(List<string> xseqlist, IProgress<int> progress)
        {
            if (progress == null)
                progress = new Progress<int>();

            int i = 0;
            List<XSEQ> ret = new List<XSEQ>();
            foreach (string file in xseqlist)
            {
                progress.Report(++i);
                XSEQ seq = new XSEQ(file);
                seq = getXSEQMeta(seq);
                ret.Add(seq);
            }
            return ret;
        }

        public static XSEQ getXSEQMeta(XSEQ seq)
        {
            if (!File.Exists(seq.FileFullname))
            {
                seq.ParseWarning = "OS reports file does not exist.  Perhaps you need to enable NTFS long paths using group policy.";
                return seq;
            }

            XElement doc;
            try
            {
                doc = XElement.Load(seq.FileFullname);

                if (doc.Element("head") == null)
                {
                    seq.ParseWarning = "Missing sequence metadata";
                    return seq;
                }

                if (doc.Elements("head").Any() && doc.Element("head").Elements("version").Any())
                        seq.XLightsVersion = elementValue(doc.Element("head").Element("version"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("author").Any())
                    seq.Author = elementValue(doc.Element("head").Element("author"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("author-email").Any())
                    seq.AuthorEmail = elementValue(doc.Element("head").Element("author-email"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("author-website").Any())
                    seq.AuthorWebsite = elementValue(doc.Element("head").Element("author-website"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("comment").Any())
                    seq.AuthorComment = elementValue(doc.Element("head").Element("comment"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("sequenceType").Any())
                    seq.SequenceType = elementValue(doc.Element("head").Element("sequenceType"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("sequenceTiming").Any())
                    seq.SequenceTiming = elementValue(doc.Element("head").Element("sequenceTiming"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("sequenceDuration").Any())
                    seq.SequenceDuration = elementValue(doc.Element("head").Element("sequenceDuration"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("artist").Any())
                    seq.Artist = elementValue(doc.Element("head").Element("artist"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("album").Any())
                    seq.Album = elementValue(doc.Element("head").Element("album"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("song").Any())
                    seq.Song = elementValue(doc.Element("head").Element("song"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("mediaFile").Any())
                    seq.MediaFile = elementValue(doc.Element("head").Element("mediaFile"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("MusicURL").Any())
                    seq.MusicURL = elementValue(doc.Element("head").Element("MusicURL"));

                if (doc.Elements("head").Any() && doc.Element("head").Elements("imageDir").Any())
                    seq.ImageDir = elementValue(doc.Element("head").Element("imageDir"));

            } catch (Exception ex) {
                seq.ParseWarning = "Possible sequence error: " + ex.Message;
                return seq;
            }

            // Add models that are in use which may be interesting info somehow
            var demodels = from model in doc.Elements("DisplayElements").Elements("Element")
                           where (string)model.Attribute("type") == "model"
                           select model;
            foreach(var model in demodels)
            {
                seq.ModelDisplayElements.Add(model.Attribute("name").Value);
            }

            seq.ModelDisplayElements.Sort();

            // Grab info from XLA file if one exists
            if (!File.Exists(seq.XLAFile))
                return seq; 

            try
            {
                doc = XElement.Load(seq.XLAFile);

                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("Category").Any())
                    seq.Category = elementValue(doc.Element("sequence").Element("Category"));

                
                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("Credit").Any())
                    seq.Category = elementValue(doc.Element("sequence").Element("Credit"));

                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("VideoURL").Any())
                    seq.VideoURL = elementValue(doc.Element("sequence").Element("VideoURL"));

                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("Notes").Any())
                    seq.Notes = elementValue(doc.Element("sequence").Element("Notes"));

                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("ShareSource").Any())
                    seq.ShareSource = elementValue(doc.Element("sequence").Element("ShareSource"));

                if (doc.Elements("sequence").Any() && doc.Element("sequence").Elements("ShareURL").Any())
                    seq.ShareURL = elementValue(doc.Element("sequence").Element("ShareURL"));
            }
            catch (Exception ex)
            {
                seq.ParseWarning = "Possible XLA file error: " + ex.Message;
                return seq;
            }

            return seq;
        }

        private static string elementValue(XElement x)
        {
            if (x != null)
                return x.Value;
            else
                return "";
        }

        /// <summary>
        /// Removes working path from file and trims leading slash if appropriate
        /// </summary>
        /// <param name="file"></param>
        /// <param name="workingPath"></param>
        /// <returns></returns>
        public static string ShortPath(string file, string workingPath)
        {
            if (file.Contains(workingPath))
            {
                string f = file.Substring(workingPath.Length);
                if (f.StartsWith("\\") || f.StartsWith("/"))
                    f = f.Substring(1);
                return f;
            }
            else
                return file;
        }

        public static void saveXLA(XSEQ seq)
        {
            XElement doc;
            if (!File.Exists(seq.XLAFile))
            {
                // create new file
                doc = new XElement("xlightsadapter");
            }
            else
            {
                doc = XElement.Load(seq.XLAFile);
            }

            // add/update xlafile details and save
            if (!doc.Elements("sequence").Any())
                doc.Add(new XElement("sequence"));

            if (!doc.Element("sequence").Elements("Category").Any())
                doc.Element("sequence").Add(new XElement("Category"));
            doc.Element("sequence").Element("Category").Value = seq.Category + "";

            if (!doc.Element("sequence").Elements("Credit").Any())
                doc.Element("sequence").Add(new XElement("Credit"));
            doc.Element("sequence").Element("Credit").Value = seq.Credit + "";

            if (!doc.Element("sequence").Elements("VideoURL").Any())
                doc.Element("sequence").Add(new XElement("VideoURL"));
            doc.Element("sequence").Element("VideoURL").Value = seq.VideoURL + "";

            if (!doc.Element("sequence").Elements("Notes").Any())
                doc.Element("sequence").Add(new XElement("Notes"));
            doc.Element("sequence").Element("Notes").Value = seq.Notes + "";

            if (!doc.Element("sequence").Elements("ShareSource").Any())
                doc.Element("sequence").Add(new XElement("ShareSource"));
            doc.Element("sequence").Element("ShareSource").Value = seq.ShareSource + "";

            if (!doc.Element("sequence").Elements("ShareURL").Any())
                doc.Element("sequence").Add(new XElement("ShareURL"));
            doc.Element("sequence").Element("ShareURL").Value = seq.ShareURL + "";

            doc.Save(seq.XLAFile);
        }
    }
}
