using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControl
{
    public partial class SettingUcl : UserControl
    {
        public SettingUcl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            InitControlResize();
        }

        private void InitControlResize()
        {           
            //pnlsize
            pnlsize.Width = pnlsize.Parent.Width - 10;
            pnlsize.Height = pnlsize.Parent.Height - 10;

            Point pt = new Point((this.Width / 2) - (pnlsize.Width / 2), (this.Height / 2) - (pnlsize.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            pnlsize.Location = pt;

            //mouseoverButton1
            pt = new Point((pnlsize.Right - mouseoverButton1.Width - 10), (pnlsize.Top));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            mouseoverButton1.Location = pt;
            
            //buttonBorder2
            pt = new Point((pnlsize.Right - buttonBorder2.Width - 100), (pnlsize.Top + buttonBorder2.Height));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder2.Location = pt;



            int nOffset = (toggleButtonEx1.Width + toggleButtonEx1.Width) / 3;

            //buttonBorder1
            pt = new Point((((this.Width / 2) - (buttonBorder1.Width / 2)) - nOffset), (this.Height / 2) - (buttonBorder1.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder1.Location = pt;

            //buttonBorder3
            pt = new Point((((this.Width / 2) - (buttonBorder3.Width / 2)) - nOffset), (buttonBorder1.Bottom +10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder3.Location = pt;

            //buttonBorder4
            pt = new Point((((this.Width / 2) - (buttonBorder4.Width / 2)) - nOffset), (buttonBorder3.Bottom + 10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder4.Location = pt;

            //buttonBorder5
            pt = new Point((((this.Width / 2) - (buttonBorder5.Width / 2)) - nOffset), (buttonBorder4.Bottom + 10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder5.Location = pt;

            //toggleButtonEx1
            pt = new Point((((this.Width / 2) - (toggleButtonEx1.Width / 2)) + nOffset), (this.Height / 2) - (toggleButtonEx1.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            toggleButtonEx1.Location = pt;

            //buttonBorder6
            pt = new Point(toggleButtonEx1.Left, (toggleButtonEx1.Bottom + 10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder6.Location = pt;

            //buttonBorder7
            pt = new Point(toggleButtonEx1.Left, (buttonBorder6.Bottom + 10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder7.Location = pt;

            //buttonBorder8
            pt = new Point(toggleButtonEx1.Left, (buttonBorder7.Bottom + 10));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            buttonBorder8.Location = pt;
        }

        private void buttonBorder1_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl1");
        }

        private void buttonBorder2_Click(object sender, EventArgs e)
        {
            Program.MainForm.Call_frmLogout();
        }

        private void mouseoverButton1_Click(object sender, EventArgs e)
        {
            Program.MainForm.SettingUclClear(true);
        }

        private void buttonBorder3_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl2");
        }

        private void buttonBorder4_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl3");
        }

        private void buttonBorder5_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl4");
        }

        private void buttonBorder6_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl5");
        }

        private void buttonBorder7_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl6");
        }

        private void buttonBorder8_Click(object sender, EventArgs e)
        {
            Program.MainForm.SetChangeControl("UserControl7");
        }

    }
}
