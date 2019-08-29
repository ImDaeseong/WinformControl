using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public partial class HeadmainTitle : UserControl
    {
        public HeadmainTitle()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            InitControlResize();
        }

        private void InitControlResize()
        {
            Point pt = new Point(DisplayRectangle.X + (DisplayRectangle.Width - close.Width), (this.Height / 2) - (close.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            close.Location = pt;

            pt = new Point(DisplayRectangle.X + (DisplayRectangle.Width - close.Width - Maximize.Width), (this.Height / 2) - (Maximize.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            Maximize.Location = pt;

            pt = new Point(DisplayRectangle.X + (DisplayRectangle.Width - close.Width - Maximize.Width - Mimimize.Width), (this.Height / 2) - (Mimimize.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            Mimimize.Location = pt;

            pt = new Point(DisplayRectangle.X + (DisplayRectangle.Width - close.Width - Maximize.Width - Mimimize.Width - SettingButton.Width), (this.Height / 2) - (SettingButton.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            SettingButton.Location = pt;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Program.MainForm.Call_frmExit();
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            Program.MainForm.MaximizeUclShow();
        }

        private void Mimimize_Click(object sender, EventArgs e)
        {
            Program.MainForm.MimimizeUclShow();
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            Program.MainForm.SettingUclShow();
        }

        private void HeadmainTitle_MouseMove(object sender, MouseEventArgs e)
        {
            Program.MainForm.Invoke(new MethodInvoker(delegate()
            {
                Program.MainForm.frmMain_MouseMove();
            }));
        }

        private void HeadmainTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Program.MainForm.MaximizeUclShow();
        }

    }
}
