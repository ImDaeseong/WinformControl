using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public partial class Headtitle : UserControl
    {
        private string m_lblTitle = "";
        public string LabelText
        {
            get
            {
                m_lblTitle = lbltitle.Text;
                return m_lblTitle;
            }
            set
            {
                m_lblTitle = value;
                lbltitle.Text = m_lblTitle;
                Invalidate();
            }
        }

        public Headtitle()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            lbltitle.ForeColor = System.Drawing.Color.White;
            LabelText = "";
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            InitControlResize();
        }

        private void InitControlResize()
        {
            Point pt = new Point(DisplayRectangle.X + 5, (this.Height / 2) - (pictureBoxEx1.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            pictureBoxEx1.Location = pt;

            pt = new Point((DisplayRectangle.X + pictureBoxEx1.Width), (this.Height / 2) - (lbltitle.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            lbltitle.Location = pt;
        }

        private void pictureBoxEx1_Click(object sender, EventArgs e)
        {
            Program.MainForm.GoSettingUcl();
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {
            Program.MainForm.GoSettingUcl();
        }

        private void Headtitle_Click(object sender, EventArgs e)
        {
            Program.MainForm.GoSettingUcl();
        }
    }
}
