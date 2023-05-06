using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fdList : Form
    {
        Label[] labels = new Label[20];
        Label[] labels2 = new Label[20];
        Button[] btn_chat = new Button[20];
        Button[] btn_delete = new Button[20];
        Panel[] panel = new Panel[20];

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

        public void add_label(string id, string s)
        {
            A = cntlbl + 1;

            labels2[A] = new Label();
            labels2[A].Location = new Point(235,60+50*A );
            labels2[A].Size = new Size(labelWidth+15, labelHeight);
            labels2[A].Text = id;
            labels2[A].Tag = A;

            labels[A] = new Label();
            labels[A].Location = new Point(labels2[A].Location.X+65, labels2[A].Location.Y);
            labels[A].Size = new Size(labelWidth,labelHeight);
            labels[A].Text = s;
            labels[A].Tag = A;
            
            btn_chat[A] = new Button();
            btn_chat[A].Location = new Point(labels2[A].Location.X + 115, labels2[A].Location.Y-10);
            btn_chat[A].Size = new Size(labelWidth,labelHeight);
            btn_chat[A].Text = "채팅";
            btn_chat[A].Tag = A;

            btn_delete[A] = new Button();
            btn_delete[A].Location = new Point(labels2[A].Location.X + 165, labels2[A].Location.Y-10);
            btn_delete[A].Size = new Size(labelWidth, labelHeight);
            btn_delete[A].Text = "삭제";
            btn_delete[A].Tag = A;


            btn_delete[A].Click += new EventHandler(btn_delete_Click);

            panel[A] = new Panel();
            panel[A].Location = new Point(labels2[A].Location.X, labels2[A].Location.Y+15);
            panel[A].Size = new Size(215, 1);
            panel[A].BackColor = Color.Black;
            panel[A].Tag = A;

            this.Controls.Add(panel[A]);
            this.Controls.Add(labels2[A] );
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
                labels2[idx].Text = labels2[A-1].Text;

                this.Controls.Remove(labels2[A - 1]);
                this.Controls.Remove(btn_delete[A-1]);
                this.Controls.Remove(labels[A-1]);
                this.Controls.Remove(btn_chat[A-1]);
                this.Controls.Remove(panel[A-1]);
                A = A - 1;
            } else
            {
                this.Controls.Remove(labels2[idx]);
                this.Controls.Remove(btn_delete[idx]);
                this.Controls.Remove(labels[idx]);
                this.Controls.Remove(btn_chat[idx]);
                this.Controls.Remove(panel[idx]);
            }
            cntlbl--;
        }

       
    }
}
