namespace Client
{
    partial class UserControlDays
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
            this.lbDay = new System.Windows.Forms.Label();
            this.dayLbl = new System.Windows.Forms.Label();
            this.customeLbl = new System.Windows.Forms.Label();
            this.klasLbl = new System.Windows.Forms.Label();
            this.libraryLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDay.Location = new System.Drawing.Point(2, 7);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(23, 16);
            this.lbDay.TabIndex = 0;
            this.lbDay.Text = "00";
            // 
            // dayLbl
            // 
            this.dayLbl.AutoSize = true;
            this.dayLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayLbl.Location = new System.Drawing.Point(42, 10);
            this.dayLbl.Name = "dayLbl";
            this.dayLbl.Size = new System.Drawing.Size(0, 14);
            this.dayLbl.TabIndex = 1;
            // 
            // customeLbl
            // 
            this.customeLbl.AutoSize = true;
            this.customeLbl.Location = new System.Drawing.Point(3, 35);
            this.customeLbl.Name = "customeLbl";
            this.customeLbl.Size = new System.Drawing.Size(0, 12);
            this.customeLbl.TabIndex = 2;
            // 
            // klasLbl
            // 
            this.klasLbl.AutoSize = true;
            this.klasLbl.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.klasLbl.Location = new System.Drawing.Point(3, 64);
            this.klasLbl.Name = "klasLbl";
            this.klasLbl.Size = new System.Drawing.Size(11, 11);
            this.klasLbl.TabIndex = 3;
            this.klasLbl.Text = "";
            // 
            // libraryLbl
            // 
            this.libraryLbl.AutoSize = true;
            this.libraryLbl.Location = new System.Drawing.Point(3, 92);
            this.libraryLbl.Name = "libraryLbl";
            this.libraryLbl.Size = new System.Drawing.Size(0, 12);
            this.libraryLbl.TabIndex = 4;
            // 
            // UserControlDays
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.libraryLbl);
            this.Controls.Add(this.klasLbl);
            this.Controls.Add(this.customeLbl);
            this.Controls.Add(this.dayLbl);
            this.Controls.Add(this.lbDay);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(115, 115);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.DoubleClick += new System.EventHandler(this.UserControlDays_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.UserControlDays_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControlDays_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbDay;
        public System.Windows.Forms.Label dayLbl;
        public System.Windows.Forms.Label customeLbl;
        public System.Windows.Forms.Label klasLbl;
        public System.Windows.Forms.Label libraryLbl;
    }
}
