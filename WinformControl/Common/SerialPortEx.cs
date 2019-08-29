using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace WinformControl.Common
{
    public class SerialPortEventDelegate
    {
        public delegate void OnSerialReceiveMsg(string strRecvMsg);
    }

    public class SerialPortEx
    {
        public event SerialPortEventDelegate.OnSerialReceiveMsg serialReceive = null;


        private SerialPort _serialPort;

        private Object _Lock = new Object();

        public SerialPortEx()
        {
            _serialPort = new SerialPort();
        }

        public void Open(string sPortName, int nBaudRate)
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Encoding = Encoding.GetEncoding("ks_c_5601-1987");
                _serialPort.PortName = sPortName;
                _serialPort.BaudRate = nBaudRate;
                _serialPort.DataBits = (int)8;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Handshake = Handshake.None;
                _serialPort.DtrEnable = true;
                _serialPort.DataReceived += serialPortEx_DataReceived;

                try
                {
                    _serialPort.Open();
                }
                catch { }
            }
        }

        public void Close()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.DataReceived -= serialPortEx_DataReceived;
                try
                {
                    _serialPort.Close();
                }
                catch { }
            }
        }

        private void serialPortEx_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof)
                return;

            lock (_Lock)
            {
                Int32 len = _serialPort.BytesToRead;
                Byte[] data = new Byte[len];
                try
                {
                    _serialPort.Read(data, 0, len);
                }
                catch (Exception)
                {
                }

                if (serialReceive != null)
                {
                    string sData = System.Text.Encoding.Default.GetString(data);
                    serialReceive.Invoke(sData);
                }
            }
        }

        public bool Write(string sData)
        {
            if (!_serialPort.IsOpen)
                return false;

            try
            {
                _serialPort.Write(sData);
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
                return false;
            }
            return true;
        }

        public bool Write(Byte[] bData)
        {
            if (!_serialPort.IsOpen)
                return false;

            try
            {
                _serialPort.Write(bData, 0, bData.Length);
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message.ToString();
                return false;
            }
            return true;
        }

    }
}
