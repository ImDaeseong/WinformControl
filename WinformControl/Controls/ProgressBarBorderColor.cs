using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    class ProgressBarBorderColor : ProgressBar
    {
        private Color _NormalColor = Color.FromArgb(255, 51, 51);
        private Color _BorderColor = Color.FromArgb(176, 194, 227);

        public ProgressBarBorderColor()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        public Color NormalColor
        {
            get { return _NormalColor; }
            set
            {
                _NormalColor = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var doneProgress = (int)(e.ClipRectangle.Width * ((double)Value / Maximum));
            e.Graphics.FillRectangle(new SolidBrush(NormalColor), 0, 0, doneProgress, e.ClipRectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), doneProgress, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);

            drawBorder(e.Graphics);
        }

        protected void drawBorder(Graphics g)
        {
            Rectangle borderRect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            g.DrawRectangle(new Pen(_BorderColor, 1), borderRect);
        }
    }
}
