namespace WinformControl.Controls
{
    partial class ToggleButtonEx
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
            this.roundedPanel1 = new WinformControl.Controls.RoundedPanel();
            this.offButton1 = new WinformControl.Controls.OffButton();
            this.onButton1 = new WinformControl.Controls.OnButton();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.roundedPanel1.BorderWidth = 1;
            this.roundedPanel1.Controls.Add(this.offButton1);
            this.roundedPanel1.Controls.Add(this.onButton1);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.NormalColor = System.Drawing.Color.White;
            this.roundedPanel1.Radius = 2;
            this.roundedPanel1.Size = new System.Drawing.Size(84, 39);
            this.roundedPanel1.TabIndex = 0;
            this.roundedPanel1.Click += new System.EventHandler(this.roundedPanel1_Click);
            // 
            // offButton1
            // 
            this.offButton1.Location = new System.Drawing.Point(42, 0);
            this.offButton1.Name = "offButton1";
            this.offButton1.Size = new System.Drawing.Size(42, 39);
            this.offButton1.TabIndex = 1;
            this.offButton1.Text = "offButton1";
            this.offButton1.UseVisualStyleBackColor = true;
            this.offButton1.Click += new System.EventHandler(this.offButton1_Click);
            // 
            // onButton1
            // 
            this.onButton1.Location = new System.Drawing.Point(0, 0);
            this.onButton1.Name = "onButton1";
            this.onButton1.Size = new System.Drawing.Size(42, 39);
            this.onButton1.TabIndex = 0;
            this.onButton1.Text = "onButton1";
            this.onButton1.UseVisualStyleBackColor = true;
            this.onButton1.Click += new System.EventHandler(this.onButton1_Click);
            // 
            // ToggleButtonEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundedPanel1);
            this.Name = "ToggleButtonEx";
            this.Size = new System.Drawing.Size(84, 39);
            this.roundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private OffButton offButton1;
        private OnButton onButton1;
    }
}
