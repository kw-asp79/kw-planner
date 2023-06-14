namespace Client
{
    partial class KLASLoginForm
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
            this.pwdTbx.AcceptsTab = true;
            this.pwdTbx.Location = new System.Drawing.Point(524, 484);
            this.pwdTbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.PasswordChar = '*';
            this.pwdTbx.Size = new System.Drawing.Size(223, 28);
            this.pwdTbx.TabIndex = 10;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.LightBlue;
            this.loginBtn.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(562, 551);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(136, 48);
            this.loginBtn.TabIndex = 11;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // idTbx
            // 
            this.idTbx.AcceptsTab = true;
            this.idTbx.Location = new System.Drawing.Point(524, 402);
            this.idTbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.idTbx.Name = "idTbx";
            this.idTbx.Size = new System.Drawing.Size(223, 28);
            this.idTbx.TabIndex = 9;
            // 
            // klasLbl
            // 
            this.klasLbl.AutoSize = true;
            this.klasLbl.BackColor = System.Drawing.Color.Transparent;
            this.klasLbl.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klasLbl.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.klasLbl.Location = new System.Drawing.Point(494, 231);
            this.klasLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.klasLbl.Name = "klasLbl";
            this.klasLbl.Size = new System.Drawing.Size(230, 102);
            this.klasLbl.TabIndex = 14;
            this.klasLbl.Text = "KLAS";
            // 
            // pwdLbl
            // 
            this.pwdLbl.AutoSize = true;
            this.pwdLbl.BackColor = System.Drawing.Color.Transparent;
            this.pwdLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdLbl.Location = new System.Drawing.Point(351, 467);
            this.pwdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdLbl.Name = "pwdLbl";
            this.pwdLbl.Size = new System.Drawing.Size(159, 50);
            this.pwdLbl.TabIndex = 13;
            this.pwdLbl.Text = "Password";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.BackColor = System.Drawing.Color.Transparent;
            this.idLbl.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLbl.Location = new System.Drawing.Point(451, 386);
            this.idLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(54, 50);
            this.idLbl.TabIndex = 12;
            this.idLbl.Text = "ID";
            // 
            // KLASLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.kw_blur1;
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.idTbx);
            this.Controls.Add(this.klasLbl);
            this.Controls.Add(this.pwdLbl);
            this.Controls.Add(this.idLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KLASLoginForm";
            this.Size = new System.Drawing.Size(1231, 1226);
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
