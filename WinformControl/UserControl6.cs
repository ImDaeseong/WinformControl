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
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";

            comboBoxExLarge1.Items.Clear();
            comboBoxExLarge1.Items.Add("이미지1");
            comboBoxExLarge1.Items.Add("이미지2");
            comboBoxExLarge1.Items.Add("이미지3");
            comboBoxExLarge1.Items.Add("이미지4");
            comboBoxExLarge1.SelectedIndex = 0;
        }

        private void comboBoxExLarge1_SelectedIndexChanged(object sender, EventArgs e)
        {
            scrollPictureBox1.SetChangeImageIndex(comboBoxExLarge1.SelectedIndex);
        }
    }
}
