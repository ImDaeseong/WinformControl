using System;
using System.Linq;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinformControl.Common
{
    class CommonFunc
    {
        private static CommonFunc selfInstance = null;
        public static CommonFunc getInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new CommonFunc();
                return selfInstance;
            }
        }

        public string APPLICATION_FILE_PATH = Application.StartupPath;

        public String osVersion()
        {
            OperatingSystem os = System.Environment.OSVersion;
            //Console.WriteLine("os.Version.Major " + os.Version.Major);
            //Console.WriteLine("os.Version.Minor " + os.Version.Minor);

            String osName = "";

            if (os.Version.Major == 4)
            {
                if (os.Version.Minor == 0)
                {
                    osName = "Windows NT 4.0";
                }
            }
            else if (os.Version.Major == 5)
            {
                if (os.Version.Minor == 0)
                {
                    osName = "Windows 2000";
                }
                else if (os.Version.Minor == 1)
                {
                    osName = "Windows XP";
                }
                else if (os.Version.Minor == 2)
                {
                    osName = "Windows 2003";
                }
            }
            else if (os.Version.Major == 6)
            {
                if (os.Version.Minor == 0)
                {
                    osName = "Windows Vista";
                }
                else if (os.Version.Minor == 1)
                {
                    osName = "Windows 7";
                }
                else if (os.Version.Minor == 2)
                {
                    osName = "Windows 8";
                }
            }
            else if (os.Version.Major == 10)
            {
                osName = "Windows 10";
            }

            return osName;
        }

        public string GetMacAddress()
        {
            var firstMacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return firstMacAddress;
        }

        public Bitmap BitmapFromUrl(string sImgUrl)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Stream image = webClient.OpenRead(sImgUrl);
                    Bitmap bitmap = Bitmap.FromStream(image) as Bitmap;
                    return bitmap;
                }
                catch (Exception ex)
                {
                    string sMsg = ex.Message.ToString();
                    return null;
                }
            }
        }

        public void GetSaveImg(string sImgUrl, string sLocalPath)
        {
            Bitmap savedimg = BitmapFromUrl(sImgUrl);

            //파일이름
            int nIndexLast = sImgUrl.LastIndexOf('/');
            string sName = sImgUrl.Substring(nIndexLast + 1);

            //확장자
            int nIndex = sImgUrl.LastIndexOf('.');
            string sExt = sImgUrl.Substring(nIndex + 1);

            sLocalPath += sName;

            savedimg.Save(sLocalPath, System.Drawing.Imaging.ImageFormat.Png);
        }

        public string GetCurrentProcessName()
        {
            string sExePath = string.Format("{0}\\WinformControl.exe", APPLICATION_FILE_PATH);
            return sExePath;
        }

        public IntPtr GetFindForm(string sFormName)
        {
            string sTypeName = Assembly.GetEntryAssembly().GetName().Name + "." + sFormName;
            Type type = Type.GetType(sTypeName);
            if (type == null)
                return IntPtr.Zero;

            foreach (Form fFind in Application.OpenForms)
            {
                if (fFind.GetType() == type)
                    return fFind.Handle;
            }
            return IntPtr.Zero;
        }

        public bool IsExistFile(string sLocalPath)
        {
            FileInfo f = new FileInfo(sLocalPath);
            if (f.Exists)
                return true;
            else
                return false;
        }

        public bool GetActiveForm()
        {
            foreach (Form fFind in Application.OpenForms)
            {
                if (fFind is frmExit)
                    return true;

                if (fFind is frmLogout)
                    return true;
            }
            return false;
        }

        public void RunProcess(string sPath)
        {
            try
            {
                Process.Start(sPath);
            }
            catch { }
        }

    }
}
