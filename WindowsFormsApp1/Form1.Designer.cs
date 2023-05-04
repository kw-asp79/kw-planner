namespace SampleCalendar
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatBtn = new System.Windows.Forms.Button();
            this.groupBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.todoBtn = new System.Windows.Forms.Button();
            this.fndBtn = new System.Windows.Forms.Button();
            this.lbyBtn = new System.Windows.Forms.Button();
            this.klasBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.ymLbl = new System.Windows.Forms.Label();
            this.calendarContainer = new System.Windows.Forms.Panel();
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.calendarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.chatBtn);
            this.panel1.Controls.Add(this.groupBtn);
            this.panel1.Controls.Add(this.settingBtn);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.todoBtn);
            this.panel1.Controls.Add(this.fndBtn);
            this.panel1.Controls.Add(this.lbyBtn);
            this.panel1.Controls.Add(this.klasBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 923);
            this.panel1.TabIndex = 1;
            // 
            // chatBtn
            // 
            this.chatBtn.Location = new System.Drawing.Point(59, 534);
            this.chatBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(96, 31);
            this.chatBtn.TabIndex = 7;
            this.chatBtn.Text = "Chat";
            this.chatBtn.UseVisualStyleBackColor = true;
            // 
            // groupBtn
            // 
            this.groupBtn.Location = new System.Drawing.Point(59, 420);
            this.groupBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBtn.Name = "groupBtn";
            this.groupBtn.Size = new System.Drawing.Size(96, 31);
            this.groupBtn.TabIndex = 6;
            this.groupBtn.Text = "Group";
            this.groupBtn.UseVisualStyleBackColor = true;
            // 
            // settingBtn
            // 
            this.settingBtn.Location = new System.Drawing.Point(119, 878);
            this.settingBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(71, 29);
            this.settingBtn.TabIndex = 5;
            this.settingBtn.Text = "setting";
            this.settingBtn.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(26, 878);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(70, 29);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "login";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // todoBtn
            // 
            this.todoBtn.Location = new System.Drawing.Point(59, 649);
            this.todoBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.todoBtn.Name = "todoBtn";
            this.todoBtn.Size = new System.Drawing.Size(96, 31);
            this.todoBtn.TabIndex = 3;
            this.todoBtn.Text = "TODO";
            this.todoBtn.UseVisualStyleBackColor = true;
            // 
            // fndBtn
            // 
            this.fndBtn.Location = new System.Drawing.Point(59, 304);
            this.fndBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fndBtn.Name = "fndBtn";
            this.fndBtn.Size = new System.Drawing.Size(96, 32);
            this.fndBtn.TabIndex = 2;
            this.fndBtn.Text = "Friends";
            this.fndBtn.UseVisualStyleBackColor = true;
            // 
            // lbyBtn
            // 
            this.lbyBtn.Location = new System.Drawing.Point(59, 185);
            this.lbyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbyBtn.Name = "lbyBtn";
            this.lbyBtn.Size = new System.Drawing.Size(96, 32);
            this.lbyBtn.TabIndex = 1;
            this.lbyBtn.Text = "Library";
            this.lbyBtn.UseVisualStyleBackColor = true;
            // 
            // klasBtn
            // 
            this.klasBtn.Location = new System.Drawing.Point(59, 80);
            this.klasBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.klasBtn.Name = "klasBtn";
            this.klasBtn.Size = new System.Drawing.Size(96, 29);
            this.klasBtn.TabIndex = 0;
            this.klasBtn.Text = "KLAS";
            this.klasBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tuesday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wednesday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(514, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thursday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(642, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Friday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(759, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Saturday";
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(613, 22);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(39, 22);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            this.nextBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextBtn_KeyDown);
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(198, 22);
            this.prevBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(39, 22);
            this.prevBtn.TabIndex = 8;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // ymLbl
            // 
            this.ymLbl.AutoSize = true;
            this.ymLbl.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ymLbl.Location = new System.Drawing.Point(374, 11);
            this.ymLbl.Name = "ymLbl";
            this.ymLbl.Size = new System.Drawing.Size(123, 44);
            this.ymLbl.TabIndex = 1;
            this.ymLbl.Text = "2023.4";
            // 
            // calendarContainer
            // 
            this.calendarContainer.Controls.Add(this.dayContainer);
            this.calendarContainer.Controls.Add(this.ymLbl);
            this.calendarContainer.Controls.Add(this.prevBtn);
            this.calendarContainer.Controls.Add(this.nextBtn);
            this.calendarContainer.Controls.Add(this.label7);
            this.calendarContainer.Controls.Add(this.label6);
            this.calendarContainer.Controls.Add(this.label5);
            this.calendarContainer.Controls.Add(this.label4);
            this.calendarContainer.Controls.Add(this.label3);
            this.calendarContainer.Controls.Add(this.label2);
            this.calendarContainer.Controls.Add(this.label1);
            this.calendarContainer.Location = new System.Drawing.Point(216, 0);
            this.calendarContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calendarContainer.Name = "calendarContainer";
            this.calendarContainer.Size = new System.Drawing.Size(856, 906);
            this.calendarContainer.TabIndex = 0;
            // 
            // dayContainer
            // 
            this.dayContainer.Location = new System.Drawing.Point(3, 110);
            this.dayContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(860, 796);
            this.dayContainer.TabIndex = 9;
            this.dayContainer.Click += new System.EventHandler(this.dayContainer_Click);
            this.dayContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.dayContainer_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 923);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.calendarContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "KW-Planner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.calendarContainer.ResumeLayout(false);
            this.calendarContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button todoBtn;
        private System.Windows.Forms.Button fndBtn;
        private System.Windows.Forms.Button lbyBtn;
        private System.Windows.Forms.Button klasBtn;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.Button groupBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Label ymLbl;
        private System.Windows.Forms.Panel calendarContainer;
        private System.Windows.Forms.FlowLayoutPanel dayContainer;
    }
}

