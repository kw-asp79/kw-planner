namespace Client
{
    partial class fdAdd
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
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.ID_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_SearchedName = new System.Windows.Forms.Label();
            this.Name_lbl = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Add.Location = new System.Drawing.Point(135, 173);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(99, 42);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "추가";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.SystemColors.Window;
            this.txt_id.Location = new System.Drawing.Point(32, 55);
            this.txt_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(190, 28);
            this.txt_id.TabIndex = 0;
            // 
            // ID_lbl
            // 
            this.ID_lbl.AutoSize = true;
            this.ID_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ID_lbl.Location = new System.Drawing.Point(30, 25);
            this.ID_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ID_lbl.Name = "ID_lbl";
            this.ID_lbl.Size = new System.Drawing.Size(22, 18);
            this.ID_lbl.TabIndex = 3;
            this.ID_lbl.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.txt_SearchedName);
            this.panel1.Controls.Add(this.Name_lbl);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 254);
            this.panel1.TabIndex = 5;
            // 
            // txt_SearchedName
            // 
            this.txt_SearchedName.AutoSize = true;
            this.txt_SearchedName.Location = new System.Drawing.Point(31, 134);
            this.txt_SearchedName.Name = "txt_SearchedName";
            this.txt_SearchedName.Size = new System.Drawing.Size(0, 18);
            this.txt_SearchedName.TabIndex = 3;
            // 
            // Name_lbl
            // 
            this.Name_lbl.AutoSize = true;
            this.Name_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name_lbl.Location = new System.Drawing.Point(30, 98);
            this.Name_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Name_lbl.Name = "Name_lbl";
            this.Name_lbl.Size = new System.Drawing.Size(55, 18);
            this.Name_lbl.TabIndex = 4;
            this.Name_lbl.Text = "Name";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Search.Location = new System.Drawing.Point(20, 173);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(99, 42);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "조회";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // fdAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 254);
            this.Controls.Add(this.ID_lbl);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fdAdd";
            this.Text = "fdAdd";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label ID_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label Name_lbl;
        private System.Windows.Forms.Label txt_SearchedName;
    }
}