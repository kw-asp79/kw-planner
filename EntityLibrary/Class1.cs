using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{

    [Serializable]
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
        
        public bool isEmpty()
        {
            return this.id.Equals("") && this.pwd.Equals("") && this.name.Equals("");
        }

    }

    [Serializable]
    public class Schedule
    {
        public int id;
        public string category; // 종류는 CUSTOM, KLAS, LIBRARY
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

    [Serializable]
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

    [Serializable]
    public class Friendship
    {
        public string user_id;
        public string friend_id;

        public Friendship()
        {
            user_id = "";
            friend_id = "";
        }

        public Friendship(string user_id, string friend_id)
        {
            this.user_id = user_id;
            this.friend_id = friend_id;
        }

    }
    
}
