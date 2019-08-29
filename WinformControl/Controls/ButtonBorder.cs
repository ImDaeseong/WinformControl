using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinformControl.Controls
{
    public class ButtonBorder : Button
    {
        private Color _BackColor = Color.FromArgb(250, 250, 250);
        private Color _TextColor = Color.FromArgb(51, 51, 51);
        private Color _BorderColor = Color.FromArgb(219, 224, 235);
        StringFormat sf;

        public ButtonBorder()
        {
            SetStyle(ControlStyles.UserPaint, true);
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            using (SolidBrush backgroundBrush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(backgroundBrush, this.ClientRectangle);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle outerRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

            using (GraphicsPath outerPath = RoundedRectangle(outerRect, 0, 0))
            {
                g.FillPath(new SolidBrush(_BackColor), outerPath);

                Pen grayPen = new Pen(_BorderColor);
                g.DrawPath(grayPen, outerPath);
            }

            TextRenderer.DrawText(g, this.Text, this.Font, outerRect, _TextColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
        {
            int nSize = 1;
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddLine(boundingRect.Right, boundingRect.Top, boundingRect.Right, boundingRect.Bottom - (nSize / 2));
            roundedRect.AddArc(new Rectangle((boundingRect.Right - nSize), (boundingRect.Bottom - nSize), nSize, nSize), 0, 90);
            roundedRect.AddLine(boundingRect.Right - (nSize / 2), boundingRect.Bottom, boundingRect.Left + (nSize / 2), boundingRect.Bottom);
            roundedRect.AddArc(new Rectangle(boundingRect.Left, (boundingRect.Bottom - nSize), nSize, nSize), 90, 90);
            roundedRect.AddLine(boundingRect.Left, boundingRect.Bottom - (nSize / 2), boundingRect.Left, boundingRect.Top);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
