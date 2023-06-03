﻿using EntityLibrary;
using PacketLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class fdAdd : Form
    {
        fdList fdList;
        NetworkStream netstrm;
        mainForm mainForm;
        public fdAdd(fdList form, NetworkStream netstrm)
        {
            InitializeComponent();
            fdList = form;
            this.netstrm = netstrm;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //friends list 에 추가
            User user = new User();
            user.id = this.txt_id.Text;
            user.name = this.txt_SearchedName.Text;
            if (this.txt_SearchedName.Text == "(해당 사용자 정보가 없습니다.") user.name = "";
            if (!user.name.Equals(""))
            {
                mainForm.friends.Add(user);
                // 친구목록 화면에 추가
                fdList.add_label(this.txt_id.Text, this.txt_SearchedName.Text);

                string message = string.Format("{0} 님이 친구로 등록되었습니다.", this.txt_SearchedName.Text);
                MessageBox.Show(message);
                txt_id.Clear();
                txt_SearchedName.Text = null;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.id = txt_id.Text;
            
            Packet packet = new Packet();
            packet.action = ActionType.readUser;
            packet.data = user;

            Packet.SendPacket(netstrm, packet);

            packet = Packet.ReceivePacket(netstrm);

            if (packet.action == ActionType.Fail)
            {
                string message = string.Format("{0} 님은 등록되지 않은 정보입니다.", this.txt_id.Text);
                MessageBox.Show(message);
                txt_id.Clear();
                txt_SearchedName.Text = "(해당 사용자 정보가 없습니다)";
                user.name = "";
            }
            else if (packet.action == ActionType.Success)
            {
                user = (User)packet.data;
                txt_SearchedName.Text = user.name;
            }
        }
    }


}
