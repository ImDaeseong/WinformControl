using System;
using System.Threading;
using WinformControl.NetSocket;
using Timer = System.Threading.Timer;

namespace WinformControl.Common
{
    class clsConnectTimer
    {
        clsClientSend clientSend = clsClientSend.getInstance;

        TimerCallback tCallback;
        Timer ConnectTimer;

        int nConnectTickCount = 0;

        private frmMain m_pParent = null;

        public void StartTimer()
        {
            tCallback = new TimerCallback(this.CheckMsg);
            ConnectTimer = new Timer(tCallback, this, 1000, 1000);
        }

        public void StopTimer()
        {
            try
            {
                if (ConnectTimer != null)
                {
                    ConnectTimer.Dispose();
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
            }
        }

        public clsConnectTimer(frmMain Parent)
        {
            m_pParent = Parent;
        }

        ~clsConnectTimer()
        {
            StopTimer();
        }

        public void CheckMsg(object oMethod)
        {
            try
            {
                nConnectTickCount++;

                //20초마다 접속 여부 체크
                if (nConnectTickCount >= 20)
                {
                    if (clientSend.GetGetSocketConnected())
                    {
                        Console.WriteLine("접속 상태");
                    }
                    else
                    {
                        Console.WriteLine("미접속 상태");
                    }

                    nConnectTickCount = 0;
                }
            }
            catch { }
        }
    }
}
