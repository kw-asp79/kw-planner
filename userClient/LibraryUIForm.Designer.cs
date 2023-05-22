namespace Client
{
    partial class LibraryUIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookStateTbx = new System.Windows.Forms.TextBox();
            this.stateTbx = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "대출 상태";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "대출현황";
            // 
            // bookStateTbx
            // 
            this.bookStateTbx.Location = new System.Drawing.Point(280, 270);
            this.bookStateTbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bookStateTbx.Multiline = true;
            this.bookStateTbx.Name = "bookStateTbx";
            this.bookStateTbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bookStateTbx.Size = new System.Drawing.Size(478, 569);
            this.bookStateTbx.TabIndex = 3;
            // 
            // stateTbx
            // 
            this.stateTbx.Location = new System.Drawing.Point(280, 141);
            this.stateTbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stateTbx.Multiline = true;
            this.stateTbx.Name = "stateTbx";
            this.stateTbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stateTbx.Size = new System.Drawing.Size(478, 72);
            this.stateTbx.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(280, 46);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(478, 25);
            this.textBox3.TabIndex = 5;
            // 
            // LibraryUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 871);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.stateTbx);
            this.Controls.Add(this.bookStateTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LibraryUIForm";
            this.Text = "MyLibrary";
            this.Load += new System.EventHandler(this.LibraryUIForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bookStateTbx;
        private System.Windows.Forms.TextBox stateTbx;
        private System.Windows.Forms.TextBox textBox3;
    }
}