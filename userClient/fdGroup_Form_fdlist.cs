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
    public partial class fdGroup_Form_fdlist : Form
    {
        fdGroup_Form fdGroupForm;
        fdList fdList;
        List<string> add_list= new List<string>();
        int k = 0;
        public fdGroup_Form_fdlist(fdGroup_Form fdGroup_Form,List<string> list, List<string> list1,int i)
        {
            InitializeComponent();
            fdGroupForm = fdGroup_Form;
            친구_list.DataSource = list;
            친구_list.Refresh();
            add_list = list1;
            친구_list.SelectionMode = SelectionMode.MultiSimple;
            친구_list.SelectedIndex = -1;
            k = i;
            if(list.Count == 0) { this.Close();MessageBox.Show("추가할 친구가 더 이상 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
        }

        private void btn_add_add_Click(object sender, EventArgs e)
        {
            List<string> list_frdname = new List<string>();
             
            foreach (var selectedname in 친구_list.SelectedItems)
            {
                list_frdname.Add(selectedname.ToString());
                //기존 그룹에 새로운 친구 추가 
                mainForm.groups.ElementAt(k - 1).Value.Add(new User("", "", (string)selectedname));
                
            }
            
            add_list = add_list.Union(list_frdname).ToList();
            fdGroupForm.update_list(add_list, k);
            this.Close();
        }
    }
}
