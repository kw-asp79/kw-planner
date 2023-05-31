using EntityLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCalenderServer
{
    public static class GroupRepository
    {
        public static Dictionary<string, List<User>> SelectGroupsWithFriends(User user)
        {
            // 나한테만 보여지는 Group이라고 가정
            MySqlCommand command = DBProcess.connection.CreateCommand();

            command.CommandText = "SELECT group.name FROM asp.group WHERE group.user_id = @myUserId;";
            command.Parameters.AddWithValue("@myUserID", user.id);

            MySqlDataReader reader = command.ExecuteReader();

            Dictionary<string, List<User>> groups = new Dictionary<string, List<User>>();

            while (reader.Read())
            {
                string groupName = reader.GetString("name");
                groups.Add(groupName, new List<User>());
            }

            reader.Close();

            foreach (string groupName in groups.Keys)
            {
                command = DBProcess.connection.CreateCommand();
                command.CommandText = "SELECT user.* FROM user join user_group join asp.group where group.name = @groupName" +
                    " and asp.group.group_id = user_group.group_id and user_group.user_id = user.user_id;";
                command.Parameters.AddWithValue("@groupName", groupName);

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    User friend = new User();

                    friend.id = reader.GetString("user_id");
                    friend.name = reader.GetString("name");

                    groups[groupName].Add(friend);
                }

                reader.Close();
            }

            return groups;
        }

        public static int SelectGroupIdByName(string groupName, string userId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "SELECT group_id FROM asp.group WHERE asp.group.name = @groupName and group.user_id = @userId";
            command.Parameters.AddWithValue("@groupName", groupName);
            command.Parameters.AddWithValue("@userId", userId);

            MySqlDataReader reader = command.ExecuteReader();

            int id = -1;

            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32("group_id");
            }

            reader.Close();

            return id;
        }

        public static void CreateGroup(string name, string user_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "INSERT INTO `group` (name, user_id) VALUES (@name, @user_id);";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@user_id", user_id);

            command.ExecuteNonQuery();
        }

        public static void DeleteGroup(int group_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "DELETE FROM `group` WHERE group_id = @group_id;";
            command.Parameters.AddWithValue("@group_id", group_id);

            command.ExecuteNonQuery();
        }

        public static void UpdateGroup(int group_id, string name, string user_id)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "UPDATE group SET name = @name WHERE group_id = @group_id;";
            command.Parameters.AddWithValue("@group_id", group_id);
            command.Parameters.AddWithValue("@name", name);

            command.ExecuteNonQuery();
        }

        public static void CreateUserGroup(int groupId, string userId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "INSERT INTO user_group (group_id, user_id) VALUES (@groupId, @userId);";
            command.Parameters.AddWithValue("@groupId", groupId);
            command.Parameters.AddWithValue("@userId", userId);

            command.ExecuteNonQuery();
        }
        public static void DeleteUserGroup(int groupId, string userId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "DELETE FROM user_group WHERE user_id = @userId and group_id = @groupId;";
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@groupId", groupId);

            command.ExecuteNonQuery();
        }

        public static void AddUserListToGroup(int GroupId, List<User> userList)
        {
            foreach(User friend in userList)
            {
                CreateUserGroup(GroupId, friend.id);
            }
        }

        public static void DeleteUserListFromGroup(int GroupId, List<User> userList)
        {
            foreach (User friend in userList)
            {
                DeleteUserGroup(GroupId, friend.id);
            }
        }
    }
}
