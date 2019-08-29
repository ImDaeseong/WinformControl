using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinformControl.Controls
{
    public partial class TrackBarEx : UserControl
    {
        public TrackBarEx()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
            this.AutoSize = false;
        }

        private double _Value = 0;
        public double Value
        {
            get { return _Value; }
            set
            {
                if (_Value == value)
                {
                    return;
                }
                else
                {
                    _Value = value;
                    this.Invalidate();
                    if (ValueChanged != null)
                    {
                        ValueChanged(this, new EventArgs());
                    }
                }
            }
        }

        private int _Minimum = 0;
        public int Minimum
        {
            get { return _Minimum; }
            set { _Minimum = value; }
        }

        private int _Maximum = 10;
        public int Maximum
        {
            get { return _Maximum; }
            set { _Maximum = value; }
        }

        private int _TrackHeight = 4;
        public int TrackHeight
        {
            get { return _TrackHeight; }
            set
            {
                _TrackHeight = value;
                this.Invalidate();
            }
        }

        private int _LRMargins = 40;
        public int LRMargins
        {
            get { return _LRMargins; }
            set
            {
                _LRMargins = value;
                this.Invalidate();
            }
        }

        public enum ControlState
        {
            Normal,
            Hover,
            Pressed,
            Focused,
        }

        public GraphicsPath CreateRoundPath(int radius)
        {
            double percent = (double)Value / (double)(Maximum - Minimum);
            int X = LRMargins + (int)((double)Value / (double)(this.Maximum - this.Minimum) * (this.Width - LRMargins * 2));
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(X - radius, this.Height / 2 - radius, radius * 2, radius * 2);
            gp.CloseFigure();
            return gp;
        }

        public void CreateShadowCircle(Graphics g, double CurrentValue, int radius)
        {
            double percent = (double)Value / (double)(Maximum - Minimum);
            int X = LRMargins + (int)((double)Value / (double)(this.Maximum - this.Minimum) * (this.Width - LRMargins * 2));

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = Color.White;
            Color shadow = Color.FromArgb(255, 188, 188, 188);

            for (int i = 0; i < 8; i++)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadow)))
                {
                    g.FillEllipse(brush, (X - radius) + i * 2, (this.Height / 2 - radius) + i, radius * 2, radius * 2);
                }
            }
            g.FillEllipse(new SolidBrush(color), X - radius, this.Height / 2 - radius, radius * 2, radius * 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect = new Rectangle(LRMargins, (this.Height - TrackHeight) / 2, this.Width - LRMargins * 2, TrackHeight);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 204, 204, 204)), rect);

            Rectangle rect1 = new Rectangle(rect.Left, rect.Top, (int)((double)Value / (double)(this.Maximum - this.Minimum) * rect.Width), rect.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 51, 51)), rect1);

            CreateShadowCircle(g, Value, 24);

            base.OnPaint(e);
        }

        public ControlState CState = ControlState.Normal;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            CState = ControlState.Pressed;

            double percent = (double)(e.X - LRMargins) / (double)(this.Width - LRMargins * 2);
            this.Value = (percent * (Maximum - Minimum));
            Invalidate();
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CState = ControlState.Normal;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            GraphicsPath gp = CreateRoundPath(TrackHeight);
            if (gp.GetBounds().Contains(e.Location) && CState != ControlState.Pressed)
            {
                CState = ControlState.Hover;
                Invalidate();
            }
            else if (!gp.GetBounds().Contains(e.Location) && CState != ControlState.Pressed)
            {
                CState = ControlState.Focused;
                Invalidate();
            }

            if (CState == ControlState.Pressed && this.Focused)
            {
                double percent = (double)(e.X - LRMargins) / (double)(this.Width - LRMargins * 2);
                int valueTemp = (int)(percent * (Maximum - Minimum));
                if (valueTemp >= this.Maximum)
                {
                    this.Value = this.Maximum;
                }
                else if (valueTemp <= this.Minimum)
                {
                    this.Value = this.Minimum;
                }
                else
                {
                    this.Value = valueTemp;
                }
                Invalidate();

                if (ValueChanged != null)
                {
                    ValueChanged(this, e);
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Focus();
            CState = ControlState.Focused;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Parent.Focus();
            CState = ControlState.Normal;
        }

        [Browsable(true)]
        public event EventHandler ValueChanged;
    }
}
