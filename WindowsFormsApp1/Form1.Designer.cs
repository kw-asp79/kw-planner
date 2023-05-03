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
            this.calendarContainer = new System.Windows.Forms.Panel();
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ymLbl = new System.Windows.Forms.Label();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.todoBtn = new System.Windows.Forms.Button();
            this.fndBtn = new System.Windows.Forms.Button();
            this.lbyBtn = new System.Windows.Forms.Button();
            this.klasBtn = new System.Windows.Forms.Button();
            this.calendarContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.calendarContainer.Location = new System.Drawing.Point(270, 0);
            this.calendarContainer.Margin = new System.Windows.Forms.Padding(4);
            this.calendarContainer.Name = "calendarContainer";
            this.calendarContainer.Size = new System.Drawing.Size(1070, 1088);
            this.calendarContainer.TabIndex = 0;
            // 
            // dayContainer
            // 
            this.dayContainer.Location = new System.Drawing.Point(4, 132);
            this.dayContainer.Margin = new System.Windows.Forms.Padding(4);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(1060, 956);
            this.dayContainer.TabIndex = 9;
            // 
            // ymLbl
            // 
            this.ymLbl.AutoSize = true;
            this.ymLbl.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ymLbl.Location = new System.Drawing.Point(467, 14);
            this.ymLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ymLbl.Name = "ymLbl";
            this.ymLbl.Size = new System.Drawing.Size(143, 53);
            this.ymLbl.TabIndex = 1;
            this.ymLbl.Text = "2023.4";
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(247, 27);
            this.prevBtn.Margin = new System.Windows.Forms.Padding(4);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(49, 27);
            this.prevBtn.TabIndex = 8;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(766, 27);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(49, 27);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(949, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Saturday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(803, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Friday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(643, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thursday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wednesday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tuesday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monday";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunday";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.settingBtn);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.todoBtn);
            this.panel1.Controls.Add(this.fndBtn);
            this.panel1.Controls.Add(this.lbyBtn);
            this.panel1.Controls.Add(this.klasBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 1095);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 640);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 38);
            this.button4.TabIndex = 7;
            this.button4.Text = "Chat";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(74, 504);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Group";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // settingBtn
            // 
            this.settingBtn.Location = new System.Drawing.Point(149, 1053);
            this.settingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(89, 34);
            this.settingBtn.TabIndex = 5;
            this.settingBtn.Text = "setting";
            this.settingBtn.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(33, 1053);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(87, 34);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "login";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // todoBtn
            // 
            this.todoBtn.Location = new System.Drawing.Point(74, 778);
            this.todoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.todoBtn.Name = "todoBtn";
            this.todoBtn.Size = new System.Drawing.Size(120, 38);
            this.todoBtn.TabIndex = 3;
            this.todoBtn.Text = "TODO";
            this.todoBtn.UseVisualStyleBackColor = true;
            // 
            // fndBtn
            // 
            this.fndBtn.Location = new System.Drawing.Point(74, 364);
            this.fndBtn.Margin = new System.Windows.Forms.Padding(4);
            this.fndBtn.Name = "fndBtn";
            this.fndBtn.Size = new System.Drawing.Size(120, 39);
            this.fndBtn.TabIndex = 2;
            this.fndBtn.Text = "Friends";
            this.fndBtn.UseVisualStyleBackColor = true;
            this.fndBtn.Click += new System.EventHandler(this.fndBtn_Click);
            // 
            // lbyBtn
            // 
            this.lbyBtn.Location = new System.Drawing.Point(74, 222);
            this.lbyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.lbyBtn.Name = "lbyBtn";
            this.lbyBtn.Size = new System.Drawing.Size(120, 39);
            this.lbyBtn.TabIndex = 1;
            this.lbyBtn.Text = "Library";
            this.lbyBtn.UseVisualStyleBackColor = true;
            // 
            // klasBtn
            // 
            this.klasBtn.Location = new System.Drawing.Point(74, 96);
            this.klasBtn.Margin = new System.Windows.Forms.Padding(4);
            this.klasBtn.Name = "klasBtn";
            this.klasBtn.Size = new System.Drawing.Size(120, 34);
            this.klasBtn.TabIndex = 0;
            this.klasBtn.Text = "KLAS";
            this.klasBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 1095);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.calendarContainer);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "KW-Planner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.calendarContainer.ResumeLayout(false);
            this.calendarContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel calendarContainer;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ymLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button todoBtn;
        private System.Windows.Forms.Button fndBtn;
        private System.Windows.Forms.Button lbyBtn;
        private System.Windows.Forms.Button klasBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel dayContainer;
    }
}

