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



        public static void CreateUser(User user)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "INSERT INTO user (user_id, pwd, name) VALUES (@user_id, @pwd, @name)";
            command.Parameters.AddWithValue("@user_id", user.id);
            command.Parameters.AddWithValue("@pwd", user.pwd);
            command.Parameters.AddWithValue("@name", user.name);

            command.ExecuteNonQuery();
        }

        public static void DeleteUser(string user_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

            // 유저 정보가 있는지 확인 
            command.CommandText = "SELECT COUNT(*) FROM user WHERE user_id = @user_id";
            command.Parameters.AddWithValue("@user_id", user_id);

            int userCount = Convert.ToInt32(command.ExecuteScalar());

            if (userCount > 0)
            {
                // Delete data from user_schedule table
                command.CommandText = "DELETE FROM user_schedule WHERE user_id = @user_id";
                command.ExecuteNonQuery();

                // Delete data from user_group table
                command.CommandText = "DELETE FROM user_group WHERE user_id = @user_id";
                command.ExecuteNonQuery();

                // Delete data from friendship table
                command.CommandText = "DELETE FROM friendship WHERE user_id = @user_id OR friend_id = @user_id";
                command.ExecuteNonQuery();

                // Delete data from user table
                command.CommandText = "DELETE FROM user WHERE user_id = @user_id";
                command.ExecuteNonQuery();

            }
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
        public static void CreateFriendship(string user_id, string friend_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "INSERT INTO friendship (user_id, friend_id) VALUES (@user_id, @friend_id)";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@friend_id", friend_id);

            command.ExecuteNonQuery();
        }



        public static void DeleteFriendship(string user_id, string friend_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "DELETE FROM friendship WHERE user_id = @user_id AND friend_id = @friend_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@friend_id", friend_id);

            command.ExecuteNonQuery();
        }


    }
}
