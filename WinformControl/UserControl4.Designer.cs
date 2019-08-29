namespace WinformControl
{
    partial class UserControl4
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
            this.trackBarEx1 = new WinformControl.Controls.TrackBarEx();
            this.headtitle1 = new WinformControl.Controls.Headtitle();
            this.pnlsize.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlsize
            // 
            this.pnlsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlsize.Controls.Add(this.trackBarEx1);
            this.pnlsize.Location = new System.Drawing.Point(204, 233);
            this.pnlsize.Name = "pnlsize";
            this.pnlsize.Size = new System.Drawing.Size(411, 200);
            this.pnlsize.TabIndex = 0;
            // 
            // trackBarEx1
            // 
            this.trackBarEx1.BackColor = System.Drawing.Color.Transparent;
            this.trackBarEx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarEx1.Location = new System.Drawing.Point(3, 79);
            this.trackBarEx1.LRMargins = 40;
            this.trackBarEx1.Maximum = 10;
            this.trackBarEx1.Minimum = 0;
            this.trackBarEx1.Name = "trackBarEx1";
            this.trackBarEx1.Size = new System.Drawing.Size(405, 49);
            this.trackBarEx1.TabIndex = 0;
            this.trackBarEx1.TrackHeight = 4;
            this.trackBarEx1.Value = 0D;
            this.trackBarEx1.ValueChanged += new System.EventHandler(this.trackBarEx1_ValueChanged);
            this.trackBarEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarEx1_MouseUp);
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
            // UserControl4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.headtitle1);
            this.Controls.Add(this.pnlsize);
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(798, 549);
            this.pnlsize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlsize;
        private Controls.Headtitle headtitle1;
        private Controls.TrackBarEx trackBarEx1;
    }
}
