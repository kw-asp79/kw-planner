﻿namespace Client
{
    partial class LibraryLoadingForm
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
            this.crawlingPBar = new System.Windows.Forms.ProgressBar();
            this.statusLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crawlingPBar
            // 
            this.crawlingPBar.BackColor = System.Drawing.Color.DimGray;
            this.crawlingPBar.ForeColor = System.Drawing.Color.Gold;
            this.crawlingPBar.Location = new System.Drawing.Point(12, 84);
            this.crawlingPBar.MarqueeAnimationSpeed = 400;
            this.crawlingPBar.Name = "crawlingPBar";
            this.crawlingPBar.Size = new System.Drawing.Size(375, 23);
            this.crawlingPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.crawlingPBar.TabIndex = 0;
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("SimSun-ExtB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(105, 37);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(175, 19);
            this.statusLbl.TabIndex = 1;
            this.statusLbl.Text = "로그인 진행 중입니다..";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LibraryLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(399, 117);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.crawlingPBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LibraryLoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraryLoadingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar crawlingPBar;
        private System.Windows.Forms.Label statusLbl;
    }
}