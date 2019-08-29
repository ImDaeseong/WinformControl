using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class frmPopupButton : Form
    {
        private int m_nWidth = 0;
        private int m_nHeight = 0;

        public frmPopupButton()
        {
            clsConst.bfrmPopupButton = true;

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ShowInTaskbar = false;
            TopMost = true;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.None;

            MoveWinForm();
        }

        private void MoveWinForm()
        {
            try
            {
                int nLeft = 632;
                int nTop = 292;
                if (Properties.Settings.Default.WidgetLeft != 0 && Properties.Settings.Default.WidgetTop != 0)
                {
                    nLeft = (int)Properties.Settings.Default.WidgetLeft;
                    nTop = (int)Properties.Settings.Default.WidgetTop;
                }

                IntPtr ptrHandle = this.Handle;
                if (ptrHandle == IntPtr.Zero) return;

                clsWin32Api.MoveWindow(ptrHandle, nLeft, nTop, m_nWidth, m_nHeight, false);
            }
            catch
            {
            }
        }

        private void frmPopupButton_Load(object sender, EventArgs e)
        {
            try
            {
                string BackgroundPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WinformControl\\widget.png";

                Bitmap bmpBackground = null;
                if (CommonFunc.getInstance.IsExistFile(BackgroundPath))
                    bmpBackground = (Bitmap)Image.FromFile(BackgroundPath);
                else
                    bmpBackground = new Bitmap(Properties.Resources.widget);

                if (bmpBackground != null)
                {
                    SetImageUpdateLayeredWindow(bmpBackground);
                    m_nWidth = bmpBackground.Width;
                    m_nHeight = bmpBackground.Height;
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();

                Bitmap bmpBackground = new Bitmap(Properties.Resources.widget);
                if (bmpBackground != null)
                {
                    SetImageUpdateLayeredWindow(bmpBackground);
                    m_nWidth = bmpBackground.Width;
                    m_nHeight = bmpBackground.Height;
                }
            }
        }

        public void SetImageUpdateLayeredWindow(Bitmap image, int newOpacity = 255)
        {
            if (image == null) return;

            if (image.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            IntPtr screenDc = FormStyleAPI.GetDC(IntPtr.Zero);
            IntPtr memDc = FormStyleAPI.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = image.GetHbitmap(Color.FromArgb(0));

                oldBitmap = FormStyleAPI.SelectObject(memDc, hBitmap);

                var size = new FormStyleAPI.Size { cx = image.Width, cy = image.Height };

                var pointSource = new FormStyleAPI.Point { x = 0, y = 0 };

                var topPos = new FormStyleAPI.Point { x = Left, y = Top };

                var blend = new FormStyleAPI.BLENDFUNCTION
                {
                    BlendOp = FormStyleAPI.AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = (byte)newOpacity,
                    AlphaFormat = FormStyleAPI.AC_SRC_ALPHA
                };

                FormStyleAPI.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, FormStyleAPI.ULW_ALPHA);
            }
            finally
            {
                FormStyleAPI.ReleaseDC(IntPtr.Zero, screenDc);

                if (hBitmap != IntPtr.Zero)
                {
                    FormStyleAPI.SelectObject(memDc, oldBitmap);
                    FormStyleAPI.DeleteObject(hBitmap);

                }
                FormStyleAPI.DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                if (!DesignMode)
                    cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        public void SaveLocation()
        {
            try
            {
                IntPtr ptrHandle = this.Handle;
                if (ptrHandle == IntPtr.Zero) return;

                Rectangle rcRect = new Rectangle(0, 0, 0, 0);
                bool success = clsWin32Api.GetWindowRect(ptrHandle, ref rcRect);
                if (success)
                {
                    Properties.Settings.Default.WidgetLeft = rcRect.Left;
                    Properties.Settings.Default.WidgetTop = rcRect.Top;
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
            }
        }

        private void frmPopupButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormStyleAPI.ReleaseCapture();
                FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
            }
        }

        private void frmPopupButton_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void frmPopupButton_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void frmPopupButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Hide();
                Program.MainForm.CallWidgetButton();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }
    }
}
