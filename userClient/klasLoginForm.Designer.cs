namespace Client
{
    partial class klasLoginForm
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
            this.pwdTbx = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.idTbx = new System.Windows.Forms.TextBox();
            this.klasLbl = new System.Windows.Forms.Label();
            this.pwdLbl = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pwdTbx
            // 
            this.pwdTbx.Location = new System.Drawing.Point(377, 490);
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.Size = new System.Drawing.Size(259, 25);
            this.pwdTbx.TabIndex = 18;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(449, 588);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(109, 40);
            this.loginBtn.TabIndex = 17;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // idTbx
            // 
            this.idTbx.Location = new System.Drawing.Point(377, 360);
            this.idTbx.Name = "idTbx";
            this.idTbx.Size = new System.Drawing.Size(259, 25);
            this.idTbx.TabIndex = 16;
            // 
            // klasLbl
            // 
            this.klasLbl.AutoSize = true;
            this.klasLbl.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klasLbl.Location = new System.Drawing.Point(465, 238);
            this.klasLbl.Name = "klasLbl";
            this.klasLbl.Size = new System.Drawing.Size(116, 46);
            this.klasLbl.TabIndex = 15;
            this.klasLbl.Text = "KLAS";
            // 
            // pwdLbl
            // 
            this.pwdLbl.AutoSize = true;
            this.pwdLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdLbl.Location = new System.Drawing.Point(234, 477);
            this.pwdLbl.Name = "pwdLbl";
            this.pwdLbl.Size = new System.Drawing.Size(132, 42);
            this.pwdLbl.TabIndex = 14;
            this.pwdLbl.Text = "Password";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLbl.Location = new System.Drawing.Point(290, 357);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(45, 42);
            this.idLbl.TabIndex = 13;
            this.idLbl.Text = "ID";
            // 
            // klasLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.idTbx);
            this.Controls.Add(this.klasLbl);
            this.Controls.Add(this.pwdLbl);
            this.Controls.Add(this.idLbl);
            this.Name = "klasLoginForm";
            this.Size = new System.Drawing.Size(985, 1022);
            this.Load += new System.EventHandler(this.klasLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwdTbx;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox idTbx;
        private System.Windows.Forms.Label klasLbl;
        private System.Windows.Forms.Label pwdLbl;
        private System.Windows.Forms.Label idLbl;
    }
}
