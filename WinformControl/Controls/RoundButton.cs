using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WinformControl.Controls
{
    public class RoundButton : Button
    {
        private Color clsNormalColor = Color.White;
        private Color clsHoverColor = Color.Black;
        private Color clsTextColor = Color.Black;
        StringFormat sf;

        public RoundButton()
        {
            SetStyle(ControlStyles.UserPaint, true);

            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        [Description("NormalColor"), Category("NormalColor")]
        public Color NormalColor
        {
            get { return clsNormalColor; }
            set { clsNormalColor = value; this.Invalidate(); }
        }

        [Description("HoverColor"), Category("HoverColor")]
        public Color HoverColor
        {
            get { return clsHoverColor; }
            set { clsHoverColor = value; this.Invalidate(); }
        }

        [Description("TextColor"), Category("TextColor")]
        public Color TextColor
        {
            get { return clsTextColor; }
            set { clsTextColor = value; this.Invalidate(); }
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
            using (GraphicsPath outerPath = RoundedRectangle(outerRect, 5, 0))
            {
                Brush brNormal = new SolidBrush(NormalColor);
                Brush brHover = new SolidBrush(HoverColor);

                if (Enabled && Bounds.Contains(Parent.PointToClient(Cursor.Position)))
                    g.FillPath(brHover, outerPath);
                else
                    g.FillPath(brNormal, outerPath);
            }

            TextRenderer.DrawText(g, this.Text, this.Font, outerRect, TextColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
