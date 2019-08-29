using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinformControl.Controls
{
    public partial class RoundedPanel : Panel
    {
        private Int32 borderWidth = 1;
        private Int32 radius = 2;

        private Color borderColor = Color.Black;
        private Color backColor = Color.White;

        public Int32 BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        public Int32 Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public Color NormalColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        public RoundedPanel()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle newRect = new Rectangle(ClientRectangle.X + borderWidth, ClientRectangle.Y + borderWidth, ClientRectangle.Width - 2 * borderWidth, ClientRectangle.Height - 2 * borderWidth);
            GraphicsPath button = DrawRoundedRectangle(radius, newRect);

            e.Graphics.FillPath(new SolidBrush(backColor), button);
            e.Graphics.DrawPath(new Pen(borderColor, borderWidth), button);
        }

        private static GraphicsPath DrawRoundedRectangle(int radius, Rectangle newRectangle)
        {
            GraphicsPath gp = new GraphicsPath();
            int diameter = radius * 2;
            int d = diameter;
            gp.AddArc(newRectangle.X, newRectangle.Y, d, d, 180, 90);
            gp.AddArc(newRectangle.X + newRectangle.Width - d, newRectangle.Y, d, d, 270, 90);
            gp.AddArc(newRectangle.X + newRectangle.Width - d, newRectangle.Y + newRectangle.Height - d, d, d, 0, 90);
            gp.AddArc(newRectangle.X, newRectangle.Y + newRectangle.Height - d, d, d, 90, 90);
            gp.AddLine(newRectangle.X, newRectangle.Y + newRectangle.Height - d, newRectangle.X, newRectangle.Y + d / 2);
            return gp;
        }
    }
}
