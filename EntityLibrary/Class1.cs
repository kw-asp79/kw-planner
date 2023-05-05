using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class User
    {
        public string id;
        public string pwd;
        public string name;

        public User()
        {
            this.id = "";
            this.pwd = "";
            this.name = "";
        }

        public User(string id, string pwd, string name)
        {
            this.id = id;
            this.pwd = pwd;
            this.name = name;
        }
        

    }
}
