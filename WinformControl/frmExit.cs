using System;
using System.Drawing;
using System.Windows.Forms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class frmExit : frmBaseborderless
    {
        public frmExit()
        {
            clsConst.bfrmExit = true;

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

        private void roundButton1_Click(object sender, EventArgs e)
        {
            clsConst.bfrmExit = false;
            this.DialogResult = DialogResult.OK;
        }

        private void mouseoverButton1_Click(object sender, EventArgs e)
        {
            clsConst.bfrmExit = false;
            this.Close();
        }
    }
}
