namespace Client
{
    partial class calendarForm
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
            this.calendarContainer = new System.Windows.Forms.Panel();
            this.btn_share = new System.Windows.Forms.Button();
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
            this.calendarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarContainer
            // 
            this.calendarContainer.Controls.Add(this.btn_share);
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
            this.calendarContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.calendarContainer.Location = new System.Drawing.Point(0, 0);
            this.calendarContainer.Name = "calendarContainer";
            this.calendarContainer.Size = new System.Drawing.Size(862, 817);
            this.calendarContainer.TabIndex = 1;
            this.calendarContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.calendarContainer_Paint);
            // 
            // btn_share
            // 

            this.btn_share.Location = new System.Drawing.Point(960, 29);

            this.btn_share.Name = "btn_share";
            this.btn_share.Size = new System.Drawing.Size(127, 39);
            this.btn_share.TabIndex = 10;
            this.btn_share.Text = "공유된 일정";
            this.btn_share.UseVisualStyleBackColor = true;
            this.btn_share.Click += new System.EventHandler(this.btn_share_Click);
            // 
            // dayContainer
            // 
            this.dayContainer.Location = new System.Drawing.Point(8, 87);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(853, 728);
            this.dayContainer.TabIndex = 9;
            // 
            // ymLbl
            // 
            this.ymLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ymLbl.AutoSize = true;
            this.ymLbl.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ymLbl.Location = new System.Drawing.Point(381, 14);
            this.ymLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ymLbl.Name = "ymLbl";
            this.ymLbl.Size = new System.Drawing.Size(111, 40);
            this.ymLbl.TabIndex = 1;
            this.ymLbl.Text = "2023.4";
            this.ymLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(333, 18);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(26, 29);
            this.prevBtn.TabIndex = 8;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 

            this.nextBtn.Location = new System.Drawing.Point(769, 27);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(26, 29);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(764, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Saturday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(651, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Friday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(522, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thursday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(398, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wednesday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tuesday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monday";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunday";
            // 
            // calendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calendarContainer);
            this.Name = "calendarForm";
            this.Size = new System.Drawing.Size(862, 817);
            this.calendarContainer.ResumeLayout(false);
            this.calendarContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel calendarContainer;
        private System.Windows.Forms.FlowLayoutPanel dayContainer;
        private System.Windows.Forms.Label ymLbl;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_share;
    }
}
