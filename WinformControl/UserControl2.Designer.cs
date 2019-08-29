namespace WinformControl
{
    partial class UserControl2
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
            this.headtitle1 = new WinformControl.Controls.Headtitle();
            this.pnlsize = new System.Windows.Forms.Panel();
            this.comboBoxExLarge1 = new WinformControl.Controls.ComboBoxExLarge();
            this.comboBoxEx1 = new WinformControl.Controls.ComboBoxEx();
            this.pnlsize.SuspendLayout();
            this.SuspendLayout();
            // 
            // headtitle1
            // 
            this.headtitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.headtitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headtitle1.LabelText = "";
            this.headtitle1.Location = new System.Drawing.Point(0, 0);
            this.headtitle1.Name = "headtitle1";
            this.headtitle1.Size = new System.Drawing.Size(551, 50);
            this.headtitle1.TabIndex = 0;
            // 
            // pnlsize
            // 
            this.pnlsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlsize.Controls.Add(this.comboBoxEx1);
            this.pnlsize.Controls.Add(this.comboBoxExLarge1);
            this.pnlsize.Location = new System.Drawing.Point(64, 96);
            this.pnlsize.Name = "pnlsize";
            this.pnlsize.Size = new System.Drawing.Size(434, 245);
            this.pnlsize.TabIndex = 1;
            // 
            // comboBoxExLarge1
            // 
            this.comboBoxExLarge1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxExLarge1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxExLarge1.DropDownHeight = 150;
            this.comboBoxExLarge1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExLarge1.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.comboBoxExLarge1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboBoxExLarge1.FormattingEnabled = true;
            this.comboBoxExLarge1.IntegralHeight = false;
            this.comboBoxExLarge1.ItemHeight = 56;
            this.comboBoxExLarge1.Location = new System.Drawing.Point(18, 23);
            this.comboBoxExLarge1.Name = "comboBoxExLarge1";
            this.comboBoxExLarge1.Size = new System.Drawing.Size(190, 62);
            this.comboBoxExLarge1.TabIndex = 0;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxEx1.DropDownHeight = 100;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.comboBoxEx1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.IntegralHeight = false;
            this.comboBoxEx1.ItemHeight = 56;
            this.comboBoxEx1.Location = new System.Drawing.Point(226, 23);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(190, 62);
            this.comboBoxEx1.TabIndex = 1;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlsize);
            this.Controls.Add(this.headtitle1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(551, 391);
            this.pnlsize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Headtitle headtitle1;
        private System.Windows.Forms.Panel pnlsize;
        private Controls.ComboBoxEx comboBoxEx1;
        private Controls.ComboBoxExLarge comboBoxExLarge1;
    }
}
