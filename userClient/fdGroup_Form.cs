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
    public partial class fdGroup_Form : Form
    {
        Label[] labelGroupName = new Label[10];
        ListBox[] listBoxFriends = new ListBox[10];
        Button[] btn_delete = new Button[10];
        Button[] btn_add = new Button[10];
        int A = 1;
        int cntGrp = 0;
        public fdGroup_Form()
        {
            InitializeComponent();
        }
        private void btn_addfd_Click(object sender, EventArgs e)
        {
            fdGroup_Add_Form fdGroup_Add_Form = new fdGroup_Add_Form(this);
            fdGroup_Add_Form.Show();
        }
        public void add_Grouplist(string grpname, List<string> ts)
        {
            if (grpname != "")
            {
                A = cntGrp + 1;

                labelGroupName[A] = new Label();
                labelGroupName[A].Text = grpname;
                labelGroupName[A].Location = new Point(100 + 200 * (A - 1), 120);
                labelGroupName[A].Size = new Size(100, 100);
                labelGroupName[A].Tag = A;

                listBoxFriends[A] = new ListBox();
                listBoxFriends[A].Tag = A;
                listBoxFriends[A].DataSource = ts;
                listBoxFriends[A].Size = new Size(100, 50);
                listBoxFriends[A].Location = new Point { X = 100 + 200 * (A - 1), Y = 132 };

                btn_add[A] = new Button();
                btn_add[A].Tag = A;
                btn_add[A].Text = "추가";
                btn_add[A].Size = new Size(40, 20);
                btn_add[A].Location = new Point(100 + 200 * (A - 1), 172);

                btn_delete[A] = new Button();
                btn_delete[A].Tag = A;
                btn_delete[A].Text = "삭제";
                btn_delete[A].Size = new Size(40, 20);
                btn_delete[A].Location = new Point(142 + 200 * (A - 1), 172);

                this.Controls.Add(btn_add[A]);
                this.Controls.Add(btn_delete[A]);
                this.Controls.Add(listBoxFriends[A]);
                this.Controls.Add(labelGroupName[A]);

                cntGrp++;
                A++;
            }
        }
        
    }
}
