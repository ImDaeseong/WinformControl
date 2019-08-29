using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinformControl.Controls
{
    public class ComboBoxExLarge : ComboBox
    {
        //콤보 스타일 결정 모서리(둥근,직각)
        private bool bCornerRound = false;

        private bool bFocus = false;

        private Font _Font = new Font("맑은 고딕", 12F);

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if (DesignMode) return;

            e.ItemHeight = 40;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                base.OnDrawItem(e);

                if (System.Convert.ToInt32((e.State & DrawItemState.Selected)) == (int)DrawItemState.Selected)
                {
                    if (!(e.Index == -1))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(126, 180, 234)), e.Bounds);
                        e.Graphics.DrawString(GetItemText(Items[e.Index]), _Font, Brushes.Black, e.Bounds);
                    }
                }
                else
                {
                    if (!(e.Index == -1))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
                        e.Graphics.DrawString(GetItemText(Items[e.Index]), _Font, Brushes.Black, e.Bounds);
                    }
                }
            }
            catch { }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                base.OnResize(e);

                if (!Focused)
                {
                    SelectionLength = 0;
                }
            }
            catch { }
        }

        public ComboBoxExLarge()
        {
            SetStyle((ControlStyles)(139286), true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownStyle = ComboBoxStyle.DropDownList;

            BackColor = Color.FromArgb(246, 246, 246);
            ForeColor = Color.FromArgb(142, 142, 142);
            Size = new Size(190, 62);
            ItemHeight = 56;
            DropDownHeight = 150;
            Font = new Font("맑은 고딕", 14F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush LGB = default(LinearGradientBrush);
            GraphicsPath GP = default(GraphicsPath);

            e.Graphics.Clear(Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //배경색
            if (bCornerRound)
            {
                //둥근 모서리 스타일
                GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5);
                if (bFocus)
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(226, 239, 252), Color.FromArgb(226, 239, 252), 90.0F);
                else
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(236, 236, 236), Color.FromArgb(236, 236, 236), 90.0F);
            }
            else
            {
                //사각형 모서리 스타일
                GP = RoundRectangle.NoRoundRect(0, 0, Width - 1, Height - 1);
                if (bFocus)
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(226, 239, 252), Color.FromArgb(226, 239, 252), 90.0F);
                else
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(236, 236, 236), Color.FromArgb(236, 236, 236), 90.0F);
            }


            e.Graphics.SetClip(GP);
            e.Graphics.FillRectangle(LGB, ClientRectangle);
            e.Graphics.ResetClip();

            //모서리색
            if (bFocus)
                e.Graphics.DrawPath(new Pen(Color.FromArgb(126, 180, 234)), GP);
            else
                e.Graphics.DrawPath(new Pen(Color.FromArgb(153, 153, 153)), GP);

            //글자
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(0, 0, 0)), new Rectangle(3, 0, Width - 20, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            //화살표
            e.Graphics.DrawString("6", new Font("Marlett", 13, FontStyle.Regular), new SolidBrush(Color.FromArgb(119, 119, 118)), new Rectangle(3, 0, Width - 4, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            });

            //화살표옆 라인
            e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), Width - 24, 4, Width - 24, this.Height - 5);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), Width - 25, 4, Width - 25, this.Height - 5);

            GP.Dispose();
            LGB.Dispose();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            bFocus = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            bFocus = false;
            Invalidate();
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            bFocus = false;
            Invalidate();
        }
    }

    public class ComboBoxEx : ComboBox
    {
        //콤보 스타일 결정 모서리(둥근,직각)
        private bool bCornerRound = false;

        private bool bFocus = false;

        private Font _Font = new Font("맑은 고딕", 12F);

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if (DesignMode) return;

            e.ItemHeight = 30;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                base.OnDrawItem(e);

                if (System.Convert.ToInt32((e.State & DrawItemState.Selected)) == (int)DrawItemState.Selected)
                {
                    if (!(e.Index == -1))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(126, 180, 234)), e.Bounds);
                        e.Graphics.DrawString(GetItemText(Items[e.Index]), _Font, Brushes.Black, e.Bounds);
                    }
                }
                else
                {
                    if (!(e.Index == -1))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
                        e.Graphics.DrawString(GetItemText(Items[e.Index]), _Font, Brushes.Black, e.Bounds);
                    }
                }
            }
            catch { }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                base.OnResize(e);

                if (!Focused)
                {
                    SelectionLength = 0;
                }
            }
            catch { }
        }

        public ComboBoxEx()
        {
            SetStyle((ControlStyles)(139286), true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownStyle = ComboBoxStyle.DropDownList;

            BackColor = Color.FromArgb(246, 246, 246);
            ForeColor = Color.FromArgb(142, 142, 142);
            Size = new Size(190, 62);
            ItemHeight = 56;
            DropDownHeight = 100;
            Font = new Font("맑은 고딕", 14F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush LGB = default(LinearGradientBrush);
            GraphicsPath GP = default(GraphicsPath);

            e.Graphics.Clear(Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //배경색
            if (bCornerRound)
            {
                //둥근 모서리 스타일
                GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5);
                if (bFocus)
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(226, 239, 252), Color.FromArgb(226, 239, 252), 90.0F);
                else
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(236, 236, 236), Color.FromArgb(236, 236, 236), 90.0F);
            }
            else
            {
                //사각형 모서리 스타일
                GP = RoundRectangle.NoRoundRect(0, 0, Width - 1, Height - 1);
                if (bFocus)
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(226, 239, 252), Color.FromArgb(226, 239, 252), 90.0F);
                else
                    LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(236, 236, 236), Color.FromArgb(236, 236, 236), 90.0F);
            }


            e.Graphics.SetClip(GP);
            e.Graphics.FillRectangle(LGB, ClientRectangle);
            e.Graphics.ResetClip();

            //모서리색
            if (bFocus)
                e.Graphics.DrawPath(new Pen(Color.FromArgb(126, 180, 234)), GP);
            else
                e.Graphics.DrawPath(new Pen(Color.FromArgb(153, 153, 153)), GP);

            //글자
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(0, 0, 0)), new Rectangle(3, 0, Width - 20, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            //화살표
            e.Graphics.DrawString("6", new Font("Marlett", 13, FontStyle.Regular), new SolidBrush(Color.FromArgb(119, 119, 118)), new Rectangle(3, 0, Width - 4, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            });

            //화살표옆 라인
            e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), Width - 24, 4, Width - 24, this.Height - 5);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), Width - 25, 4, Width - 25, this.Height - 5);

            GP.Dispose();
            LGB.Dispose();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            bFocus = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            bFocus = false;
            Invalidate();
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            bFocus = false;
            Invalidate();
        }
    }
    
    static class RoundRectangle
    {
        public static GraphicsPath NoRoundRect(int X, int Y, int Width, int Height)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            P.AddRectangle(Rectangle);
            return P;
        }
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public static GraphicsPath RoundedTopRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height - 1));
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - 1 + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y + Curve));
            return P;
        }
    }

}
