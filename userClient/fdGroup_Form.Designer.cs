﻿namespace Client
{
    partial class fdGroup_Form
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
            this.btn_addfd = new System.Windows.Forms.Button();
            this.fdlistLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_addfd
            // 
            this.btn_addfd.BackColor = System.Drawing.SystemColors.Control;
            this.btn_addfd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_addfd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_addfd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_addfd.Location = new System.Drawing.Point(607, 65);
            this.btn_addfd.Name = "btn_addfd";
            this.btn_addfd.Size = new System.Drawing.Size(99, 30);
            this.btn_addfd.TabIndex = 5;
            this.btn_addfd.Text = "신규그룹 추가";
            this.btn_addfd.UseVisualStyleBackColor = false;
            this.btn_addfd.Click += new System.EventHandler(this.btn_addfd_Click);
            // 
            // fdlistLbl
            // 
            this.fdlistLbl.AutoSize = true;
            this.fdlistLbl.BackColor = System.Drawing.Color.Transparent;
            this.fdlistLbl.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlistLbl.ForeColor = System.Drawing.Color.LightCyan;
            this.fdlistLbl.Location = new System.Drawing.Point(229, 28);
            this.fdlistLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fdlistLbl.Name = "fdlistLbl";
            this.fdlistLbl.Size = new System.Drawing.Size(338, 67);
            this.fdlistLbl.TabIndex = 4;
            this.fdlistLbl.Text = "친구그룹 목록";
            // 
            // fdGroup_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.bima_blur4;
            this.ClientSize = new System.Drawing.Size(846, 820);
            this.Controls.Add(this.btn_addfd);
            this.Controls.Add(this.fdlistLbl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fdGroup_Form";
            this.Text = "친구그룹 목록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addfd;
        private System.Windows.Forms.Label fdlistLbl;
    }
}