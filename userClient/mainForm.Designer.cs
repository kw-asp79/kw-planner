namespace Client
{
    partial class mainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuContainer = new System.Windows.Forms.Panel();
            this.mainBtn = new System.Windows.Forms.Button();
            this.groupBtn = new System.Windows.Forms.Button();
            this.signupBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.todoBtn = new System.Windows.Forms.Button();
            this.fndBtn = new System.Windows.Forms.Button();
            this.lbyBtn = new System.Windows.Forms.Button();
            this.klasBtn = new System.Windows.Forms.Button();
            this.calendarContainer = new System.Windows.Forms.Panel();
            this.menuContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuContainer.Controls.Add(this.mainBtn);
            this.menuContainer.Controls.Add(this.groupBtn);
            this.menuContainer.Controls.Add(this.signupBtn);
            this.menuContainer.Controls.Add(this.loginBtn);
            this.menuContainer.Controls.Add(this.todoBtn);
            this.menuContainer.Controls.Add(this.fndBtn);
            this.menuContainer.Controls.Add(this.lbyBtn);
            this.menuContainer.Controls.Add(this.klasBtn);
            this.menuContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuContainer.Location = new System.Drawing.Point(0, 0);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(213, 879);
            this.menuContainer.TabIndex = 1;
            this.menuContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.menuContainer_Paint);
            // 
            // mainBtn
            // 
            this.mainBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainBtn.Location = new System.Drawing.Point(59, 72);
            this.mainBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.mainBtn.Name = "mainBtn";
            this.mainBtn.Size = new System.Drawing.Size(96, 40);
            this.mainBtn.TabIndex = 8;
            this.mainBtn.Text = "Main";
            this.mainBtn.UseVisualStyleBackColor = true;
            this.mainBtn.Click += new System.EventHandler(this.mainBtn_Click);
            // 
            // groupBtn
            // 
            this.groupBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBtn.Location = new System.Drawing.Point(59, 652);
            this.groupBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.groupBtn.Name = "groupBtn";
            this.groupBtn.Size = new System.Drawing.Size(96, 42);
            this.groupBtn.TabIndex = 6;
            this.groupBtn.Text = "Group";
            this.groupBtn.UseVisualStyleBackColor = true;
            // 
            // signupBtn
            // 
            this.signupBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupBtn.Location = new System.Drawing.Point(121, 972);
            this.signupBtn.Name = "signupBtn";
            this.signupBtn.Size = new System.Drawing.Size(82, 38);
            this.signupBtn.TabIndex = 5;
            this.signupBtn.Text = "signup";
            this.signupBtn.UseVisualStyleBackColor = true;
            this.signupBtn.Click += new System.EventHandler(this.signupBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(3, 972);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(83, 38);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // todoBtn
            // 
            this.todoBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todoBtn.Location = new System.Drawing.Point(59, 797);
            this.todoBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.todoBtn.Name = "todoBtn";
            this.todoBtn.Size = new System.Drawing.Size(96, 38);
            this.todoBtn.TabIndex = 3;
            this.todoBtn.Text = "TODO";
            this.todoBtn.UseVisualStyleBackColor = true;
            // 
            // fndBtn
            // 
            this.fndBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fndBtn.Location = new System.Drawing.Point(59, 502);
            this.fndBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.fndBtn.Name = "fndBtn";
            this.fndBtn.Size = new System.Drawing.Size(96, 40);
            this.fndBtn.TabIndex = 2;
            this.fndBtn.Text = "Friends";
            this.fndBtn.UseVisualStyleBackColor = true;
            this.fndBtn.Click += new System.EventHandler(this.fndBtn_Click);
            // 
            // lbyBtn
            // 
            this.lbyBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbyBtn.Location = new System.Drawing.Point(59, 352);
            this.lbyBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lbyBtn.Name = "lbyBtn";
            this.lbyBtn.Size = new System.Drawing.Size(96, 40);
            this.lbyBtn.TabIndex = 1;
            this.lbyBtn.Text = "Library";
            this.lbyBtn.UseVisualStyleBackColor = true;
            this.lbyBtn.Click += new System.EventHandler(this.lbyBtn_Click);
            // 
            // klasBtn
            // 
            this.klasBtn.Font = new System.Drawing.Font("Ink Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klasBtn.Location = new System.Drawing.Point(59, 207);
            this.klasBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.klasBtn.Name = "klasBtn";
            this.klasBtn.Size = new System.Drawing.Size(96, 40);
            this.klasBtn.TabIndex = 0;
            this.klasBtn.Text = "KLAS";
            this.klasBtn.UseVisualStyleBackColor = true;
            this.klasBtn.Click += new System.EventHandler(this.klasBtn_Click);
            // 
            // calendarContainer
            // 
            this.calendarContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.calendarContainer.Location = new System.Drawing.Point(210, 0);
            this.calendarContainer.Name = "calendarContainer";
            this.calendarContainer.Size = new System.Drawing.Size(985, 879);
            this.calendarContainer.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 879);
            this.Controls.Add(this.menuContainer);
            this.Controls.Add(this.calendarContainer);
            this.IsMdiContainer = true;
            this.Name = "mainForm";
            this.Text = "KW-Planner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel menuContainer;
        private System.Windows.Forms.Button signupBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button todoBtn;
        private System.Windows.Forms.Button fndBtn;
        private System.Windows.Forms.Button lbyBtn;
        private System.Windows.Forms.Button klasBtn;
        private System.Windows.Forms.Button groupBtn;
        private System.Windows.Forms.Button mainBtn;
        private System.Windows.Forms.Panel calendarContainer;
    }
}

