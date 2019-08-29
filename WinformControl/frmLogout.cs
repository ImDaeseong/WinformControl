using System;
using System.Drawing;
using System.Windows.Forms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class frmLogout : frmBaseborderless
    {
        public frmLogout()
        {
            clsConst.bfrmLogout = true;

            InitializeComponent();

            //마우스 드레그 이동 불가
            MouseDrag = false;
            ShowInTaskbar = false;

            CenterToParent(this.Size);
        }

        private void CenterToParent(Size finalSize)
        {
            this.StartPosition = FormStartPosition.Manual;
            Point pPosition = new Point();

            var pParent = Program.MainForm;
            if (pParent != null)
            {
                int nWidth = pParent.Size.Width;
                int nHeight = pParent.Size.Height;
                int nX = pParent.Location.X;
                int nY = pParent.Location.Y;

                pPosition.X = nX + ((nWidth - finalSize.Width) / 2);
                pPosition.Y = nY + ((nHeight - finalSize.Height) / 2);
                this.Location = pPosition;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }            
        }

        private void frmLogout_Load(object sender, EventArgs e)
        {
            InitLocation();            
        }

        private void InitLocation()
        {
            Point pt = new Point((this.Width - label1.Width), (this.Top + label1.Height));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            label1.Location = pt;
            
            pt = new Point((this.Width / 2) - (label1.Width / 2), (this.Height / 2) - (label1.Height / 2));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            label1.Location = pt;

            pt = new Point((this.Width / 2) - (roundButton1.Width / 2), (label1.Bottom + roundButton1.Height));
            pt.X = Math.Max(0, pt.X);
            pt.Y = Math.Max(0, pt.Y);
            roundButton1.Location = pt;
        }

        private void mouseoverButton1_Click(object sender, EventArgs e)
        {
            clsConst.bfrmLogout = false;
            this.Close(); 
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            clsConst.bfrmLogout = false;
            this.DialogResult = DialogResult.OK;
        }

    }
}
