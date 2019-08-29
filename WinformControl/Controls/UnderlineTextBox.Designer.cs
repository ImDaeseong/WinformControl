namespace WinformControl.Controls
{
    partial class UnderlineTextBox
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.hLine1 = new WinformControl.Controls.hLine();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 21);
            this.txtName.TabIndex = 0;
            // 
            // hLine1
            // 
            this.hLine1.BackColor = System.Drawing.Color.Black;
            this.hLine1.LineBorder = 1;
            this.hLine1.LineColor = System.Drawing.Color.Black;
            this.hLine1.Location = new System.Drawing.Point(0, 22);
            this.hLine1.Margin = new System.Windows.Forms.Padding(0);
            this.hLine1.Name = "hLine1";
            this.hLine1.Size = new System.Drawing.Size(150, 1);
            this.hLine1.TabIndex = 1;
            // 
            // UnderlineTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hLine1);
            this.Controls.Add(this.txtName);
            this.Name = "UnderlineTextBox";
            this.Size = new System.Drawing.Size(150, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private hLine hLine1;
    }
}
