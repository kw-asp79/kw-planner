namespace Client
{
    partial class fdGroup_Add_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.친구목록 = new System.Windows.Forms.ListBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_grpname = new System.Windows.Forms.TextBox();
            this.Grpname_lbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.친구목록);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.txt_grpname);
            this.panel1.Controls.Add(this.Grpname_lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 451);
            this.panel1.TabIndex = 6;
            // 
            // 친구목록
            // 
            this.친구목록.FormattingEnabled = true;
            this.친구목록.ItemHeight = 18;
            this.친구목록.Location = new System.Drawing.Point(22, 114);
            this.친구목록.Name = "친구목록";
            this.친구목록.Size = new System.Drawing.Size(438, 256);
            this.친구목록.TabIndex = 17;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Add.Location = new System.Drawing.Point(22, 398);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(79, 35);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "추가";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_grpname
            // 
            this.txt_grpname.BackColor = System.Drawing.SystemColors.Window;
            this.txt_grpname.Location = new System.Drawing.Point(32, 61);
            this.txt_grpname.Margin = new System.Windows.Forms.Padding(2);
            this.txt_grpname.Name = "txt_grpname";
            this.txt_grpname.Size = new System.Drawing.Size(153, 28);
            this.txt_grpname.TabIndex = 0;
            // 
            // Grpname_lbl
            // 
            this.Grpname_lbl.AutoSize = true;
            this.Grpname_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grpname_lbl.Location = new System.Drawing.Point(29, 29);
            this.Grpname_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Grpname_lbl.Name = "Grpname_lbl";
            this.Grpname_lbl.Size = new System.Drawing.Size(62, 18);
            this.Grpname_lbl.TabIndex = 4;
            this.Grpname_lbl.Text = "그룹명";
            // 
            // fdGroup_Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 451);
            this.Controls.Add(this.panel1);
            this.Name = "fdGroup_Add_Form";
            this.Text = "신규 그룹 추가";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Grpname_lbl;
        private System.Windows.Forms.TextBox txt_grpname;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox 친구목록;
    }
}