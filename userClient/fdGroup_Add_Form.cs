using Client;
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
        fdList fdList;
        public fdGroup_Add_Form(fdGroup_Form fdGroup_Form)
        {
            InitializeComponent();
            fdGroupForm = fdGroup_Form;
            listBoxconfig();
        }
        private void listBoxconfig()
        {
            친구목록.DataSource = fdList.frd_list;
            친구목록.SelectionMode = SelectionMode.MultiSimple;
            친구목록.SelectedIndex = -1;

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<string> list_frdname = new List<string>();
            foreach (var selectedname in 친구목록.SelectedItems)
            {
                list_frdname.Add(selectedname.ToString());
            }
            fdGroupForm.add_Grouplist(this.txt_grpname.Text, list_frdname);
            친구목록.SelectedIndex = -1;
            txt_grpname.Clear();

        }
    }
}
