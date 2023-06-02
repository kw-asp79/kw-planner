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
            this.tbContent = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.lblSelectedDayOfWeek = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbContent
            // 
            this.tbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContent.Location = new System.Drawing.Point(851, 56);
            this.tbContent.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(512, 39);
            this.tbContent.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1421, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 78);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Location = new System.Drawing.Point(28, 11);
            this.lblSelectedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(0, 18);
            this.lblSelectedDate.TabIndex = 6;
            // 
            // lblSelectedDayOfWeek
            // 
            this.lblSelectedDayOfWeek.AutoSize = true;
            this.lblSelectedDayOfWeek.Location = new System.Drawing.Point(166, 11);
            this.lblSelectedDayOfWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedDayOfWeek.Name = "lblSelectedDayOfWeek";
            this.lblSelectedDayOfWeek.Size = new System.Drawing.Size(0, 18);
            this.lblSelectedDayOfWeek.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1639, 724);
            this.panel1.TabIndex = 9;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(170, 13);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(250, 28);
            this.dtpStartDate.TabIndex = 10;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(429, 13);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(250, 28);
            this.dtpStartTime.TabIndex = 11;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(170, 61);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(250, 28);
            this.dtpEndDate.TabIndex = 12;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(430, 61);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(250, 28);
            this.dtpEndTime.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label1.Location = new System.Drawing.Point(1, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "start_Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "end_Time";
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbTitle.Location = new System.Drawing.Point(851, 10);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(512, 39);
            this.tbTitle.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label3.Location = new System.Drawing.Point(716, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label4.Location = new System.Drawing.Point(689, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 32);
            this.label4.TabIndex = 16;
            this.label4.Text = "Content";
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1639, 826);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSelectedDayOfWeek);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "EventForm";
            this.Text = "EventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Label lblSelectedDayOfWeek;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}