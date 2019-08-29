namespace WinformControl.Controls
{
    partial class addBar
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
            this.noLabel = new System.Windows.Forms.Label();
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.lblLabel2 = new System.Windows.Forms.Label();
            this.delButton = new WinformControl.Controls.RoundButton();
            this.hLine1 = new WinformControl.Controls.hLine();
            this.SuspendLayout();
            // 
            // noLabel
            // 
            this.noLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.noLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.noLabel.Location = new System.Drawing.Point(23, 23);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(40, 18);
            this.noLabel.TabIndex = 3;
            this.noLabel.Text = "번호";
            // 
            // lblLabel1
            // 
            this.lblLabel1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblLabel1.Location = new System.Drawing.Point(99, 23);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(81, 18);
            this.lblLabel1.TabIndex = 4;
            this.lblLabel1.Text = "내용1";
            // 
            // lblLabel2
            // 
            this.lblLabel2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblLabel2.Location = new System.Drawing.Point(270, 23);
            this.lblLabel2.Name = "lblLabel2";
            this.lblLabel2.Size = new System.Drawing.Size(102, 18);
            this.lblLabel2.TabIndex = 5;
            this.lblLabel2.Text = "내용2";
            // 
            // delButton
            // 
            this.delButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(186)))), ((int)(((byte)(198)))));
            this.delButton.Location = new System.Drawing.Point(464, 9);
            this.delButton.Name = "delButton";
            this.delButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(186)))), ((int)(((byte)(198)))));
            this.delButton.Size = new System.Drawing.Size(54, 40);
            this.delButton.TabIndex = 15;
            this.delButton.Text = "삭제";
            this.delButton.TextColor = System.Drawing.Color.White;
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // hLine1
            // 
            this.hLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(186)))), ((int)(((byte)(198)))));
            this.hLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hLine1.LineBorder = 1;
            this.hLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(186)))), ((int)(((byte)(198)))));
            this.hLine1.Location = new System.Drawing.Point(0, 59);
            this.hLine1.Margin = new System.Windows.Forms.Padding(0);
            this.hLine1.Name = "hLine1";
            this.hLine1.Size = new System.Drawing.Size(552, 1);
            this.hLine1.TabIndex = 0;
            // 
            // addBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.lblLabel2);
            this.Controls.Add(this.lblLabel1);
            this.Controls.Add(this.noLabel);
            this.Controls.Add(this.hLine1);
            this.Name = "addBar";
            this.Size = new System.Drawing.Size(552, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private hLine hLine1;
        private System.Windows.Forms.Label noLabel;
        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.Label lblLabel2;
        private RoundButton delButton;
    }
}
