using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public partial class ToggleButtonEx : UserControl
    {
        private bool m_bOn = false;

        public bool IsOn
        {
            get { return m_bOn; }
            set
            {
                m_bOn = value;
                setToggle();
            }
        }

        public ToggleButtonEx()
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
            //onButton1.Hide();
            onButton1.Width = (this.Width / 2);
            onButton1.Height = (this.Height) - 2;
            onButton1.Location = new Point(1, 1);

            //offButton1.Hide();
            offButton1.Width = (this.Width / 2);
            offButton1.Height = (this.Height) - 2;
            offButton1.Location = new Point((onButton1.Width) + 1, 1);
        }

        private void onButton1_Click(object sender, EventArgs e)
        {
            m_bOn = true;
            offButton1.Hide();
            onButton1.Show();
            roundedPanel1.BorderColor = Color.FromArgb(255, 51, 51);
            roundedPanel1.Invalidate();
        }

        private void offButton1_Click(object sender, EventArgs e)
        {
            m_bOn = false;
            onButton1.Hide();
            offButton1.Show();
            roundedPanel1.BorderColor = Color.FromArgb(221, 221, 221);
            roundedPanel1.Invalidate();
        }

        private void roundedPanel1_Click(object sender, EventArgs e)
        {
            if (m_bOn)
            {
                offButton1_Click(null, null);//현재 상태가 온이므로 오프로

                Program.MainForm.SetStartPage(false);
            }
            else
            {
                onButton1_Click(null, null);//현재 상태가 오프이므로 온으로

                Program.MainForm.SetStartPage(true);
            }
        }

        private void setToggle()
        {
            if (m_bOn)
            {
                m_bOn = true;
                offButton1.Hide();
                onButton1.Show();
                roundedPanel1.BorderColor = Color.FromArgb(255, 51, 51);
                roundedPanel1.Invalidate();
            }
            else
            {
                m_bOn = false;
                onButton1.Hide();
                offButton1.Show();
                roundedPanel1.BorderColor = Color.FromArgb(221, 221, 221);
                roundedPanel1.Invalidate();
            }
        }

    }
}
