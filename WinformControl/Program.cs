using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WinformControl
{
    static class Program
    {
        static frmMain _mainForm = null;
        public static frmMain MainForm
        {
            get { return _mainForm; }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool bExist = false;
            Mutex mt = null;

            try
            {
                mt = new Mutex(true, "WinformControl", out bExist);
                if (false == bExist)
                {
                    MessageBox.Show("이미 WinformControl이 실행중입니다.", "WinformControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.Run(_mainForm = new frmMain());
            }
            catch { }
            finally
            {
                if (mt != null && bExist != false)
                {
                    mt.ReleaseMutex();
                }
            }

        }
    }
}
