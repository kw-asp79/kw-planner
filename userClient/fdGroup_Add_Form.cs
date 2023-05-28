using Client;
using EntityLibrary;
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
    public partial class fdGroup_Add_Form : Form
    {
        fdGroup_Form fdGroupForm;
        mainForm mainForm;
        public fdGroup_Add_Form(fdGroup_Form fdGroup_Form)
        {
            InitializeComponent();
            fdGroupForm = fdGroup_Form;
            listBoxconfig();
        }
        private void listBoxconfig()
        {
            //friends에 있는 user.name정보만 list에 담아 보여주기
            List<string> nameList = mainForm.friends.Select(user => user.name).ToList();
            친구목록.DataSource =  nameList;
            친구목록.SelectionMode = SelectionMode.MultiSimple;
            친구목록.SelectedIndex = -1;

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<string> list_frdname = new List<string>();
            List<User> userList = new List<User>();
            
            foreach (var selectedname in 친구목록.SelectedItems)
            {
                list_frdname.Add(selectedname.ToString());
                User user = new User("", "", (string)selectedname);
                userList.Add(user); 
            }
            fdGroupForm.add_Grouplist(this.txt_grpname.Text, list_frdname);
            mainForm.groups.Add(this.txt_grpname.Text, userList);

            친구목록.SelectedIndex = -1;
            txt_grpname.Clear();

        }
    }
}
