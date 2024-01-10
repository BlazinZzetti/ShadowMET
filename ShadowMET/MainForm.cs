using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadowMET
{
    public partial class MainForm : Form
    {
        public string FontFolderPath;
        public List<MetFileInfo> MetFileInfos = new List<MetFileInfo>();

        public MetFileInfo CurrentMetFile;
        public Bitmap CurrentMetPicture;
        
        public MainForm()
        {
            InitializeComponent();
            ResetControls();
        }

        private void ProcessFontFolderPath()
        {
            AvailableMetsComboBox.Items.Clear();
            AvailableMetsComboBox.ResetText();
            unicodeSelectionComboBox.Items.Clear();
            unicodeSelectionComboBox.ResetText();
            EditCharButton.Enabled = false;
            AddCharButton.Enabled = false;
            
            MetFileInfos.Clear();
            if (!String.IsNullOrEmpty(FontFolderPath))
            {
                var fontDirectory = new DirectoryInfo(FontFolderPath);
                GetMetFiles(fontDirectory);
            }

            ResetControls();
            if (MetFileInfos.Count > 0)
            {
                foreach (var metFile in MetFileInfos)
                {
                    AvailableMetsComboBox.Items.Add(metFile.ImageName);
                    AvailableMetsComboBox.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("No .met files found.");
            }
        }

        private void ResetControls()
        {
            AvailableMetsComboBox.Items.Clear();
            AvailableMetsComboBox.Enabled = false;
            unicodeSelectionComboBox.Items.Clear();
            unicodeSelectionComboBox.Enabled = false;
            MetPictureBox.Image = null;
            MetPictureBox.ImageLocation = null;
            EditCharButton.Enabled = false;
            AddCharButton.Enabled = false;
        }

        private void GetMetFiles(DirectoryInfo currentDirectory)
        {
            if (currentDirectory.Exists)
            {
                foreach (var folderInfo in currentDirectory.EnumerateDirectories())
                {
                    GetMetFiles(folderInfo);
                }
                foreach (var file in currentDirectory.EnumerateFiles())
                {
                    if (file.Extension == ".met")
                    {
                        MetFileInfos.Add(ParseMetFile(file));
                    }
                }
            }
        }

        private MetFileInfo ParseMetFile(FileInfo file)
        {
            var metFile = new MetFileInfo();
            metFile.FileInfo = file;
            
            var headerCheck = false;
            var imageNameCheck = false;
            var parameterCheck = false;
            
            // Use a using statement to ensure that the StreamReader is properly closed and disposed of
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string currentLine;

                // Read and display lines from the file until the end of the file is reached
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(currentLine) || !string.IsNullOrWhiteSpace(currentLine))
                    {
                        //Check if header info has been processed.
                        if (!headerCheck || !imageNameCheck || !parameterCheck)
                        {
                            if (!headerCheck && currentLine == "METRICS1")
                            {
                                headerCheck = true;
                                continue;
                            }

                            if (headerCheck)
                            {
                                if (!imageNameCheck && string.IsNullOrEmpty(metFile.ImageName))
                                {
                                    metFile.ImageName = currentLine;
                                    imageNameCheck = true;
                                    continue;
                                }

                                if (imageNameCheck)
                                {
                                    //Assume 0 == not initialized.
                                    //At least for Shadow, this should always be 5.
                                    //Heroes had at least one with a 3.
                                    if (!parameterCheck && metFile.Parameter == 0)
                                    {
                                        metFile.Parameter = byte.Parse(currentLine);
                                        parameterCheck = true;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }


                        var metCharInfo = new MetCharInfo();

                        var metInfoLineSplit = currentLine.Split('#');

                        if (metInfoLineSplit.Length > 1)
                        {
                            //TODO: Determine if this can be more than 1 char long
                            metCharInfo.Comment = metInfoLineSplit[1];
                        }

                        var metCharDataLineSplit =
                            metInfoLineSplit[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        metCharInfo.UnicodeChar = (char)Int32.Parse(metCharDataLineSplit[0]);
                        var metCharDataLineBytes = new byte[]
                        {
                            byte.Parse(metCharDataLineSplit[1]),
                            byte.Parse(metCharDataLineSplit[2]),
                            byte.Parse(metCharDataLineSplit[3]),
                            byte.Parse(metCharDataLineSplit[4])
                        };

                        metCharInfo.PositionX = metCharDataLineBytes[0];
                        metCharInfo.PositionY = metCharDataLineBytes[1];
                        metCharInfo.SizeX = (byte)(metCharDataLineBytes[2] - metCharDataLineBytes[0]);
                        metCharInfo.SizeY = (byte)(metCharDataLineBytes[3] - metCharDataLineBytes[1]);

                        metFile.CharInfos.Add(metCharInfo);
                    }
                }
            }

            return metFile;
        }

        private void SaveMetFile(MetFileInfo currentMetFile)
        {
            using (StreamWriter writer = new StreamWriter(currentMetFile.FileInfo.FullName))
            {
                writer.NewLine = "\n";
                //File Header
                writer.WriteLine("METRICS1");
                writer.WriteLine(currentMetFile.ImageName);
                writer.WriteLine(5);
                
                //Char Infos
                foreach (var metCharInfo in currentMetFile.CharInfos)
                {
                    var unicodeIndexString = ((int)metCharInfo.UnicodeChar).ToString().PadLeft(5);
                    var posXString = metCharInfo.PositionX.ToString().PadLeft(4); //Space for 3 digits + space
                    var posYString = metCharInfo.PositionY.ToString().PadLeft(4); //Space for 3 digits + space
                    var sizeXString = (metCharInfo.PositionX + metCharInfo.SizeX).ToString().PadLeft(4); //Space for 3 digits + space
                    var sizeYString = (metCharInfo.PositionY + metCharInfo.SizeY).ToString().PadLeft(4); //Space for 3 digits + space
                    
                    writer.WriteLine(unicodeIndexString + posXString + posYString + sizeXString + sizeYString + " #" /*+Comment?*/);
                }
                //WriteLine to end file.
                writer.WriteLine(); 
            }
            MessageBox.Show("Saved: " + currentMetFile.FileInfo.Name);
        }
        
        private void SetFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    FontFolderPath = fbd.SelectedPath;
                }
            }

            ProcessFontFolderPath();
        }

        private void AvailableMetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvailableMetsComboBox.Enabled)
            {
                var fileName = (string)AvailableMetsComboBox.SelectedItem;
                CurrentMetFile = MetFileInfos.Find(m => m.ImageName == fileName);
                MetPictureBox.Image = null;

                try
                {
                    CurrentMetPicture = new Bitmap(CurrentMetFile.FileInfo.DirectoryName + "\\" + fileName + ".png");
                    MetPictureBox.Image = ProcessMetImage(CurrentMetPicture);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("PNG file Missing");
                }
                
                unicodeSelectionComboBox.Items.Clear();
                unicodeSelectionComboBox.ResetText();
                EditCharButton.Enabled = false;
                foreach (var charInfo in CurrentMetFile.CharInfos)
                {
                    unicodeSelectionComboBox.Enabled = true;
                    unicodeSelectionComboBox.Items.Add(charInfo.UnicodeChar);
                }
            }
        }

        private Image ProcessMetImage(Image originalImage)
        {
            var processedImage = new Bitmap(512, 512);
            
            using (Graphics g = Graphics.FromImage(processedImage))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.DrawImage(originalImage, 0, 0, 512, 512);
            }
            
            return processedImage;
        }

        private void unicodeSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baseImage = ProcessMetImage(CurrentMetPicture);
            
            if (unicodeSelectionComboBox.SelectedIndex > -1
                && unicodeSelectionComboBox.SelectedIndex < unicodeSelectionComboBox.Items.Count)
            {
                EditCharButton.Enabled = true;
                var charData = CurrentMetFile.CharInfos[unicodeSelectionComboBox.SelectedIndex];
                using (Graphics g = Graphics.FromImage(baseImage))
                {
                    //Pen will draw around the char region showing every
                    //pixel that would be rendered to the screen.
                    g.DrawRectangle(new Pen(Color.Magenta, 2),
                        (charData.PositionX * 2) - 2,
                        (charData.PositionY * 2) - 2,
                        (charData.SizeX * 2) + 4,
                        (charData.SizeY * 2) + 4);
                }
            }

            MetPictureBox.Image = baseImage;

        }

        private void EditCharButton_Click(object sender, EventArgs e)
        {
            var editDialog = new MetCharEditForm(CurrentMetPicture, CurrentMetFile.CharInfos[unicodeSelectionComboBox.SelectedIndex]);
            editDialog.ConfirmEditEventHandler += EditConfirmAction;
            editDialog.ShowDialog();
            editDialog.ConfirmEditEventHandler -= EditConfirmAction;
        }

        private void EditConfirmAction(object sender, MetCharEditForm.MetCharInfoEventArg e)
        {
            CurrentMetFile.CharInfos[unicodeSelectionComboBox.SelectedIndex] = e.MetCharInfo;
            SaveMetFile(CurrentMetFile);
            MetPictureBox.Image = ProcessMetImage(CurrentMetPicture);
        }
    }
}