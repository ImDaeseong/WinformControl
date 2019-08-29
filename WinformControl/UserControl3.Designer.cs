namespace WinformControl
{
    partial class UserControl3
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
            this.underlineTextBox1 = new WinformControl.Controls.UnderlineTextBox();
            this.headtitle1 = new WinformControl.Controls.Headtitle();
            this.pnlsize.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlsize
            // 
            this.pnlsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlsize.Controls.Add(this.underlineTextBox1);
            this.pnlsize.Location = new System.Drawing.Point(204, 233);
            this.pnlsize.Name = "pnlsize";
            this.pnlsize.Size = new System.Drawing.Size(390, 200);
            this.pnlsize.TabIndex = 0;
            // 
            // underlineTextBox1
            // 
            this.underlineTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.underlineTextBox1.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.underlineTextBox1.ForeColor = System.Drawing.Color.White;
            this.underlineTextBox1.LabeltxtName = "";
            this.underlineTextBox1.Location = new System.Drawing.Point(0, 0);
            this.underlineTextBox1.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.underlineTextBox1.Name = "underlineTextBox1";
            this.underlineTextBox1.Size = new System.Drawing.Size(390, 40);
            this.underlineTextBox1.TabIndex = 0;
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
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.headtitle1);
            this.Controls.Add(this.pnlsize);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(798, 549);
            this.pnlsize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlsize;
        private Controls.Headtitle headtitle1;
        private Controls.UnderlineTextBox underlineTextBox1;
    }
}
