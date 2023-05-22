namespace Client
{
    partial class EventForm
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
            this.tbSchedule = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.lblSelectedDayOfWeek = new System.Windows.Forms.Label();
            this.cbbHour = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tbSchedule
            // 
            this.tbSchedule.Font = new System.Drawing.Font("Bookman Old Style", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSchedule.Location = new System.Drawing.Point(234, 15);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(410, 34);
            this.tbSchedule.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(705, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 48);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Location = new System.Drawing.Point(22, 9);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(0, 15);
            this.lblSelectedDate.TabIndex = 6;
            // 
            // lblSelectedDayOfWeek
            // 
            this.lblSelectedDayOfWeek.AutoSize = true;
            this.lblSelectedDayOfWeek.Location = new System.Drawing.Point(132, 9);
            this.lblSelectedDayOfWeek.Name = "lblSelectedDayOfWeek";
            this.lblSelectedDayOfWeek.Size = new System.Drawing.Size(0, 15);
            this.lblSelectedDayOfWeek.TabIndex = 7;
            // 
            // cbbHour
            // 
            this.cbbHour.Font = new System.Drawing.Font("Bookman Old Style", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHour.FormattingEnabled = true;
            this.cbbHour.Location = new System.Drawing.Point(28, 15);
            this.cbbHour.Name = "cbbHour";
            this.cbbHour.Size = new System.Drawing.Size(121, 34);
            this.cbbHour.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 466);
            this.panel1.TabIndex = 9;
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbbHour);
            this.Controls.Add(this.lblSelectedDayOfWeek);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSchedule);
            this.Name = "EventForm";
            this.Text = "EventForm";
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSchedule;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Label lblSelectedDayOfWeek;
        private System.Windows.Forms.ComboBox cbbHour;
        private System.Windows.Forms.Panel panel1;
    }
}