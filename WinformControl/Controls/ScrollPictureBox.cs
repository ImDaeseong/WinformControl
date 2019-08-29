using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WinformControl.Controls
{
    public partial class ScrollPictureBox : UserControl
    {
        public ScrollPictureBox()
        {
            InitializeComponent();

            panel1.AutoScroll = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            panel1.Controls.Add(pictureBox1);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            InitControlResize();
        }

        private void InitControlResize()
        {
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Height = this.Height - 1;
            pictureBox1.Width = this.Width - 1;
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            if (image != null)
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }
            else
                return null;
        }

        public void SetChangeImageIndex(int nIndex)
        {
            Bitmap bmp = null;

            try
            {
                if (nIndex == 0)
                    bmp = Properties.Resources.type1;
                else if (nIndex == 1)
                    bmp = Properties.Resources.type2;
                else if (nIndex == 2)
                    bmp = Properties.Resources.type3;
                else if (nIndex == 3)
                    bmp = Properties.Resources.type4;

                int nWidht = 360;
                int nHeight = bmp.Height;

                pictureBox1.Image = ResizeImage((Image)bmp, nWidht, nHeight);
                this.Invalidate();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

    }
}
