using System;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;

namespace WinformControl.Common
{
    public class LifeSpanHandler : ILifeSpanHandler
    {
        public LifeSpanHandler()
        {
        }

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;

            if (!String.IsNullOrWhiteSpace(targetUrl))
            {
                //Program.MainForm.Call_frmBrower(targetUrl);

                System.Diagnostics.Process.Start(targetUrl);
                return true;//팝업 않뜸 
            }

            return false;//팝업 뜸         
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            if (browser.IsDisposed || browser.IsPopup)
            {
                return false;
            }
            return true;
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }
    }
}
