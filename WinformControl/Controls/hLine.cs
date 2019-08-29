using System.Drawing;
using System.Windows.Forms;

namespace WinformControl.Controls
{
    public partial class hLine : UserControl
    {
        private Color m_LineColor = Color.Black;
        private int m_LineBorder = 1;

        public int LineBorder
        {
            get { return m_LineBorder; }
            set
            {
                m_LineBorder = value;
                this.Width = m_LineBorder;
                this.Refresh();
            }
        }

        public Color LineColor
        {
            get { return m_LineColor; }
            set
            {
                m_LineColor = value;
                this.BackColor = m_LineColor;
                this.Refresh();
            }
        }

        public hLine()
        {
            InitializeComponent();
            LineColor = Color.Black;
            LineBorder = 1;
        }
    }
}
