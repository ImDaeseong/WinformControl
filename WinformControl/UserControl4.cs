using System;
using System.Windows.Forms;

namespace WinformControl
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";
        }

        private void trackBarEx1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                float volumn = (float)Math.Round((float)(trackBarEx1.Value / 10), 1);
                Console.WriteLine(volumn);
            }
            catch { }
        }

        private void trackBarEx1_ValueChanged(object sender, EventArgs e)
        {
            float volumn = (float)Math.Round((float)(trackBarEx1.Value / 10), 1);
            Console.WriteLine(volumn);
        }
    }
}
