namespace WinformControl
{
    partial class frmLogout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mouseoverButton1 = new WinformControl.Controls.MouseoverButton();
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton1 = new WinformControl.Controls.RoundButton();
            this.SuspendLayout();
            // 
            // mouseoverButton1
            // 
            this.mouseoverButton1.Image = global::WinformControl.Properties.Resources.close_black;
            this.mouseoverButton1.Location = new System.Drawing.Point(536, 12);
            this.mouseoverButton1.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mouseoverButton1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mouseoverButton1.Name = "mouseoverButton1";
            this.mouseoverButton1.Size = new System.Drawing.Size(32, 32);
            this.mouseoverButton1.TabIndex = 0;
            this.mouseoverButton1.Text = "mouseoverButton1";
            this.mouseoverButton1.UseVisualStyleBackColor = true;
            this.mouseoverButton1.Click += new System.EventHandler(this.mouseoverButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(149, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "로그아웃 하시겠어요?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // roundButton1
            // 
            this.roundButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.roundButton1.Location = new System.Drawing.Point(90, 256);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.roundButton1.Size = new System.Drawing.Size(390, 60);
            this.roundButton1.TabIndex = 0;
            this.roundButton1.Text = "로그아웃";
            this.roundButton1.TextColor = System.Drawing.Color.Black;
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // frmLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(580, 400);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mouseoverButton1);
            this.Name = "frmLogout";
            this.Text = "frmLogout";
            this.Load += new System.EventHandler(this.frmLogout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MouseoverButton mouseoverButton1;
        private System.Windows.Forms.Label label1;
        private Controls.RoundButton roundButton1;
    }
}