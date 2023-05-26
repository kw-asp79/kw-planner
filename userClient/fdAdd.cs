using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class fdAdd : Form
    {
        fdList fdList;
        public fdAdd(fdList form)
        {
            InitializeComponent();
            fdList = form;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            fdList.bool_tf = true;
            fdList.add_label(this.txt_id.Text,this.txt_fd.Text);
            txt_fd.Clear();
            txt_id.Clear();
        }

        private void fdAdd_Load(object sender, EventArgs e)
        {

        }
    }
}