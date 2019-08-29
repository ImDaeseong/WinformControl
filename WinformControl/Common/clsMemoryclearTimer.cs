using System;
using System.Threading;
using Timer = System.Threading.Timer;

namespace WinformControl.Common
{
    public class clsMemoryclearTimer
    {
        TimerCallback tCallback;
        Timer clearMemoryTimer;

        int nTickCount = 0;

        public void StartTimer()
        {
            tCallback = new TimerCallback(this.ClearMemoryMsg);

            //프로그램 시작후 10초부터 체크 시작 5초마다 체크
            clearMemoryTimer = new Timer(tCallback, this, 10000, 5000);
        }

        public void StopTimer()
        {
            try
            {
                if (clearMemoryTimer != null)
                {
                    clearMemoryTimer.Dispose();
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        public clsMemoryclearTimer()
        {
        }

        ~clsMemoryclearTimer()
        {
            StopTimer();
        }

        public void ClearMemoryMsg(object oMethod)
        {
            try
            {
                nTickCount++;

                //3초마다 호출
                if (nTickCount >= 3)
                {
                    ClearMemory();

                    nTickCount = 0;
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        //프로그램 메모리 사용량 줄임
        private void ClearMemory()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    clsWin32Api.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

    }
}
