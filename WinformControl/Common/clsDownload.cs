using System;
using System.Net;

namespace WinformControl.Common
{
    public class clsDownload
    {
        private static WebClient webClient;

        private static clsDownload selfInstance = null;
        public static clsDownload GetInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new clsDownload();
                return selfInstance;
            }
        }

        public clsDownload()
        {
        }

        public void getFileDownload(string sUrl, string sFilePath)
        {
            try
            {
                webClient = new WebClient();
                webClient.QueryString.Add("file", sFilePath);
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                Uri uri = new Uri(sUrl);
                webClient.DownloadFileAsync(uri, sFilePath);
            }
            catch (WebException ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //e.ProgressPercentage;
            //e.UserState;
            //e.BytesReceived;
            //e.TotalBytesToReceive;
        }

        private void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                string sFileName = ((System.Net.WebClient)(sender)).QueryString["file"];

                string szBuff = String.Format("{0}", sFileName);
                int len = System.Text.Encoding.Default.GetBytes(szBuff).Length + 1;

                clsWin32Api.COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)103;
                cds.cbData = len;
                cds.lpData = szBuff;

                IntPtr wndPtr = clsWin32Api.FindWindow(null, "frmMain");
                if (wndPtr != IntPtr.Zero)
                {
                    clsWin32Api.SendMessage(wndPtr, clsWin32Api.WM_COPYDATA, 0, ref cds);
                }

                webClient.Dispose();
            }
            catch (WebException ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        private string GetFileNameUrl(string sServerURL)
        {
            string sFileName = sServerURL.Substring(sServerURL.LastIndexOf("/") + 1);
            return sFileName;
        }

        private string GetFileNameExe(string sFileFullPath)
        {
            string sFileName = sFileFullPath.Substring(sFileFullPath.LastIndexOf("\\") + 1);
            return sFileName;
        }

        private string GetFileExtName(string strFilename)
        {
            int nPos = strFilename.LastIndexOf('.');
            int nLength = strFilename.Length;
            if (nPos < nLength)
                return strFilename.Substring(nPos + 1, (nLength - nPos) - 1);
            return string.Empty;
        }
    }
}
