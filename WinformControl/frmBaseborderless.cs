using System;
using System.Windows.Forms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class frmBaseborderless : Form
    {
        private bool m_bDrag = false;
        private bool m_aeroEnabled;

        public frmBaseborderless()
        {
            InitializeComponent();

            Init();
        }

        public bool MouseDrag
        {
            get { return m_bDrag; }
            set { m_bDrag = value; }
        }

        private void Init()
        {
            m_aeroEnabled = false;

            FormBorderStyle = FormBorderStyle.None;

            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= FormStyleAPI.CS_DropSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                //Environment.OSVersion.Version.Minor == 0 //Windows Vista
                //Environment.OSVersion.Version.Minor == 1//Windows 7
                //Environment.OSVersion.Version.Minor == 2//Windows 8

                int enabled = 0;
                FormStyleAPI.DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case FormStyleAPI.WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        FormStyleAPI.DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        FormStyleAPI.MARGINS margins = new FormStyleAPI.MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        FormStyleAPI.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            //폼 드레그시 이동 가능하게
            if (m_bDrag)
            {
                if (m.Msg == FormStyleAPI.WM_NCHITTEST && (int)m.Result == FormStyleAPI.HTCLIENT)
                    m.Result = (IntPtr)FormStyleAPI.HTCAPTION;
            }

        }

    }
}
