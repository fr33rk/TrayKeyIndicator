namespace TrayKeyIndicator
{
    partial class FrmMain
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
            this.lblCapsLock = new System.Windows.Forms.Label();
            this.lblNumLock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCapsLock
            // 
            this.lblCapsLock.AutoSize = true;
            this.lblCapsLock.Location = new System.Drawing.Point(54, 90);
            this.lblCapsLock.Name = "lblCapsLock";
            this.lblCapsLock.Size = new System.Drawing.Size(107, 13);
            this.lblCapsLock.TabIndex = 0;
            this.lblCapsLock.Text = "Caps Lock Unknown";
            // 
            // lblNumLock
            // 
            this.lblNumLock.AutoSize = true;
            this.lblNumLock.Location = new System.Drawing.Point(54, 153);
            this.lblNumLock.Name = "lblNumLock";
            this.lblNumLock.Size = new System.Drawing.Size(102, 13);
            this.lblNumLock.TabIndex = 1;
            this.lblNumLock.Text = "NumLock Unknown";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblNumLock);
            this.Controls.Add(this.lblCapsLock);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.FrmMain_ResizeBegin);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCapsLock;
        private System.Windows.Forms.Label lblNumLock;
    }
}

