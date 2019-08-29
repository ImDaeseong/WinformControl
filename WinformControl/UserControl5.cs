using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace WinformControl
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();

            headtitle1.LabelText = "제목";

            Init();
        }

        private void loadingSpiner_Click(object sender, EventArgs e)
        {
            loadingSpiner.RotatePictureBoxSetUnSet();
        }

        private void Init()
        {
            progressBarBorderColor1.Maximum = 100;
            progressBarBorderColor1.Minimum = 0;
            progressBarBorderColor1.Value = 0;

            //RotatePictureBox 시작
            loadingSpiner_Click(null, null);

            //다운로드 시작
            Uri uri = new Uri("http://download/test.exe"); 
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(uri, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WinformControl\\test.exe");
            });
            thread.Start();        
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    double bytesIn = double.Parse(e.BytesReceived.ToString());
                    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                    double percentage = bytesIn / totalBytes * 100;
                    progressBarBorderColor1.Value = int.Parse(Math.Truncate(percentage).ToString());
                }));
            }
            catch { }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    //MessageBox.Show("재시작 합니다.");                    
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                }));
            }
            catch { }
        }
    }
}
