using System.Windows.Forms;

namespace Client
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
            this.fdlistLbl.BackColor = System.Drawing.Color.Transparent;
            this.fdlistLbl.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlistLbl.ForeColor = System.Drawing.Color.LightCyan;
            this.fdlistLbl.Location = new System.Drawing.Point(298, 34);
            this.fdlistLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.fdlistLbl.Name = "fdlistLbl";
            this.fdlistLbl.Size = new System.Drawing.Size(242, 67);
            this.fdlistLbl.TabIndex = 2;
            this.fdlistLbl.Text = "친구 목록";
            // 
            // btn_addfd
            // 
            this.btn_addfd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_addfd.Location = new System.Drawing.Point(607, 65);
            this.btn_addfd.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addfd.Name = "btn_addfd";
            this.btn_addfd.Size = new System.Drawing.Size(99, 30);
            this.btn_addfd.TabIndex = 3;
            this.btn_addfd.Text = "친구 추가";
            this.btn_addfd.UseVisualStyleBackColor = false;
            this.btn_addfd.Click += new System.EventHandler(this.btn_addfd_Click);
            // 
            // fdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.bima_blur4;
            this.ClientSize = new System.Drawing.Size(846, 821);
            this.Controls.Add(this.btn_addfd);
            this.Controls.Add(this.fdlistLbl);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "fdList";
            this.Text = "친구 목록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fdlistLbl;
        private System.Windows.Forms.Button btn_addfd;
    }
}