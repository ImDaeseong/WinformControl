using System;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace WinformControl.Common
{
    public static class LPTEx
    {
        private const short FILE_ATTRIBUTE_NORMAL = 0x80;
        private const short INVALID_HANDLE_VALUE = -1;
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint CREATE_NEW = 1;
        private const uint CREATE_ALWAYS = 2;
        private const uint OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(string strFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr intptrSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr intptrTemplateFile);

        public static bool LPTPrint(byte[] cmdBytes, string lptPort)
        {
            bool result = false;
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            SafeFileHandle handle = null;
            try
            {
                handle = CreateFile(lptPort, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                if (!handle.IsInvalid)
                {
                    fileStream = new FileStream(handle, FileAccess.ReadWrite);
                    streamWriter = new StreamWriter(fileStream);//streamWriter = new StreamWriter(fileStream, Encoding.Default);
                    streamWriter.Write(cmdBytes);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }
                if (handle != null)
                {
                    handle.Close();
                    handle = null;
                }
            }
            return result;
        }

        public static bool LPTPrint(string message, string portName)
        {
            string nl = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
            Byte[] buffer = new byte[message.Length];
            buffer = System.Text.Encoding.GetEncoding("ks_c_5601-1987").GetBytes(message);

            return LPTPrint(buffer, portName);
        }
    }
}
