namespace WinformControl
{
    partial class UserControl7
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
            this.headtitle1 = new WinformControl.Controls.Headtitle();
            this.pnlScroll = new WinformControl.Controls.DoubleBufferPanel();
            this.pnl1View = new WinformControl.Controls.DoubleBufferPanel();
            this.roundButton1 = new WinformControl.Controls.RoundButton();
            this.pnlsize.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnl1View.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlsize
            // 
            this.pnlsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlsize.Controls.Add(this.pnlScroll);
            this.pnlsize.Location = new System.Drawing.Point(39, 96);
            this.pnlsize.Name = "pnlsize";
            this.pnlsize.Size = new System.Drawing.Size(622, 245);
            this.pnlsize.TabIndex = 0;
            // 
            // headtitle1
            // 
            this.headtitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.headtitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headtitle1.LabelText = "";
            this.headtitle1.Location = new System.Drawing.Point(0, 0);
            this.headtitle1.Name = "headtitle1";
            this.headtitle1.Size = new System.Drawing.Size(693, 50);
            this.headtitle1.TabIndex = 1;
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.pnlScroll.Controls.Add(this.pnl1View);
            this.pnlScroll.Location = new System.Drawing.Point(14, 18);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(576, 211);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnl1View
            // 
            this.pnl1View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnl1View.Controls.Add(this.roundButton1);
            this.pnl1View.Location = new System.Drawing.Point(3, 3);
            this.pnl1View.Name = "pnl1View";
            this.pnl1View.Size = new System.Drawing.Size(546, 100);
            this.pnl1View.TabIndex = 0;
            // 
            // roundButton1
            // 
            this.roundButton1.HoverColor = System.Drawing.Color.Silver;
            this.roundButton1.Location = new System.Drawing.Point(440, 19);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.NormalColor = System.Drawing.Color.White;
            this.roundButton1.Size = new System.Drawing.Size(93, 59);
            this.roundButton1.TabIndex = 0;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.TextColor = System.Drawing.Color.Black;
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // UserControl7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.headtitle1);
            this.Controls.Add(this.pnlsize);
            this.Name = "UserControl7";
            this.Size = new System.Drawing.Size(693, 391);
            this.pnlsize.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.pnl1View.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlsize;
        private Controls.Headtitle headtitle1;
        private Controls.DoubleBufferPanel pnlScroll;
        private Controls.DoubleBufferPanel pnl1View;
        private Controls.RoundButton roundButton1;
    }
}
