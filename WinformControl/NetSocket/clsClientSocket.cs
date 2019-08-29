using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WinformControl.NetSocket
{
    public class clsClientSocket
    {
        private static clsClientSocket selfInstance = null;

        public socketEventDelegate.OnClientReceiveMsg OnClientReceiveMsg;
        public socketEventDelegate.OnClientConnect OnClientConnect;
        public socketEventDelegate.OnClientDisConnect OnClientDisConnect;
        public socketEventDelegate.OnClientSendComplete OnClientSendComplete;

        //버퍼
        private byte[] buffer = new byte[256];
        private readonly int bufferLen = 256;

        //클라이언트 소켓
        private Socket clientSock = null;
        private string sServerIP = null;
        private int nClientport = 0;

        public static clsClientSocket GetInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new clsClientSocket();
                return selfInstance;
            }
        }

        public string ServerIP
        {
            get
            {
                return sServerIP;
            }
        }

        public int ClientPort
        {
            get
            {
                return nClientport;
            }
        }

        public bool connected
        {
            get
            {
                return (clientSock != null) ? (clientSock.Connected) : (false);
            }
        }

        public clsClientSocket()
        {
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public bool Connect(string sIP, int nPort)
        {
            sServerIP = sIP;
            nClientport = nPort;

            try
            {
                IPAddress IPAddr = IPAddress.Parse(sServerIP);
                IPEndPoint EP = new IPEndPoint(IPAddr, nClientport);
                clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSock.BeginConnect(EP, new AsyncCallback(CallBackConnect), this);
            }
            catch (Exception ex)
            {
                //Log
                string sMsg = string.Format("Connect Error:{0} ", ex.ToString());
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -" + sMsg);

                Disconnect();
                return false;
            }

            return true;
        }

        //비동기 접속
        private void CallBackConnect(IAsyncResult ar)
        {
            try
            {
                clientSock.BeginReceive(buffer, 0, bufferLen, SocketFlags.None, new AsyncCallback(CallBackReceive), this);
            }
            catch (Exception ex)
            {
                //Log
                string sMsg = string.Format("CallBackConnect Error:{0} ", ex.ToString());
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -" + sMsg);

                Disconnect();
                return;
            }

            this.OnClientConnect();
        }

        //비동기 데이타 받기
        private void CallBackReceive(IAsyncResult ar)
        {
            try
            {
                string strCompleteMsg = "";

                //int nIndex = 0;
                SocketError errorCode;
                int BytesReceived = clientSock.EndReceive(ar, out errorCode);

                //Log
                string sMsg = string.Format("BytesReceived :{0} ", BytesReceived);
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -" + sMsg);

                if (errorCode != SocketError.Success)
                {
                    // 데이터 수신 중 소켓오류가 발생하였다. 연결을 종료하자.
                    IPEndPoint IP = (IPEndPoint)clientSock.RemoteEndPoint;
                    if (IP == null)
                        return;

                    Disconnect();
                    return;
                }

                if (BytesReceived == 0)
                {
                    // 원격에서 연결을 종료하였다. 연결을 종료하자.
                    IPEndPoint IP = (IPEndPoint)clientSock.RemoteEndPoint;
                    if (IP == null)
                        return;

                    Disconnect();
                    return;
                }

                if (BytesReceived > 0)
                {
                    strCompleteMsg = Encoding.ASCII.GetString(buffer, 0, BytesReceived);

                    this.OnClientReceiveMsg(strCompleteMsg);
                }

                clientSock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(CallBackReceive), this);
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();

                try
                {
                    IPEndPoint IP = (IPEndPoint)clientSock.RemoteEndPoint;
                    if (IP == null)
                        return;

                    Disconnect();
                }
                catch
                {
                }
            }
        }

        //비동기 데이타 전송
        public void Send(string strMsg)
        {
            byte[] SendBuffer = Encoding.ASCII.GetBytes(strMsg);
            Send(SendBuffer);
        }

        public void Send(byte[] bSendMsg)
        {
            try
            {
                clientSock.BeginSend(bSendMsg, 0, bSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBackSendComplete), this);
            }
            catch
            {

                return;
            }
        }

        private void CallBackSendComplete(IAsyncResult ar)
        {
            int bytesSent = 0;
            try
            {
                bytesSent = clientSock.EndSend(ar);
            }
            catch
            {

                return;
            }

            this.OnClientSendComplete(bytesSent);
        }

        public void Disconnect()
        {
            if (clientSock != null)
            {
                try
                {
                    clientSock.Shutdown(SocketShutdown.Both);
                }
                catch { }

                try
                {
                    clientSock.Close();
                    clientSock = null;
                }
                catch { }

                this.OnClientDisConnect();
            }
        }
    }
}
