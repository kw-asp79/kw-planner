﻿using EntityLibrary;
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
            User user = new User();
            user.id = this.txt_id.Text;
            // user가져가서 friendship의 친구에 추가 

            // add_label함수에 null값에 sql문으로 가져온 name 넣으면 됨
            fdList.add_label(this.txt_id.Text,null);

            MessageBox.Show("{0} 님이 친구로 등록되었습니다.", this.txt_id.Text);
            txt_id.Clear();
        }


    }
}