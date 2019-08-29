namespace WinformControl.Controls
{
    partial class Headtitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Headtitle));
            this.lbltitle = new System.Windows.Forms.Label();
            this.pictureBoxEx1 = new WinformControl.Controls.PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(52, 12);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(50, 25);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "제목";
            this.lbltitle.Click += new System.EventHandler(this.lbltitle_Click);
            // 
            // pictureBoxEx1
            // 
            this.pictureBoxEx1.Location = new System.Drawing.Point(17, 10);
            this.pictureBoxEx1.Name = "pictureBoxEx1";
            this.pictureBoxEx1.ResourceImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxEx1.ResourceImage")));
            this.pictureBoxEx1.Size = new System.Drawing.Size(29, 27);
            this.pictureBoxEx1.TabIndex = 0;
            this.pictureBoxEx1.TabStop = false;
            this.pictureBoxEx1.Click += new System.EventHandler(this.pictureBoxEx1_Click);
            // 
            // Headtitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.pictureBoxEx1);
            this.Name = "Headtitle";
            this.Size = new System.Drawing.Size(529, 50);
            this.Click += new System.EventHandler(this.Headtitle_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBoxEx pictureBoxEx1;
        private System.Windows.Forms.Label lbltitle;

    }
}
