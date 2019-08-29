using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public class ImageButton : PictureBox
    {
        private int ImgSize = 70;

        public ImageButton()
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
                _ResourceImage = value;//ResizeImage(value, nImgWidth, nImgHeight);
                this.Refresh();
            }
        }

        private bool _Pressed = false;
        private bool Pressed
        {
            get { return _Pressed; }
            set
            {
                if (value == _Pressed)
                    return;

                _Pressed = value;
                Invalidate();
            }
        }

        private bool _Hovering = false;
        private bool Hovering
        {
            get { return _Hovering; }
            set
            {
                if (value == _Hovering)
                    return;

                _Hovering = value;
                Invalidate();
            }
        }

        private Color _BackColor = Color.FromArgb(0, 0, 0);
        public Color MouseNormalColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        private Color _MouseOverColor = Color.FromArgb(211, 211, 211);
        public Color MouseOverColor
        {
            get { return _MouseOverColor; }
            set { _MouseOverColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;

            g.FillRectangle((new SolidBrush(Parent.BackColor)), ClientRectangle);

            if (Pressed)
                g.FillRectangle(new SolidBrush(MouseOverColor), r);
            else if (Hovering)
                g.FillRectangle(new SolidBrush(MouseOverColor), r);
            else
                g.FillRectangle(new SolidBrush(MouseNormalColor), r);

            if (_ResourceImage != null)
            {
                int x = (Width - _ResourceImage.Width) / 2;
                int y = (Height - _ResourceImage.Height) / 2;

                Rectangle imgrect = new Rectangle(x, y, _ResourceImage.Width, _ResourceImage.Height);
                e.Graphics.DrawImage(_ResourceImage, imgrect);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Hovering = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hovering = false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pressed = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pressed = true;
            }
        }

    }
}
