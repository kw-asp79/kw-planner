﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class libraryLoginForm : UserControl
    {
        public libraryLoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LibraryUIForm libraryUIForm = new LibraryUIForm(idTbx.Text.ToString(),pwdTbx.Text.ToString());

            /*Thread libraryCrawlingThread = new Thread(new ThreadStart(libraryUIForm.doWork));
            libraryCrawlingThread.Start();
            */
            
            libraryUIForm.crawlLibraryData();
            libraryUIForm.showState();
            libraryUIForm.showBookState();
            libraryUIForm.Show();
        }


        private void pwdTbx_TextChanged(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
=======

>>>>>>> 846dc9ce352d96eacfcb179c0fd4a9c97514aa3c
    }
}
