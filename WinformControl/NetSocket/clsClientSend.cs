using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinformControl.NetSocket
{
    class clsClientSend
    {
        private clsClientSocket _ClientSocket = null;

        private static clsClientSend selfInstance = null;
        public static clsClientSend getInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new clsClientSend();
                return selfInstance;
            }
        }

        public clsClientSend()
        {
        }

        ~clsClientSend()
        {
        }

        public clsClientSocket GetSocket
        {
            get { return this._ClientSocket; }
            set { this._ClientSocket = value; }
        }

        public bool GetGetSocketConnected()
        {
            return GetSocket.connected;
        }

        //미암호화
        public void Send(string strMsg)
        {
            try
            {
                if (GetSocket == null)
                    return;
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                if (GetSocket.connected == true)
                {
                    GetSocket.Send(strMsg);
                }
            }
            catch
            {
            }
        }
    }      
}
