namespace WinformControl.Controls
{
    partial class HeadmainTitle
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
            this.SettingButton = new WinformControl.Controls.ImageButton();
            this.Mimimize = new WinformControl.Controls.ImageButton();
            this.Maximize = new WinformControl.Controls.ImageButton();
            this.close = new WinformControl.Controls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.SettingButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mimimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingButton
            // 
            this.SettingButton.Location = new System.Drawing.Point(270, 14);
            this.SettingButton.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SettingButton.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.ResourceImage = global::WinformControl.Properties.Resources.setting;
            this.SettingButton.Size = new System.Drawing.Size(70, 70);
            this.SettingButton.TabIndex = 3;
            this.SettingButton.TabStop = false;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // Mimimize
            // 
            this.Mimimize.Location = new System.Drawing.Point(362, 14);
            this.Mimimize.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Mimimize.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.Mimimize.Name = "Mimimize";
            this.Mimimize.ResourceImage = global::WinformControl.Properties.Resources.hide;
            this.Mimimize.Size = new System.Drawing.Size(70, 70);
            this.Mimimize.TabIndex = 2;
            this.Mimimize.TabStop = false;
            this.Mimimize.Click += new System.EventHandler(this.Mimimize_Click);
            // 
            // Maximize
            // 
            this.Maximize.Location = new System.Drawing.Point(449, 14);
            this.Maximize.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Maximize.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.Maximize.Name = "Maximize";
            this.Maximize.ResourceImage = global::WinformControl.Properties.Resources.full;
            this.Maximize.Size = new System.Drawing.Size(70, 70);
            this.Maximize.TabIndex = 1;
            this.Maximize.TabStop = false;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(534, 14);
            this.close.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.close.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.close.Name = "close";
            this.close.ResourceImage = global::WinformControl.Properties.Resources.close;
            this.close.Size = new System.Drawing.Size(70, 70);
            this.close.TabIndex = 0;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // HeadmainTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.Mimimize);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.close);
            this.Name = "HeadmainTitle";
            this.Size = new System.Drawing.Size(623, 100);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HeadmainTitle_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeadmainTitle_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.SettingButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mimimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton close;
        private ImageButton Maximize;
        private ImageButton Mimimize;
        private ImageButton SettingButton;
    }
}
