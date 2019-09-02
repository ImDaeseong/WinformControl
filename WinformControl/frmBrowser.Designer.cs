namespace WinformControl
{
    partial class frmBrowser
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
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.mouseoverButton1 = new WinformControl.Controls.MouseoverButton();
            this.pnlBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Controls.Add(this.mouseoverButton1);
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(500, 500);
            this.pnlBrowser.TabIndex = 0;
            // 
            // mouseoverButton1
            // 
            this.mouseoverButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mouseoverButton1.Image = global::WinformControl.Properties.Resources.close_black;
            this.mouseoverButton1.Location = new System.Drawing.Point(447, 18);
            this.mouseoverButton1.MouseNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mouseoverButton1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mouseoverButton1.Name = "mouseoverButton1";
            this.mouseoverButton1.Size = new System.Drawing.Size(32, 32);
            this.mouseoverButton1.TabIndex = 1;
            this.mouseoverButton1.Text = "mouseoverButton1";
            this.mouseoverButton1.UseVisualStyleBackColor = true;
            this.mouseoverButton1.Click += new System.EventHandler(this.mouseoverButton1_Click);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.pnlBrowser);
            this.Name = "frmBrowser";
            this.Text = "frmBrowser";
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            this.Resize += new System.EventHandler(this.frmBrowser_Resize);
            this.pnlBrowser.ResumeLayout(false);
            this.ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.Panel pnlBrowser;
        private Controls.MouseoverButton mouseoverButton1;

    }
}