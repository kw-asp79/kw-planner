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
        public DateTime startTime;
        public DateTime endTime;
        public string fromWho;
        public Boolean isDone;

        public Schedule()
        {
            this.category = "";
            this.title = "";
            this.content = "";
            this.startTime = new DateTime(2000, 01, 01);
            this.endTime = new DateTime(2000, 01, 01);
            this.fromWho = "";
            this.isDone = false;
        }

        public Schedule(string category, string title, string content, DateTime startTime, DateTime endTime)
        { 
            this.category = category;
            this.title = title;
            this.content = content;
            this.startTime = startTime;
            this.endTime = endTime;
            this.fromWho = "";
            this.isDone = false;
        }

        public Schedule(string category, string title, string content, DateTime startTime, DateTime endTime, string fromWho)
        {
            this.category = category;
            this.title = title;
            this.content = content;
            this.startTime = startTime;
            this.endTime = endTime;
            this.fromWho = fromWho;
            this.isDone = false;
        }

    }

    [Serializable]
    public class Group
    {
        public int id;
        public string name;
        public string user_id;

        public Group()
        {
            name = "";
            user_id = "";
        }


        public Group(string name, string user_id)
        {
            this.name = name;
            this.user_id = user_id;
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

    [Serializable]
    public class Message
    {
        public string content;
        public DateTime sendTime;

        public Message()
        {
            content = "";
            sendTime = new DateTime(2000, 01, 01);
        }

        public Message(string content, DateTime sendTime)
        {
            this.content = content;
            this.sendTime = sendTime;
        }
    }
    
}
