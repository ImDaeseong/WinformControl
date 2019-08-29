using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public class MouseoverButton : Button
    {
        private Boolean isMouseOver;

        private Color _BackColor = Color.FromArgb(250, 250, 250);
        public Color MouseNormalColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        private Color _MouseOverColor = Color.FromArgb(255, 250, 250);
        public Color MouseOverColor
        {
            get { return _MouseOverColor; }
            set { _MouseOverColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(_BackColor);

            Rectangle backrect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(_BackColor), backrect);

            if (isMouseOver)
            {
                SolidBrush brush = new SolidBrush(_MouseOverColor);
                e.Graphics.FillRectangle(brush, backrect);
            }

            if (Image != null)
            {
                Rectangle imgrect = new Rectangle(0, 0, this.Width - 2, this.Height - 2);
                e.Graphics.DrawImage(Image, imgrect);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isMouseOver = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isMouseOver = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            isMouseOver = true;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            isMouseOver = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }
    }
}
