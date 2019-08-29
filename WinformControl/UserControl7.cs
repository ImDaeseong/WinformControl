using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControl.Controls;

namespace WinformControl
{
    public partial class UserControl7 : UserControl
    {
        //pnl1View 높이(pnl1View 밑에서부터 addBar를 붙여야하기 때문에 pnl1View 높이가 필요함)
        private int nScrollY = 100;

        public UserControl7()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";
            
            for(int i=0; i< 5; i++)
            {
                addBar itemCtl = new addBar();
                itemCtl.NoText = String.Format("{0}", i + 1);
                itemCtl.label1Text = String.Format("label1Text_{0}", i + 1);
                itemCtl.label2Text = String.Format("label2Text_{0}", i + 1);
                itemCtl.ButtonText = i.ToString();
                itemCtl.addbarEventClick += item_ddbarEventClick;
                itemCtl.Name = string.Format("addBar{0}", i);
                itemCtl.Location = new System.Drawing.Point(1, nScrollY);
                pnlScroll.Controls.Add(itemCtl);
                nScrollY = nScrollY + 60;
            }
        }

        private void item_ddbarEventClick(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
