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

            command.CommandText = "SELECT group.name FROM schema.group WHERE group.user_id = @myUserId;";
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
                command.CommandText = "SELECT user.* FROM user join user_group join schema.group where group.name = @groupName" +
                    " and schema.group.group_id = user_group.group_id and user_group.user_id = user.user_id;";
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
    }
}
