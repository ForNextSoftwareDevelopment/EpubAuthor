using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace EpubAuthor
{
    public partial class MainForm : Form
    {
        #region Members

        string defaultPath = @"C:\\";

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            folderBrowserDialog.SelectedPath = defaultPath;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Select folder to process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                defaultPath = folderBrowserDialog.SelectedPath;
                tbFolder.Text = defaultPath;
                ProcessFiles(false);
            }
        }

        // Convert files and save
        private void btnStart_Click(object sender, EventArgs e)
        {
            ProcessFiles(true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process all opf files
        /// </summary>
        /// <param name="convert"></param>
        private void ProcessFiles(bool convert)
        {
            // Clear datagridview
            dgvFiles.Rows.Clear();
            dgvFiles.Columns.Clear();

            // Create columns
            dgvFiles.Columns.Add("path", "Path");
            dgvFiles.Columns["path"].Visible = false;
            dgvFiles.Columns.Add("file", "File");
            dgvFiles.Columns.Add("title", "Title");
            dgvFiles.Columns.Add("author", "Author");

            // Get all epub files in the folder
            string[] allFiles = Directory.GetFiles(tbFolder.Text, "*.epub");

            string[] temp = tbFolder.Text.Split('\\');
            string newAuthor = temp[temp.Length - 1];

            if (allFiles.Length > 0)
            {
                FormProgress progress = new FormProgress();
                int numBook = 0;
                progress.SetValue(numBook, allFiles.Length);
                progress.Show();

                foreach (string file in allFiles)
                {
                    string opfFile = "";
                    temp = file.Split("\\");
                    string fileName = temp[temp.Length - 1];
                    string title = "";
                    string author = "";
                    string opf = "";
                    string line = "";

                    ZipArchive zipArchive = null;
                    XmlDocument xmlDocument = null;

                    // Open epub file (as a zip)
                    try
                    {
                        if (convert)
                        {
                            zipArchive = ZipFile.Open(file, ZipArchiveMode.Update);
                        } else
                        {
                            zipArchive = ZipFile.OpenRead(file);
                        }
                    } catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message + "\r\nThis ebook cannot be opened: " + fileName + "\r\nProcessing aborted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (zipArchive == null)
                    {
                        MessageBox.Show("ERROR: This ebook cannot be opened: " + fileName + "\r\nProcessing aborted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Open container xml (to locate content.opf)
                    ZipArchiveEntry contentEntry = null;
                    foreach (ZipArchiveEntry entry in zipArchive.Entries)
                    {
                        if (entry.FullName.ToLower() == "meta-inf/container.xml")
                        {
                            ZipArchiveEntry containerEntry = entry;
                            Stream stream = containerEntry.Open();
                            StreamReader streamReader = new StreamReader(stream);

                            string container = "";
                            line = "";
                            while (line != null)
                            {
                                if (line != "") container += line + "\r\n";
                                line = streamReader.ReadLine();
                            }

                            streamReader.Close();
                            stream.Close();

                            // Convert to XML
                            xmlDocument = new XmlDocument();
                            try
                            {
                                xmlDocument.LoadXml(container);
                            } catch (Exception ex)
                            {
                                MessageBox.Show("WARNING: " + ex.Message + "\r\nThis ebook has no valid container file: " + fileName, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            XmlNodeList nodeList;

                            // Get opf file full path
                            try
                            {
                                nodeList = xmlDocument.GetElementsByTagName("rootfile");
                                foreach (XmlNode node in nodeList)
                                {
                                    string outerXml = node.OuterXml;
                                    if (outerXml.Contains("full-path="))
                                    {
                                        int posStart = outerXml.IndexOf("full-path=") + 11;
                                        int posEnd = outerXml.IndexOf("\"", posStart + 11);
                                        opfFile = outerXml.Substring(posStart, posEnd - posStart);
                                    }
                                }
                                
                                // If found then read opf file
                                if (opfFile != "")
                                {
                                    contentEntry = zipArchive.GetEntry(opfFile);

                                    if (contentEntry != null)
                                    {
                                        Stream opfStream = contentEntry.Open();
                                        StreamReader opfStreamReader = new StreamReader(opfStream);

                                        line = "";
                                        while (line != null)
                                        {
                                            opf += line;
                                            line = opfStreamReader.ReadLine();
                                        }

                                        opfStreamReader.Close();
                                        opfStream.Close();
                                    }
                                }
                            } catch (Exception ex)
                            {
                                MessageBox.Show("WARNING: " + ex.Message + "\r\nCan't read container file of: " + fileName, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    // If not found then just search for .opf files and read first one
                    if (contentEntry == null)
                    {
                        foreach (ZipArchiveEntry entry in zipArchive.Entries)
                        {
                            if (entry.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase))
                            {
                                opfFile = entry.FullName;
                                contentEntry = entry;
                                Stream stream = contentEntry.Open();
                                StreamReader streamReader = new StreamReader(stream);

                                line = "";
                                while (line != null)
                                {
                                    opf += line;
                                    line = streamReader.ReadLine();
                                }

                                streamReader.Close();
                                stream.Close();

                                // Only first one 
                                break;
                            }
                        }
                    }

                    // Convert to XML
                    bool skip = false;
                    xmlDocument = new XmlDocument();
                    try
                    {
                        xmlDocument.LoadXml(opf);
                    } catch (Exception ex)
                    {
                        MessageBox.Show("WARNING: " + ex.Message + "\r\nThis ebook has no valid opf file: " + fileName, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        skip = true;
                    }

                    if (!skip)
                    {
                        XmlNodeList nodeList;

                        // Get title
                        try
                        {
                            nodeList = xmlDocument.GetElementsByTagName("dc:title");
                            foreach (XmlNode node in nodeList)
                            {
                                title += node.InnerText;
                            }
                        } catch (Exception ex)
                        {
                            MessageBox.Show("ERROR: " + ex.Message + "\r\nCan't get title of: " + fileName, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // If conversion is true, then delete all author nodes and replace with a new one
                        if (convert)
                        {
                            nodeList = xmlDocument.GetElementsByTagName("dc:creator");

                            XmlNode parenNode = null;
                            string nameSpace = "";
                            while (nodeList.Count > 0)
                            {
                                // Delete node
                                parenNode = nodeList[0].ParentNode;
                                nameSpace = nodeList[0].GetNamespaceOfPrefix("dc");
                                parenNode.RemoveChild(nodeList[0]);
                                nodeList = xmlDocument.GetElementsByTagName("dc:creator");
                            }

                            // Add one
                            if (parenNode == null) parenNode = xmlDocument.DocumentElement;
                            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);

                            string tmp = "";
                            do
                            {
                                foreach (String prefix in xmlNamespaceManager)
                                {
                                    tmp += String.Format("Prefix={0}, Namespace={1}\r\n", prefix, xmlNamespaceManager.LookupNamespace(prefix));
                                }
                            }
                            while (xmlNamespaceManager.PopScope());

                            XmlElement newElement = xmlDocument.CreateElement("dc:creator", nameSpace);
                            newElement.SetAttribute("opf:role", "aut");
                            newElement.SetAttribute("opf:file-as", newAuthor);
                            newElement.InnerText = newAuthor;
                            parenNode.PrependChild(newElement);

                            // Delete old 'opf' entry
                            contentEntry.Delete();

                            // Insert new 'opf' entry
                            if (opfFile == "") opfFile = "content.opf";
                            contentEntry = zipArchive.CreateEntry(opfFile);

                            // Write xml
                            StreamWriter streamWriter = new StreamWriter(contentEntry.Open());
                            xmlDocument.Save(streamWriter);
                            streamWriter.Close();
                        }

                        // Close zip
                        zipArchive.Dispose();

                        // Get author
                        try
                        {
                            nodeList = xmlDocument.GetElementsByTagName("dc:creator");
                            foreach (XmlNode node in nodeList)
                            {
                                if (author != "") author += " / ";
                                author += node.InnerText;
                            }
                        } catch (Exception ex)
                        {
                            MessageBox.Show("WARNING: " + ex.Message + "\r\nCan't get author of: " + fileName, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Add to datagridview
                        dgvFiles.Rows.Add(file, fileName, title, author);
                    }

                    numBook++;
                    progress.SetValue(numBook, allFiles.Length);
                    Application.DoEvents();
                }

                progress.Close();
            }

            // Make file fully visible
            dgvFiles.Columns["file"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        #endregion
    }
}
