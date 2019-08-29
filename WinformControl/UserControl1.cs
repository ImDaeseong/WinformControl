using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using WinformControl.Common;

namespace WinformControl
{
    public partial class UserControl1 : UserControl
    {
        private ChromiumWebBrowser browser;

        public UserControl1()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";

            try
            {
                CefSettings settings = new CefSettings();
                settings.RemoteDebuggingPort = 8088;
                settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
                settings.CefCommandLineArgs.Add("persist_session_cookies", "1");
                settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
                settings.CefCommandLineArgs.Add("disable-gpu", "1");
            }
            catch { }

            InitBrowser("http://naver.com");
        }

        public void CloseBrowser()
        {
            try
            {
                if (browser != null)
                {
                    IntPtr _chromiumWebBrowserHandle = browser.Handle;

                    IntPtr lRes;
                    clsWin32Api.SendMessageTimeout(_chromiumWebBrowserHandle, clsWin32Api.WM_CLOSE, IntPtr.Zero, IntPtr.Zero, clsWin32Api.SendMessageTimeoutFlags.SMTO_NORMAL, 100, out lRes);
                }
            }
            catch { }

            //크롬 브라우저 종료시 너무 오래걸리므로 미사용
            /*
            try
            {    
                if (browser != null)
                {
                    browser.Dispose();
                    browser = null;
                }
            }
            catch (Exception ex)
            {
            }
            */
        }

        public void InitBrowser(String url)
        {
            browser = new ChromiumWebBrowser(url);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.LoadError += browser_LoadError;
            browser.Parent = pnlsize;
            browser.Dock = DockStyle.Fill;
        }

        private void browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //Log
            string sMsg = string.Format("browser_LoadError :{0} ", e.ErrorText);
            Console.WriteLine(sMsg);

            try
            {
                browser.Load("http://naver.com");
            }
            catch { }
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
                    //browser.ExecuteScriptAsync("setTimeout(function(){console.log('action:redirect');},3000);");
                }
            }
            catch { }
        }
    }
}
