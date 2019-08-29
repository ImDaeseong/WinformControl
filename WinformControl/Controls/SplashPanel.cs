using System.Windows.Forms;
using System.Drawing;

namespace WinformControl.Controls
{
    public class SplashPanel : Panel
    {
        private Image _ResourceImage;
        public Image ResourceImage
        {
            get { return _ResourceImage; }
            set
            {
                _ResourceImage = value;
                this.Invalidate();
            }
        }

        public SplashPanel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rc = this.ClientRectangle;
            Graphics g = e.Graphics;

            try
            {
                if (_ResourceImage != null)
                    e.Graphics.DrawImage(_ResourceImage, 0, 0, rc.Width, rc.Height);
            }
            catch { }
        }

        protected override void OnResize(System.EventArgs eventargs)
        {
            this.Refresh();
            base.OnResize(eventargs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ResourceImage.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
