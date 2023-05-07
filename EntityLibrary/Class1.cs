using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

        //서버에서 쓸 코드
        public void saveUser(User user)
        {

            // MySqlCommand command = connection.CreateCommand();

            // string name = "testGroup";

            // command.CommandText = "INSERT INTO asp.group (name) VALUES (?name);";
            // command.Parameters.AddWithValue("?name", name);

            // MySqlDataReader reader = command.ExecuteReader();
        }

        

    }

    public class Schedule
    {
        public int id;
        public string category;
        public string title;
        public string content;
        public DateTime datetime;

        public Schedule()
        {
            this.category = "";
            this.title = "";
            this.content = "";
            this.datetime = new DateTime(2000, 00, 00);
        }

        public Schedule(string category, string title, string content, DateTime datetime)
        {
            this.category = category;
            this.title = title;
            this.content = content;
            this.datetime = datetime;
        }


    }

    public class Group
    {
        public int id;
        public string name;

        public Group()
        {
            name = "";
        }

        public Group(string name)
        {
            this.name = name;
        }
    }
    
}
