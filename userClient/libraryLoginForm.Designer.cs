﻿namespace WindowsFormsApp1
{
    partial class libraryLoginForm
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBtn = new System.Windows.Forms.Button();
            this.idTbx = new System.Windows.Forms.TextBox();
            this.libraryLbl = new System.Windows.Forms.Label();
            this.pwdLbl = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.pwdTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(392, 472);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(95, 32);
            this.loginBtn.TabIndex = 11;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // idTbx
            // 
            this.idTbx.Location = new System.Drawing.Point(329, 289);
            this.idTbx.Name = "idTbx";
            this.idTbx.Size = new System.Drawing.Size(227, 21);
            this.idTbx.TabIndex = 9;
            // 
            // libraryLbl
            // 
            this.libraryLbl.AutoSize = true;
            this.libraryLbl.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryLbl.Location = new System.Drawing.Point(369, 189);
            this.libraryLbl.Name = "libraryLbl";
            this.libraryLbl.Size = new System.Drawing.Size(148, 36);
            this.libraryLbl.TabIndex = 8;
            this.libraryLbl.Text = "Library";
            // 
            // pwdLbl
            // 
            this.pwdLbl.AutoSize = true;
            this.pwdLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdLbl.Location = new System.Drawing.Point(204, 382);
            this.pwdLbl.Name = "pwdLbl";
            this.pwdLbl.Size = new System.Drawing.Size(106, 33);
            this.pwdLbl.TabIndex = 7;
            this.pwdLbl.Text = "Password";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLbl.Location = new System.Drawing.Point(253, 286);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(36, 33);
            this.idLbl.TabIndex = 6;
            this.idLbl.Text = "ID";
            // 
            // pwdTbx
            // 
            this.pwdTbx.Location = new System.Drawing.Point(329, 393);
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.Size = new System.Drawing.Size(227, 21);
            this.pwdTbx.TabIndex = 12;
            // 
            // libraryLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.idTbx);
            this.Controls.Add(this.libraryLbl);
            this.Controls.Add(this.pwdLbl);
            this.Controls.Add(this.idLbl);
            this.Name = "libraryLoginForm";
            this.Size = new System.Drawing.Size(862, 817);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox idTbx;
        private System.Windows.Forms.Label libraryLbl;
        private System.Windows.Forms.Label pwdLbl;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.TextBox pwdTbx;
    }
}