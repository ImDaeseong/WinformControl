using System.Windows.Forms;

namespace WinformControl.Controls
{
    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
