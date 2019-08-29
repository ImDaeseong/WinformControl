
namespace WinformControl.NetSocket
{
    public class socketEventDelegate
    {
        public delegate void OnClientReceiveMsg(string strRecvMsg);
        public delegate void OnClientConnect();
        public delegate void OnClientDisConnect();
        public delegate void OnClientSendComplete(int nSent);
    }
}
