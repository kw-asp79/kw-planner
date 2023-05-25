namespace WindowsFormsApp1
{
    partial class fdGroup_Form_fdlist
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
            this.친구_list = new System.Windows.Forms.ListBox();
            this.btn_add_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 친구_list
            // 
            this.친구_list.FormattingEnabled = true;
            this.친구_list.ItemHeight = 18;
            this.친구_list.Location = new System.Drawing.Point(22, 36);
            this.친구_list.Name = "친구_list";
            this.친구_list.Size = new System.Drawing.Size(275, 238);
            this.친구_list.TabIndex = 0;
            // 
            // btn_add_add
            // 
            this.btn_add_add.Location = new System.Drawing.Point(87, 290);
            this.btn_add_add.Name = "btn_add_add";
            this.btn_add_add.Size = new System.Drawing.Size(153, 43);
            this.btn_add_add.TabIndex = 1;
            this.btn_add_add.Text = "추가";
            this.btn_add_add.UseVisualStyleBackColor = true;
            this.btn_add_add.Click += new System.EventHandler(this.btn_add_add_Click);
            // 
            // fdGroup_Form_fdlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 355);
            this.Controls.Add(this.btn_add_add);
            this.Controls.Add(this.친구_list);
            this.Name = "fdGroup_Form_fdlist";
            this.Text = "친구목록";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox 친구_list;
        private System.Windows.Forms.Button btn_add_add;
    }
}