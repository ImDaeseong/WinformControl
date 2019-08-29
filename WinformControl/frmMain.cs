using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControl.Common;
using WinformControl.NetSocket;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;

namespace WinformControl
{
    public partial class frmMain : Form
    {
        //소켓 접속 여부 체크 timer
        clsConnectTimer tConnect = null;

        //프로그램 메모리 해제 timer
        clsMemoryclearTimer tClearmemory = null;

        //크롬 브라우저
        private ChromiumWebBrowser browser;

        //현재 폼사이즈(최대,일반)
        public bool bFormState = false;

        //UserControl
        private SettingUcl _SettingUcl = null;
        private Control _USER_CONTROL;
        private UserControl1 _UserControl1 = null;
        private UserControl2 _UserControl2 = null;
        private UserControl3 _UserControl3 = null;
        private UserControl4 _UserControl4 = null;
        private UserControl5 _UserControl5 = null;
        private UserControl6 _UserControl6 = null;
        private UserControl7 _UserControl7 = null;


        private clsClientSocket ClientSocket;
        private clsClientSend ClientSend = clsClientSend.getInstance;

        public frmMain()
        {
            InitializeComponent();

            //크롬 초기화
            InitCefInitialized();

            //초기화면
            SetPanelIndex(1);
            this.pnlSplash.Dock = DockStyle.Fill;
            this.pnlSplash.BringToFront();
            
            //클라이언트 소켓 생성
            ClientSocket = new clsClientSocket();
            ClientSocket.OnClientReceiveMsg += new socketEventDelegate.OnClientReceiveMsg(OnClientReceiveMsg);
            ClientSocket.OnClientConnect += new socketEventDelegate.OnClientConnect(OnClientConnect);
            ClientSocket.OnClientDisConnect += new socketEventDelegate.OnClientDisConnect(OnClientDisConnect);
            ClientSocket.OnClientSendComplete += new socketEventDelegate.OnClientSendComplete(OnClientSendComplete);
            
            //프로그램 메모리 해제 timer
            tClearmemory = new clsMemoryclearTimer();
            tClearmemory.StartTimer();
        }

        //-- ChromiumWebBrowser func
        private void InitCefInitialized()
        {            
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                settings.RemoteDebuggingPort = 8088;
                settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
                settings.CefCommandLineArgs.Add("persist_session_cookies", "1");
                settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
                settings.CefCommandLineArgs.Add("disable-gpu", "1");

                Cef.Initialize(settings);
                //Cef.EnableHighDPISupport();
                CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            }
        }

        private void InitBrowser()
        {
            browser = new ChromiumWebBrowser("http://naver.com");
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.LoadError += browser_LoadError;
           
            browser.Parent = pnlBrowser;
            browser.Dock = DockStyle.Fill;
        }

        private void browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //Log
            string sMsg = string.Format("browser_LoadError :{0} ", e.ErrorText);
            Console.WriteLine(sMsg);

            try
            {
                browser.Load("http://naver.com");
            }
            catch { }
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            try
            {
                string sMsg = (args.IsLoading ? "Loading..." : browser.Address);

                if (args.IsLoading == false)
                {
                    //브라우저 로드 완료시 해야할 일을 실행
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        SetPanelIndex(2);

                        this.pnlBrowser.Dock = DockStyle.Fill;
                        this.pnlBrowser.BringToFront();
                    }));
                }
            }
            catch
            {
                browser.Load("http://naver.com");
                Console.WriteLine("OnLoadingStateChanged Err");
            }
        }

        private void CloseBrowser()
        {
            try
            {
                if (browser != null)
                {
                    IntPtr _chromiumWebBrowserHandle = browser.Handle;

                    IntPtr lRes;
                    clsWin32Api.SendMessageTimeout(_chromiumWebBrowserHandle, clsWin32Api.WM_CLOSE, IntPtr.Zero, IntPtr.Zero, clsWin32Api.SendMessageTimeoutFlags.SMTO_NORMAL, 100, out lRes);
                }

                Cef.Shutdown();
            }
            catch { }
        }

        public void ReLoadBrowser()
        {
            SetPanelIndex(2);

            this.pnlSetting.Dock = DockStyle.Fill;
            this.pnlSetting.BringToFront();

            browser.Reload(true);
        }
        //-- ChromiumWebBrowser func

        //-- socket func
        private void OnClientConnect()
        {
            ClientSend.GetSocket = ClientSocket;
        }

        private void OnClientDisConnect()
        {
        }

        private void OnClientSendComplete(int nSent)
        {
        }

        private void OnClientReceiveMsg(string strRecvMsg)
        {
        }

        public void ClientSocket_Start(string serverIp, int serverPort)
        {
            try
            {
                ClientSocket.Connect(serverIp, serverPort);
            }
            catch { }
        }

        public void ClientSocket_Stop()
        {
            try
            {
                if (ClientSocket.connected)
                {
                    ClientSocket.Disconnect();
                }
            }
            catch { }
        }
        //-- socket func


        public void Call_frmLogout()
        {
            try
            {
                frmLogout frmLogout = new frmLogout();
                DialogResult dResult = frmLogout.ShowDialog(this);
                if (dResult == DialogResult.OK)
                {
                    frmLogout.Close();
                }
            }
            catch { }
        }

        public void Call_frmExit()
        {
            try
            {
                frmExit frmExit = new frmExit();
                DialogResult dResult = frmExit.ShowDialog(this);
                if (dResult == DialogResult.OK)
                {
                    frmExit.Close();
                    ApplicationExit();
                }
            }
            catch { }
        }

        public void ApplicationExit()
        {
            try
            {
                //실행중인 창 모드 종료
                CloseAllForm();

                Application.Exit();
            }
            catch { }
        }

        public void DownLoadFile(string sFilePath)
        {
            try
            {
            }
            catch { }
        }

        //메인 버튼창
        frmPopupButton frmPopupHandle = null;
        private delegate void CallPopupButtonEventDelegate();
        private void CallPopupButton()
        {
            if (clsConst.bfrmPopupButton == false)
            {
                frmPopupHandle = new frmPopupButton();
                frmPopupHandle.Show();
            }
            else
            {
                frmPopupHandle.Activate();
            }
        }
        private void ClosePopupButton()
        {
            if (frmPopupHandle != null)
            {
                clsConst.bfrmPopupButton = false;
                frmPopupHandle.SaveLocation();
                frmPopupHandle.Close();
                frmPopupHandle = null;
            }
        }
        private void ShowHideWidget(bool bShow)
        {
            if (frmPopupHandle != null)
            {
                if (bShow)
                {
                    frmPopupHandle.Show();
                }
                else
                {
                    frmPopupHandle.Hide();
                }
            }
        }
        public void CallWidgetButton()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (Properties.Settings.Default.FormState)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;

                //위젯팝업창 숨김
                ShowHideWidget(false);
            }
            this.Activate();
        }

        private void CloseAllForm()
        {
            try
            {
                ClosePopupButton();
                ClearAllUcl();
                CloseBrowser();
            }
            catch { }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //현재 폼사이즈(최대,일반)
            bFormState = Properties.Settings.Default.FormState;

            //소켓 접속
            ClientSocket_Start("127.0.0.1", 8080);

            //소켓 접속 여부 체크
            tConnect = new clsConnectTimer(this);
            tConnect.StartTimer();

            //크롬브라우저 로딩
            InitBrowser();

            //투명 버튼창
            CallPopupButton();
        }        

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //실행중인 창 종료
                CloseAllForm();

                //소켓 접속 여부 체크
                if (tConnect != null) tConnect.StopTimer();

                //프로그램 메모리 해제 timer
                if (tClearmemory != null) tClearmemory.StopTimer();

                //소켓 종료
                ClientSocket_Stop();
                
            }
            catch { }
        }
                
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            if (CommonFunc.getInstance.GetActiveForm())
                return;

            ShowHideWidget(true);
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            //위젯팝업창 숨김
            ShowHideWidget(false);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
        }

        public void frmMain_MouseMove()
        {
            try
            {
                FormStyleAPI.ReleaseCapture();
                FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
            }
            catch {}
        }

        //메인 상단바 최대화 버튼 클릭
        public void MaximizeUclShow()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

                //현재 폼사이즈(최대)
                bFormState = true;
                Properties.Settings.Default.FormState = bFormState;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;

                //현재 폼사이즈(일반)
                bFormState = false;
                Properties.Settings.Default.FormState = bFormState;
            }
        }

        //메인 상단바 최소화 버튼 클릭
        public void MimimizeUclShow()
        {
            this.WindowState = FormWindowState.Minimized;

            //위젯팝업창 보임
            ShowHideWidget(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Color.FromArgb(219, 224, 235));
            g.DrawRectangle(pen, rect);
        }

        public void SetStartPage(bool IsOn)
        {
            if (IsOn == true)
            {
                clsRegister.GetInstance.StartPage(true);
            }
            else
            {
                clsRegister.GetInstance.StartPage(false);
            }
        }  

        private void SetPanelIndex(int nIndex)
        {
            if (nIndex == 1)//pnlSplash
            {
                this.pnlBrowser.Dock = DockStyle.None;
                this.pnlBrowser.Location = new Point(-1, -1);
                this.pnlBrowser.Size = new Size(0, 0);
                this.pnlBrowser.SendToBack();

                this.pnlSetting.Dock = DockStyle.None;
                this.pnlSetting.Location = new Point(-1, -1);
                this.pnlSetting.Size = new Size(0, 0);
                this.pnlSetting.SendToBack();
            }
            else if (nIndex == 2)//pnlBrowser
            {
                this.pnlSplash.Dock = DockStyle.None;
                this.pnlSplash.Location = new Point(-1, -1);
                this.pnlSplash.Size = new Size(0, 0);
                this.pnlSplash.SendToBack();

                this.pnlSetting.Dock = DockStyle.None;
                this.pnlSetting.Location = new Point(-1, -1);
                this.pnlSetting.Size = new Size(0, 0);
                this.pnlSetting.SendToBack();
            }
            else if (nIndex == 3)//pnlSetting
            {
                this.pnlSplash.Dock = DockStyle.None;
                this.pnlSplash.Location = new Point(-1, -1);
                this.pnlSplash.Size = new Size(0, 0);
                this.pnlSplash.SendToBack();

                this.pnlBrowser.Dock = DockStyle.None;
                this.pnlBrowser.Location = new Point(-1, -1);
                this.pnlBrowser.Size = new Size(0, 0);
                this.pnlBrowser.SendToBack();
            }
        }

        public void SettingUclShow()
        {
            if (_SettingUcl == null)
                _SettingUcl = new SettingUcl();

            //유저 컨트롤 전체 초기화
            ClearAllUcl();

            pnlSetting.Controls.Clear();
            pnlSetting.Controls.Add(_SettingUcl);
            _SettingUcl.Dock = DockStyle.Fill;

            SetPanelIndex(3);

            //메인내 설정 패널을 채운다
            this.pnlSetting.Dock = DockStyle.Fill;
            this.pnlSetting.BringToFront();

            _SettingUcl.Visible = true;
            _SettingUcl.BringToFront();
        }

        public void SetChangeControl(string sTag)
        {            
            switch (sTag)
            {
                case "UserControl1":
                    if (_UserControl1 == null) _UserControl1 = new UserControl1();
                    _USER_CONTROL = _UserControl1;
                    break;
                case "UserControl2":
                    if (_UserControl2 == null) _UserControl2 = new UserControl2();
                    _USER_CONTROL = _UserControl2;
                    break;
                case "UserControl3":
                    if (_UserControl3 == null) _UserControl3 = new UserControl3();
                    _USER_CONTROL = _UserControl3;
                    break;
                case "UserControl4":
                    if (_UserControl4 == null) _UserControl4 = new UserControl4();
                    _USER_CONTROL = _UserControl4;
                    break;
                case "UserControl5":
                    if (_UserControl5 == null) _UserControl5 = new UserControl5();
                    _USER_CONTROL = _UserControl5;
                    break;
                case "UserControl6":
                    if (_UserControl6 == null) _UserControl6 = new UserControl6();
                    _USER_CONTROL = _UserControl6;
                    break;
                case "UserControl7":
                    if (_UserControl7 == null) _UserControl7 = new UserControl7();
                    _USER_CONTROL = _UserControl7;
                    break;
            }

            _SettingUcl.Visible = false;
            _SettingUcl.SendToBack();

            _USER_CONTROL.BringToFront();
            _USER_CONTROL.Dock = DockStyle.Fill;
            pnlSetting.Controls.Add(_USER_CONTROL);
        }

        private void ClearAllUcl()
        {
            try
            {
                if (_UserControl1 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl1);
                    _UserControl1.CloseBrowser();
                    _UserControl1 = null;
                }

                if (_UserControl2 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl2);
                    _UserControl2 = null;
                }

                if (_UserControl3 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl3);
                    _UserControl3 = null;
                }

                if (_UserControl4 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl4);
                    _UserControl4 = null;
                }

                if (_UserControl5 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl5);
                    _UserControl5 = null;
                }

                if (_UserControl6 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl6);
                    _UserControl6 = null;
                }

                if (_UserControl7 != null)
                {
                    pnlSetting.Controls.Remove(_UserControl7);
                    _UserControl7 = null;
                }
            }
            catch { }
        }

        public void GoSettingUcl()
        {
            //유저 컨트롤 전체 초기화
            ClearAllUcl();

            _SettingUcl.Visible = true;
            _SettingUcl.BringToFront();
        }

        public void SettingUclClear(bool bReload = false)
        {
            //유저 컨트롤 전체 초기화
            ClearAllUcl();

            //설정 컨트롤 초기화
            if (_SettingUcl != null)
            {
                pnlSetting.Controls.Remove(_SettingUcl);
                _SettingUcl.Dispose();
                _SettingUcl = null;
            }

            pnlSetting.Controls.Clear();

            SetPanelIndex(2);

            //메인내 설정 패널을 채운다
            this.pnlBrowser.Dock = DockStyle.Fill;
            this.pnlBrowser.BringToFront();

            //브라우저 리로드 여부
            if (bReload) ReLoadBrowser();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case clsWin32Api.WM_COPYDATA:
                    {
                        try
                        {
                            clsWin32Api.COPYDATASTRUCT cDataStruct = new clsWin32Api.COPYDATASTRUCT();
                            cDataStruct = (clsWin32Api.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(clsWin32Api.COPYDATASTRUCT));

                            if (cDataStruct.cbData > 0)
                            {
                                if (cDataStruct.dwData.ToString() == "100")
                                {
                                    Invoke(new MethodInvoker(delegate() { ApplicationExit(); }));
                                }
                                else if (cDataStruct.dwData.ToString() == "101")
                                {
                                    Invoke(new MethodInvoker(delegate() { DownLoadFile(cDataStruct.lpData); }));
                                }
                            }
                        }
                        catch { }
                    }
                    break;
            }
            base.WndProc(ref m);
        }   

    }
}
