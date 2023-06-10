namespace WindowsFormsApp1
{
    partial class BookInfo
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.authorLbl = new System.Windows.Forms.Label();
            this.locationLbl = new System.Windows.Forms.Label();
            this.loanDayLbl = new System.Windows.Forms.Label();
            this.returnDayLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(3, 17);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(35, 12);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "제목: ";
            // 
            // authorLbl
            // 
            this.authorLbl.AutoSize = true;
            this.authorLbl.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLbl.Location = new System.Drawing.Point(3, 53);
            this.authorLbl.Name = "authorLbl";
            this.authorLbl.Size = new System.Drawing.Size(35, 12);
            this.authorLbl.TabIndex = 1;
            this.authorLbl.Text = "저자: ";
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.Location = new System.Drawing.Point(3, 94);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(53, 12);
            this.locationLbl.TabIndex = 2;
            this.locationLbl.Text = "청구기호: ";
            // 
            // loanDayLbl
            // 
            this.loanDayLbl.AutoSize = true;
            this.loanDayLbl.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanDayLbl.Location = new System.Drawing.Point(3, 131);
            this.loanDayLbl.Name = "loanDayLbl";
            this.loanDayLbl.Size = new System.Drawing.Size(44, 12);
            this.loanDayLbl.TabIndex = 3;
            this.loanDayLbl.Text = "대출일: ";
            // 
            // returnDayLbl
            // 
            this.returnDayLbl.AutoSize = true;
            this.returnDayLbl.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnDayLbl.Location = new System.Drawing.Point(3, 168);
            this.returnDayLbl.Name = "returnDayLbl";
            this.returnDayLbl.Size = new System.Drawing.Size(44, 12);
            this.returnDayLbl.TabIndex = 4;
            this.returnDayLbl.Text = "반납일: ";
            // 
            // BookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.returnDayLbl);
            this.Controls.Add(this.loanDayLbl);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.authorLbl);
            this.Controls.Add(this.titleLbl);
            this.Name = "BookInfo";
            this.Size = new System.Drawing.Size(197, 192);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label authorLbl;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.Label loanDayLbl;
        private System.Windows.Forms.Label returnDayLbl;
    }
}
