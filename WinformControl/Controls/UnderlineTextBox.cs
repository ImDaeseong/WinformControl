using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public partial class UnderlineTextBox : UserControl
    {
        private string m_txtName;
        public string LabeltxtName
        {
            get { return txtName.Text; }
            set
            {
                m_txtName = value;
                txtName.Text = m_txtName;
                Invalidate();
            }
        }

        public UnderlineTextBox()
        {
            InitializeComponent();

            txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtName.BackColor = Color.FromArgb(250, 250, 250);
            txtName.MaxLength = 15;

            hLine1.BackColor = Color.FromArgb(250, 250, 250);
            hLine1.LineColor = System.Drawing.Color.Black;
            hLine1.LineBorder = 1;

            txtName.GotFocus += txtName_GotFocus;
            txtName.LostFocus += txtName_LostFocus;
            txtName.MouseLeave += txtName_MouseLeave;
            txtName.MouseEnter += txtName_MouseEnter;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.txtName.Location = new Point(0, 0);
            this.txtName.Height = this.Height - 1;
            this.txtName.Width = this.Width;

            this.hLine1.Location = new Point(0, this.txtName.Height);
            this.hLine1.Height = 1;
            this.hLine1.Width = this.Width;

            this.Height = this.txtName.Height + this.hLine1.Height;

            this.Invalidate();
        }

        void txtName_GotFocus(object sender, EventArgs e)
        {
            hLine1.LineColor = Color.FromArgb(126, 180, 234);
        }

        void txtName_LostFocus(object sender, EventArgs e)
        {
            hLine1.LineColor = System.Drawing.Color.Black;
        }

        void txtName_MouseLeave(object sender, EventArgs e)
        {
            if (txtName.Focused)
                hLine1.LineColor = Color.FromArgb(126, 180, 234);
            else
                hLine1.LineColor = System.Drawing.Color.Black;
        }

        void txtName_MouseEnter(object sender, EventArgs e)
        {
            hLine1.LineColor = Color.FromArgb(126, 180, 234);
        }
    }
}
