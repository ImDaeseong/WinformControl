using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WinformControl.Controls
{
    public class PictureBoxEx : PictureBox
    {
        private int ImgSize = 50;

        public PictureBoxEx()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            this.Width = ImgSize;
            this.Height = ImgSize;
        }

        private Image _ResourceImage;
        public Image ResourceImage
        {
            get { return _ResourceImage; }
            set
            {
                _ResourceImage = ResizeImage(value, this.Width, this.Height);
                this.Invalidate();
            }
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            if (_ResourceImage != null)
            {
                g.DrawImage(_ResourceImage, 0, 0, this.Width, this.Height);
            }
        }
    }
}
