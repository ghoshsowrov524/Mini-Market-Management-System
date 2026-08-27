namespace Mini_Market_Management_System
{
    partial class SplashForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading...";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.BorderRadius = 5;
            this.ProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.ProgressBar1.Location = new System.Drawing.Point(188, 202);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.ProgressColor2 = System.Drawing.Color.SeaGreen;
            this.ProgressBar1.ShadowDecoration.Parent = this.ProgressBar1;
            this.ProgressBar1.Size = new System.Drawing.Size(315, 30);
            this.ProgressBar1.TabIndex = 1;
            this.ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(245, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mini Market";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}