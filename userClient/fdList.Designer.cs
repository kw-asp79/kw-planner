﻿using System.Windows.Forms;

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
            this.fdlistLbl.Font = new System.Drawing.Font("Segoe Script", 20F, System.Drawing.FontStyle.Bold);
            this.fdlistLbl.Location = new System.Drawing.Point(339, 33);
            this.fdlistLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fdlistLbl.Name = "fdlistLbl";
            this.fdlistLbl.Size = new System.Drawing.Size(138, 44);
            this.fdlistLbl.TabIndex = 2;
            this.fdlistLbl.Text = "친구 목록";
            // 
            // btn_addfd
            // 
            this.btn_addfd.BackColor = System.Drawing.Color.Transparent;
            this.btn_addfd.Location = new System.Drawing.Point(631, 74);
            this.btn_addfd.Name = "btn_addfd";
            this.btn_addfd.Size = new System.Drawing.Size(68, 30);
            this.btn_addfd.TabIndex = 3;
            this.btn_addfd.Text = "친구 추가";
            this.btn_addfd.UseVisualStyleBackColor = false;
            this.btn_addfd.Click += new System.EventHandler(this.btn_addfd_Click);
            // 
            // fdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.kw_blur1;
            this.ClientSize = new System.Drawing.Size(770, 497);
            this.Controls.Add(this.btn_addfd);
            this.Controls.Add(this.fdlistLbl);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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