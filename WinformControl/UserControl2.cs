using System.Windows.Forms;

namespace WinformControl
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";

            comboBoxEx1.Items.Clear();           
            comboBoxEx1.Items.Add("테스트1");
            comboBoxEx1.Items.Add("테스트2");
            comboBoxEx1.Items.Add("테스트3");
            comboBoxEx1.Items.Add("테스트4");
            comboBoxEx1.Items.Add("테스트5");
            comboBoxEx1.Items.Add("테스트6");
            comboBoxEx1.Items.Add("테스트7");
            comboBoxEx1.Items.Add("테스트8");
            comboBoxEx1.Items.Add("테스트9");
            comboBoxEx1.Items.Add("테스트10");
            comboBoxEx1.SelectedItem = 0;

            comboBoxExLarge1.Items.Clear();  
            comboBoxExLarge1.Items.Add("테스트1");
            comboBoxExLarge1.Items.Add("테스트2");
            comboBoxExLarge1.Items.Add("테스트3");
            comboBoxExLarge1.Items.Add("테스트4");
            comboBoxExLarge1.SelectedItem = 0;
        }
    }
}
