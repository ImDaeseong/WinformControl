using System;
using Microsoft.Win32;

namespace WinformControl.Common
{
    class clsRegister
    {
        private static clsRegister selfInstance = null;
        public static clsRegister GetInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new clsRegister();
                return selfInstance;
            }
        }

        public clsRegister()
        {
        }

        public void StartPage(bool bStart = true)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (reg == null)
                {
                    return;
                }

                if (bStart == true)//시작페이지 설정
                {
                    reg.SetValue("WinformControl", CommonFunc.getInstance.GetCurrentProcessName());

                }
                else//시작페이지 삭제
                {
                    reg.DeleteValue("WinformControl");
                }
                reg.Close();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        public void SetLogFileValue(string sValue)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\WinformControl\\Client", true);
                if (reg == null)
                {
                    return;
                }

                reg.SetValue("CLF", sValue);
                reg.Close();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        public string GetLogFileValue()
        {
            string sValue = "";
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\WinformControl\\Client", true);
                if (reg == null)
                {
                    return "";
                }

                sValue = reg.GetValue("CLF").ToString();
                reg.Close();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();

                return "";
            }
            return sValue;
        }

        public void CreateLogFileValue()
        {
            string sValue = "SOFTWARE\\WinformControl\\Client";
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(sValue, true);
                if (reg == null)
                {
                    reg = Registry.CurrentUser.CreateSubKey(sValue);
                }

                reg.SetValue("CLF", "1");
                reg.Close();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        public void DeleteLogFileValue()
        {
            string sValue = "SOFTWARE\\WinformControl\\Client";
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(sValue, true);
                if (reg == null)
                {
                    reg = Registry.CurrentUser.CreateSubKey(sValue);
                }

                reg.SetValue("CLF", "0");
                reg.Close();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

    }
}
