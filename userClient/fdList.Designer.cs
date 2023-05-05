namespace WindowsFormsApp1
{
    partial class fdList
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
            this.fdlistLbl = new System.Windows.Forms.Label();
            this.btn_addfd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fdlistLbl
            // 
            this.fdlistLbl.AutoSize = true;
            this.fdlistLbl.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlistLbl.Location = new System.Drawing.Point(141, 36);
            this.fdlistLbl.Name = "fdlistLbl";
            this.fdlistLbl.Size = new System.Drawing.Size(107, 34);
            this.fdlistLbl.TabIndex = 2;
            this.fdlistLbl.Text = "친구 목록";
            // 
            // btn_addfd
            // 
            this.btn_addfd.Location = new System.Drawing.Point(274, 41);
            this.btn_addfd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_addfd.Name = "btn_addfd";
            this.btn_addfd.Size = new System.Drawing.Size(68, 30);
            this.btn_addfd.TabIndex = 3;
            this.btn_addfd.Text = "친구 추가";
            this.btn_addfd.UseVisualStyleBackColor = true;
            this.btn_addfd.Click += new System.EventHandler(this.btn_addfd_Click);
            // 
            // fdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 497);
            this.Controls.Add(this.btn_addfd);
            this.Controls.Add(this.fdlistLbl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fdList";
            this.Text = "fdList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fdlistLbl;
        private System.Windows.Forms.Button btn_addfd;
    }
}