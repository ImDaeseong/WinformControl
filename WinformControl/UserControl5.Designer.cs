namespace WinformControl
{
    partial class UserControl5
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlsize = new System.Windows.Forms.Panel();
            this.loadingSpiner = new WinformControl.Controls.RotatePictureBox();
            this.headtitle1 = new WinformControl.Controls.Headtitle();
            this.progressBarBorderColor1 = new WinformControl.Controls.ProgressBarBorderColor();
            this.pnlsize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpiner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlsize
            // 
            this.pnlsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlsize.Controls.Add(this.progressBarBorderColor1);
            this.pnlsize.Controls.Add(this.loadingSpiner);
            this.pnlsize.Location = new System.Drawing.Point(204, 233);
            this.pnlsize.Name = "pnlsize";
            this.pnlsize.Size = new System.Drawing.Size(411, 200);
            this.pnlsize.TabIndex = 0;
            // 
            // loadingSpiner
            // 
            this.loadingSpiner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.loadingSpiner.Image = global::WinformControl.Properties.Resources.spinner;
            this.loadingSpiner.ImageDefault = global::WinformControl.Properties.Resources.spinner;
            this.loadingSpiner.Location = new System.Drawing.Point(180, 46);
            this.loadingSpiner.Name = "loadingSpiner";
            this.loadingSpiner.Size = new System.Drawing.Size(35, 35);
            this.loadingSpiner.TabIndex = 0;
            this.loadingSpiner.TabStop = false;
            this.loadingSpiner.Click += new System.EventHandler(this.loadingSpiner_Click);
            // 
            // headtitle1
            // 
            this.headtitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.headtitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headtitle1.LabelText = "";
            this.headtitle1.Location = new System.Drawing.Point(0, 0);
            this.headtitle1.Name = "headtitle1";
            this.headtitle1.Size = new System.Drawing.Size(798, 50);
            this.headtitle1.TabIndex = 1;
            // 
            // progressBarBorderColor1
            // 
            this.progressBarBorderColor1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(194)))), ((int)(((byte)(227)))));
            this.progressBarBorderColor1.Location = new System.Drawing.Point(80, 125);
            this.progressBarBorderColor1.Name = "progressBarBorderColor1";
            this.progressBarBorderColor1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.progressBarBorderColor1.Size = new System.Drawing.Size(265, 23);
            this.progressBarBorderColor1.TabIndex = 1;
            // 
            // UserControl5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.headtitle1);
            this.Controls.Add(this.pnlsize);
            this.Name = "UserControl5";
            this.Size = new System.Drawing.Size(798, 549);
            this.pnlsize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpiner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlsize;
        private Controls.Headtitle headtitle1;
        private Controls.RotatePictureBox loadingSpiner;
        private Controls.ProgressBarBorderColor progressBarBorderColor1;
    }
}
