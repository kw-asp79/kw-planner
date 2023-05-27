namespace Client
{
    partial class LibraryUIForm
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
            this.bookStateTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numOfBookLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.overdueLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.priceToPayLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bookStateTbx
            // 
            this.bookStateTbx.Location = new System.Drawing.Point(375, 394);
            this.bookStateTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookStateTbx.Multiline = true;
            this.bookStateTbx.Name = "bookStateTbx";
            this.bookStateTbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bookStateTbx.Size = new System.Drawing.Size(434, 366);
            this.bookStateTbx.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(77, 554);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "내가 빌린 책들 정보";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(72, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = "내가 책을 빌렸었나?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 47.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 79);
            this.label4.TabIndex = 12;
            this.label4.Text = "My Library";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(371, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(441, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "책은 영혼과 마음을 맑게 하므로... 이하 중략 ... 책을 읽으면 좋다";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(370, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "총 대출 수";
            // 
            // numOfBookLbl
            // 
            this.numOfBookLbl.AutoSize = true;
            this.numOfBookLbl.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfBookLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.numOfBookLbl.Location = new System.Drawing.Point(466, 228);
            this.numOfBookLbl.Name = "numOfBookLbl";
            this.numOfBookLbl.Size = new System.Drawing.Size(26, 26);
            this.numOfBookLbl.TabIndex = 15;
            this.numOfBookLbl.Text = "#";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Tomato;
            this.label7.Location = new System.Drawing.Point(517, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 26);
            this.label7.TabIndex = 16;
            this.label7.Text = "총 연체 수 ";
            // 
            // overdueLbl
            // 
            this.overdueLbl.AutoSize = true;
            this.overdueLbl.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overdueLbl.ForeColor = System.Drawing.Color.Tomato;
            this.overdueLbl.Location = new System.Drawing.Point(610, 228);
            this.overdueLbl.Name = "overdueLbl";
            this.overdueLbl.Size = new System.Drawing.Size(26, 26);
            this.overdueLbl.TabIndex = 17;
            this.overdueLbl.Text = "#";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Tomato;
            this.label9.Location = new System.Drawing.Point(662, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 26);
            this.label9.TabIndex = 18;
            this.label9.Text = "내야할 연체료";
            // 
            // priceToPayLbl
            // 
            this.priceToPayLbl.AutoSize = true;
            this.priceToPayLbl.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceToPayLbl.ForeColor = System.Drawing.Color.Tomato;
            this.priceToPayLbl.Location = new System.Drawing.Point(783, 228);
            this.priceToPayLbl.Name = "priceToPayLbl";
            this.priceToPayLbl.Size = new System.Drawing.Size(26, 26);
            this.priceToPayLbl.TabIndex = 19;
            this.priceToPayLbl.Text = "#";
            // 
            // LibraryUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.priceToPayLbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.overdueLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numOfBookLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bookStateTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LibraryUIForm";
            this.Size = new System.Drawing.Size(862, 817);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox bookStateTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numOfBookLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label overdueLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label priceToPayLbl;
    }
}
