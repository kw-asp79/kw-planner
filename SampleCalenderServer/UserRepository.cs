using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;
using PacketLibrary;

namespace SampleCalenderServer
{
    public static class UserRepository
    {

        // User에 대한 CRUD 
        // Friendship에 대한 CRUD
        public static User SelectUser(string user_id, string user_pwd)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

            command.CommandText = "SELECT * FROM user WHERE user_id = @user_id and pwd = @pwd;";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@pwd", user_pwd);

            MySqlDataReader reader = command.ExecuteReader();

            User user = new User();

            // 데이터가 있다면
            if (reader.HasRows)
            {
                reader.Read();

                user.id = reader.GetString("user_id");
                user.pwd = reader.GetString("pwd");
                user.name = reader.GetString("name");
            }

            reader.Close();

            return user;
        }

        public static List<User> SelectFriends(User user)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

            command.CommandText = "SELECT user.* FROM user JOIN friendship WHERE friendship.user_id = @myUserId AND friendship.friend_id = user.user_id;";
            command.Parameters.AddWithValue("@myUserId", user.id);

            MySqlDataReader reader = command.ExecuteReader();

            List<User> friends = new List<User>();

            while (reader.Read())
            {
                User friend = new User();

                friend.id = reader.GetString("user_id");
                friend.name = reader.GetString("name");

                friends.Add(friend);
            }


            reader.Close();

            return friends;
        }

    }
}
