using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fdList : Form
    {
        Label[] labels = new Label[20];
        Button[] btn_chat = new Button[20];
        Button[] btn_delete = new Button[20];
        int labelWidth = 50;
        int labelHeight = 25;
        int A = 1;
        int cntlbl = 0;

        public fdList()
        {
            InitializeComponent();
        }

        private void btn_addfd_Click(object sender, EventArgs e)
        {
            fdAdd fdAdd = new fdAdd(this);
            fdAdd.ShowDialog();
        }

        public void add_label(string s)
        {
            A = cntlbl + 1;
            labels[A] = new Label();
            labels[A].Location = new Point(100,50+50*A);
            labels[A].Size = new Size(labelWidth,labelHeight);
            labels[A].Text = s;
            labels[A].Tag = A;
            
            btn_chat[A] = new Button();
            btn_chat[A].Location = new Point(150, 40 + 50 * A );
            btn_chat[A].Size = new Size(labelWidth,labelHeight);
            btn_chat[A].Text = "채팅";
            btn_chat[A].Tag = A;

            btn_delete[A] = new Button();
            btn_delete[A].Location = new Point(220, 40+50*A);
            btn_delete[A].Size = new Size(labelWidth, labelHeight);
            btn_delete[A].Text = "삭제";
            btn_delete[A].Tag = A;


            btn_delete[A].Click += new EventHandler(btn_delete_Click);

            this.Controls.Add(labels[A]);
            this.Controls.Add(btn_chat[A]);
            this.Controls.Add(btn_delete[A]);

            cntlbl++;
            A++;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idx = (int)btn.Tag;

            if(idx < A-1)
            {
                labels[idx].Text = labels[A-1].Text;
                this.Controls.Remove(btn_delete[A-1]);
                this.Controls.Remove(labels[A-1]);
                this.Controls.Remove(btn_chat[A-1]);
                A = A - 1;
            } else
            {
                this.Controls.Remove(btn_delete[idx]);
                this.Controls.Remove(labels[idx]);
                this.Controls.Remove(btn_chat[idx]);
            }
            cntlbl--;
        }
        
    }
}
