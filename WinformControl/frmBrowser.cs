using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class frmBrowser : Form
    {
        //화면 사이즈 설정
        private int m_nWidth = 0;
        private int m_nHeight = 0;
        public void SetWitdhHeight(int nWidth, int nHeight)
        {
            m_nWidth = nWidth;
            m_nHeight = nHeight;
        }

        //크롬 브라우저
        private ChromiumWebBrowser browser;

        public frmBrowser()
        {
            clsConst.bfrmBrowser = true;

            InitializeComponent();

            InitCefInitialized();

            InitBrowser();

            //CenterToParent(this.Size);
        }

        public void LoadUrl(string sUrl)
        {
            browser.Load(sUrl);
        }

        private void CenterToParent(Size finalSize)
        {
            this.StartPosition = FormStartPosition.Manual;
            Point pPosition = new Point();

            var pParent = Program.MainForm;
            if (pParent != null)
            {
                int nWidth = pParent.Size.Width;
                int nHeight = pParent.Size.Height;
                int nX = pParent.Location.X;
                int nY = pParent.Location.Y;

                pPosition.X = nX + ((nWidth - finalSize.Width) / 2);
                pPosition.Y = nY + ((nHeight - finalSize.Height) / 2);
                this.Location = pPosition;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }

        private void InitCefInitialized()
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                settings.RemoteDebuggingPort = 8088;
                settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
                settings.CefCommandLineArgs.Add("persist_session_cookies", "1");
                settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
                settings.CefCommandLineArgs.Add("disable-gpu", "1");

                Cef.Initialize(settings);
                //Cef.EnableHighDPISupport();
                CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            }
        }

        private void InitBrowser()
        {
            browser = new ChromiumWebBrowser("");
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.LoadError += browser_LoadError;

            browser.Parent = pnlBrowser;
            browser.Dock = DockStyle.Fill;
        }

        private void browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //Log
            string sMsg = string.Format("browser_LoadError :{0} ", e.ErrorText);
            Console.WriteLine(sMsg);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            try
            {
                string sMsg = (args.IsLoading ? "Loading..." : browser.Address);

                if (args.IsLoading == false)
                {
                    //브라우저 로드 완료시 해야할 일을 실행
                }
            }
            catch
            {
            }
        }

        private void CloseBrowser()
        {
            try
            {
                if (browser != null)
                {
                    IntPtr _chromiumWebBrowserHandle = browser.Handle;

                    IntPtr lRes;
                    clsWin32Api.SendMessageTimeout(_chromiumWebBrowserHandle, clsWin32Api.WM_CLOSE, IntPtr.Zero, IntPtr.Zero, clsWin32Api.SendMessageTimeoutFlags.SMTO_NORMAL, 100, out lRes);
                }

                Cef.Shutdown();
            }
            catch { }
        }

        private void mouseoverButton1_Click(object sender, EventArgs e)
        {
            CloseBrowser();

            Program.MainForm.Close_frmBrower();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            this.Width = m_nWidth;
            this.Height = m_nHeight;
            CenterToParent(this.Size);
        }

        private void frmBrowser_Resize(object sender, EventArgs e)
        {

        }
    }
}
