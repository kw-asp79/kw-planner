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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tbSchedule
            // 
            this.tbSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSchedule.Location = new System.Drawing.Point(222, 18);
            this.tbSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(359, 28);
            this.tbSchedule.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(897, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 38);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Location = new System.Drawing.Point(19, 7);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(0, 12);
            this.lblSelectedDate.TabIndex = 6;
            // 
            // lblSelectedDayOfWeek
            // 
            this.lblSelectedDayOfWeek.AutoSize = true;
            this.lblSelectedDayOfWeek.Location = new System.Drawing.Point(116, 7);
            this.lblSelectedDayOfWeek.Name = "lblSelectedDayOfWeek";
            this.lblSelectedDayOfWeek.Size = new System.Drawing.Size(0, 12);
            this.lblSelectedDayOfWeek.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 494);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(23, 7);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(176, 21);
            this.dtpStartDate.TabIndex = 10;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(23, 32);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(176, 21);
            this.dtpStartTime.TabIndex = 11;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(619, 6);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(176, 21);
            this.dtpEndDate.TabIndex = 12;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(619, 32);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(176, 21);
            this.dtpEndTime.TabIndex = 13;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 550);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSelectedDayOfWeek);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSchedule);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EventForm";
            this.Text = "EventForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventForm_FormClosing);
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSchedule;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Label lblSelectedDayOfWeek;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Panel panel1;
    }
}