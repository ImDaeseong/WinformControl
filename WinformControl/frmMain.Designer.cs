namespace WinformControl
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.pnlSplash = new WinformControl.Controls.SplashPanel();
            this.headmainTitle1 = new WinformControl.Controls.HeadmainTitle();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Location = new System.Drawing.Point(406, 169);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(100, 100);
            this.pnlBrowser.TabIndex = 1;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Location = new System.Drawing.Point(47, 169);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(100, 100);
            this.pnlSetting.TabIndex = 2;
            // 
            // pnlSplash
            // 
            this.pnlSplash.Location = new System.Drawing.Point(235, 169);
            this.pnlSplash.Name = "pnlSplash";
            this.pnlSplash.ResourceImage = global::WinformControl.Properties.Resources.splash;
            this.pnlSplash.Size = new System.Drawing.Size(100, 100);
            this.pnlSplash.TabIndex = 3;
            // 
            // headmainTitle1
            // 
            this.headmainTitle1.BackColor = System.Drawing.Color.Black;
            this.headmainTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headmainTitle1.Location = new System.Drawing.Point(1, 1);
            this.headmainTitle1.Name = "headmainTitle1";
            this.headmainTitle1.Size = new System.Drawing.Size(798, 100);
            this.headmainTitle1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlSplash);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.headmainTitle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.HeadmainTitle headmainTitle1;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.Panel pnlSetting;
        private Controls.SplashPanel pnlSplash;
    }
}

