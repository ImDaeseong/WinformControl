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
    public partial class addBar : UserControl
    {
        public event EventHandler addbarEventClick;


        private string m_noLabel = "";
        public string NoText
        {
            get
            {
                m_noLabel = noLabel.Text;
                return m_noLabel;
            }
            set
            {
                m_noLabel = value;
                noLabel.Text = m_noLabel;
                Invalidate();
            }
        }

        private string m_1Label = "";
        public string label1Text
        {
            get
            {
                m_1Label = lblLabel1.Text;
                return m_1Label;
            }
            set
            {
                m_1Label = value;
                lblLabel1.Text = m_1Label;
                Invalidate();
            }
        }

        private string m_2Label = "";
        public string label2Text
        {
            get
            {
                m_2Label = lblLabel2.Text;
                return m_2Label;
            }
            set
            {
                m_2Label = value;
                lblLabel2.Text = m_2Label;
                Invalidate();
            }
        }

        private string m_tag = "";
        public string ButtonText
        {
            get
            {
                m_tag = delButton.Tag.ToString();
                return m_tag;
            }
            set
            {
                m_tag = value;
                delButton.Tag = m_tag;
                Invalidate();
            }
        }


        public addBar()
        {
            InitializeComponent();
            
            NoText = "";
            label1Text = "";
            label2Text = "";
            ButtonText = "";
        }
        
        private void delButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.addbarEventClick != null)
                    this.addbarEventClick(delButton, e);
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }
    }
}
