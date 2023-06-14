namespace Client
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
            this.crawlingLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crawlingPBar
            // 
            this.crawlingPBar.BackColor = System.Drawing.Color.DimGray;
            this.crawlingPBar.ForeColor = System.Drawing.Color.Gold;
            this.crawlingPBar.Location = new System.Drawing.Point(17, 126);
            this.crawlingPBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crawlingPBar.MarqueeAnimationSpeed = 400;
            this.crawlingPBar.Name = "crawlingPBar";
            this.crawlingPBar.Size = new System.Drawing.Size(536, 34);
            this.crawlingPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.crawlingPBar.TabIndex = 0;
            // 
            // statusLbl
            // 
            this.statusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("SimSun-ExtB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(157, 56);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(262, 29);
            this.statusLbl.TabIndex = 1;
            this.statusLbl.Text = "로그인 진행 중입니다..";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // crawlingLbl
            // 
            this.crawlingLbl.AutoSize = true;
            this.crawlingLbl.Location = new System.Drawing.Point(107, 84);
            this.crawlingLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.crawlingLbl.Name = "crawlingLbl";
            this.crawlingLbl.Size = new System.Drawing.Size(0, 18);
            this.crawlingLbl.TabIndex = 2;
            // 
            // LibraryLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(570, 176);
            this.Controls.Add(this.crawlingLbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.crawlingPBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LibraryLoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "도서관 로딩중..";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar crawlingPBar;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label crawlingLbl;
    }
}