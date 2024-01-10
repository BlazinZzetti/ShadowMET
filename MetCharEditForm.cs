using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;

namespace ShadowMET
{
    public partial class MetCharEditForm : Form
    {
        private Bitmap metPicture;
        private MetCharInfo _metCharInfo;
        private bool updateAllowed;
        
        public class MetCharInfoEventArg
        {
            public MetCharInfo MetCharInfo;
        }

        public EventHandler<MetCharInfoEventArg> ConfirmEditEventHandler;
        
        public MetCharEditForm(Bitmap currentMetPicture, MetCharInfo charInfo)
        {
            InitializeComponent();
            metPicture = currentMetPicture;
            _metCharInfo = charInfo;

            updateAllowed = false;

            UnicodeTextBox.Text = _metCharInfo.UnicodeChar.ToString();
            PosXUpDown.Value = _metCharInfo.PositionX;
            PosYUpDown.Value = _metCharInfo.PositionY;
            SizeXUpDown.Value = _metCharInfo.SizeX;
            SizeYUpDown.Value = _metCharInfo.SizeY;
            
            UpdatePreview();
            updateAllowed = true;
        }

        public void UpdatePreview()
        {
            var editResolutionBase = new Vector2((int)SizeXUpDown.Value, (int)SizeYUpDown.Value);
            var editScale = 8;
            var editWindow = editResolutionBase * editScale;
            var processedMetImage = new Bitmap((int)editWindow.X, (int)editWindow.Y);
            
            MetPictureBox.Image = null;
            MetPictureBox.Width = (int)SizeXUpDown.Value * editScale;
            MetPictureBox.Height = (int)SizeYUpDown.Value * editScale;
            
            using (Graphics g = Graphics.FromImage(processedMetImage))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                
                //Scale to 240x240
                g.ScaleTransform(editScale,editScale);

                g.DrawImage(metPicture, -(int)PosXUpDown.Value, -(int)PosYUpDown.Value, metPicture.Width, metPicture.Height);
            }
            
            using (Graphics g = Graphics.FromImage(processedMetImage))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                
                //Draw Grid Lines to clearly show individual pixels.
                //Two separate Loops to account for rectangular sizes.
                for (int y = 0; y < editResolutionBase.Y; y++)
                {
                    g.DrawLine(new Pen(Color.FromArgb(64, Color.Red), 1), 0, y*editScale, editWindow.X, y*editScale);
                }
                
                for (int x = 0; x < editResolutionBase.X; x++)
                {
                    g.DrawLine(new Pen(Color.FromArgb(64, Color.Red), 1), x*editScale, 0, x*editScale, editWindow.Y);
                }
            }

            MetPictureBox.Image = processedMetImage;
        }
        
        private void MetValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (updateAllowed)
            {
                UpdatePreview();
            }
        }
        
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //TODO: Check for Invalid MET data.
            ConfirmEditEventHandler.Invoke(this, new MetCharInfoEventArg()
            {
                MetCharInfo = new MetCharInfo()
                {
                    UnicodeChar = UnicodeTextBox.Text[0],
                    PositionX = (short)PosXUpDown.Value,
                    PositionY = (short)PosYUpDown.Value,
                    SizeX = (short)SizeXUpDown.Value,
                    SizeY = (short)SizeYUpDown.Value,
                    Comment = ""
                }
            });
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}