using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;
using EntityLibrary;
using PacketLibrary;
using System.Management.Instrumentation;
using MySqlX.XDevAPI;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Data.Odbc;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;

namespace Server
{

    public class DBProcess
    {
        public static string connectionString;
        public static MySqlConnection connection;


        public static void ConnectDB()
        {

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        //user 테이블 
        public static User SelectUser(string user_id, string user_pwd)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM user WHERE user_id = @user_id and pwd = @pwd;";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@pwd", user_pwd);

            MySqlDataReader reader = command.ExecuteReader();

            User user = new User();

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
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO user (user_id, pwd, name) VALUES (@user_id, @pwd, @name)";
            command.Parameters.AddWithValue("@user_id", user.id);
            command.Parameters.AddWithValue("@pwd", user.pwd);
            command.Parameters.AddWithValue("@name", user.name);

            command.ExecuteNonQuery();
        }

        public static void DeleteUser(string user_id)
        {

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM user_schedule WHERE user_id = @user_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();

            // friendship 테이블에서 해당 user_id를 가진 데이터 삭제
            command.CommandText = "DELETE FROM friendship WHERE user_id = @user_id OR friend_id = @user_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();

            // user_group 테이블에서 해당 user_id를 가진 데이터 삭제
            command.CommandText = "DELETE FROM user_group WHERE user_id = @user_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();

            // user 테이블에서 해당 user_id를 가진 데이터 삭제
            command.CommandText = "DELETE FROM user WHERE user_id = @user_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();
        }


        //friendship 테이블
        public static List<User> SelectFriendship(User user)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT user.* FROM user JOIN friendship ON friendship.friend_id = user.user_id WHERE friendship.user_id = @userId;";
            command.Parameters.AddWithValue("@userId", user.id);

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
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO friendship (user_id, friend_id) VALUES (@user_id, @friend_id)";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@friend_id", friend_id);

            command.ExecuteNonQuery();
        }



        public static void DeleteFriendship(string user_id, string friend_id)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM friendship WHERE user_id = @user_id AND friend_id = @friend_id";
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@friend_id", friend_id);

            command.ExecuteNonQuery();
        }

        //group

        public static void CreateGroup(string name)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO `group` (name) VALUES (@name);";
            command.Parameters.AddWithValue("@name", name);

            command.ExecuteNonQuery();
        }

        public static void DeleteGroup(int groupId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM `group` WHERE group_id = @groupId;";
            command.Parameters.AddWithValue("@groupId", groupId);

            command.ExecuteNonQuery();
        }

        public static void UpdateGroup(int groupId, string name)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE `group` SET name = @name WHERE group_id = @groupId;";
            command.Parameters.AddWithValue("@groupId", groupId);
            command.Parameters.AddWithValue("@name", name);

            command.ExecuteNonQuery();
        }

        public static Dictionary<string, List<User>> SelectGroupsWithFriends(User user)
        {
            // 나한테만 보여지는 Group이라고 가정
            MySqlCommand command = connection.CreateCommand();

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
                command = connection.CreateCommand();
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


            foreach (string groupName in groups.Keys)
            {
                Console.Write("my Group: {0} : ", groupName);
                groups[groupName].ForEach(element => Console.Write(" {0}", element.name));
                Console.WriteLine();
            }

            return groups;
        }


        //usergroup
        // Create
        public static void CreateUserGroup(int groupId, string userId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO `user_group` (group_id, user_id) VALUES (@groupId, @userId);";
            command.Parameters.AddWithValue("@groupId", groupId);
            command.Parameters.AddWithValue("@userId", userId);

            command.ExecuteNonQuery();
        }

        public class UserGroup
        {
            public int UserGroupId { get; set; }
            public int GroupId { get; set; }
            public string UserId { get; set; }

            public UserGroup(int userGroupId, int groupId, string userId)
            {
                UserGroupId = userGroupId;
                GroupId = groupId;
                UserId = userId;
            }
        }

        // Select (특정 user_group_id에 해당하는 데이터 조회)
        public static UserGroup SelectUserGroup(int userGroupId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `user_group` WHERE `user_group_id` = @userGroupId;";
            command.Parameters.AddWithValue("@userGroupId", userGroupId);

            MySqlDataReader reader = command.ExecuteReader();

            UserGroup userGroup = null;

            if (reader.Read())
            {
                int groupId = reader.GetInt32("group_id");
                string userId = reader.GetString("user_id");

                userGroup = new UserGroup(userGroupId, groupId, userId);
            }

            reader.Close();

            return userGroup;
        }


        // Update (특정 user_group_id에 해당하는 데이터 업데이트)
        public static void UpdateUserGroup(int userGroupId, int groupId, string userId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE `user_group` SET group_id = @groupId, user_id = @userId WHERE user_group_id = @userGroupId;";
            command.Parameters.AddWithValue("@userGroupId", userGroupId);
            command.Parameters.AddWithValue("@groupId", groupId);
            command.Parameters.AddWithValue("@userId", userId);

            command.ExecuteNonQuery();
        }

        // Delete (특정 user_group_id에 해당하는 데이터 삭제)
        public static void DeleteUserGroup(int userGroupId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM `user_group` WHERE user_group_id = @userGroupId;";
            command.Parameters.AddWithValue("@userGroupId", userGroupId);

            command.ExecuteNonQuery();
        }



        //userschedule

            public static void UserScheduleCreate(string userId, int scheduleId)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO `user_schedule` (user_id, schedule_id) VALUES (@userId, @scheduleId);";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);

                command.ExecuteNonQuery();
            }

            public static void UserScheduleDelete(int userScheduleId)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM `user_schedule` WHERE user_schedule_id = @userScheduleId;";
                command.Parameters.AddWithValue("@userScheduleId", userScheduleId);

                command.ExecuteNonQuery();
            }

            public static void UserScheduleUpdate(int userScheduleId, string userId, int scheduleId)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE `user_schedule` SET user_id = @userId, schedule_id = @scheduleId WHERE user_schedule_id = @userScheduleId;";
                command.Parameters.AddWithValue("@userScheduleId", userScheduleId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);

                command.ExecuteNonQuery();
            }

            public static List<int> UserScheduleSelect(string userId)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT user_schedule_id FROM `user_schedule` WHERE user_id = @userId;";
                command.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = command.ExecuteReader();

                List<int> userScheduleIds = new List<int>();

                while (reader.Read())
                {
                    int userScheduleId = reader.GetInt32("user_schedule_id");
                    userScheduleIds.Add(userScheduleId);
                }

                reader.Close();

                return userScheduleIds;
            }
       


        //



        public static List<Schedule> SelectSchedules(User user)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT schedule.* FROM schedule JOIN user_schedule WHERE user_schedule.user_id = @myUserId AND user_schedule.schedule_id = schedule.schedule_id;";
            command.Parameters.AddWithValue("@myUserId", user.id);

            MySqlDataReader reader = command.ExecuteReader();

            List<Schedule> schedules = new List<Schedule>();

            while (reader.Read())
            {
                Schedule schedule = new Schedule();

                schedule.category = reader.GetString("category");
                schedule.title = reader.GetString("title");
                schedule.content = reader.GetString("content");
                schedule.startTime = reader.GetDateTime("start_time");
                schedule.endTime = reader.GetDateTime("end_time");

                schedules.Add(schedule);
            }

            reader.Close();

            return schedules;
        }
        public static void CreateSchedule(Schedule schedule)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO schedule (category, title, content, start_time, end_time) " +
                                  "VALUES (@category, @title, @content, @startTime, @endTime);";
            command.Parameters.AddWithValue("@category", schedule.category);
            command.Parameters.AddWithValue("@title", schedule.title);
            command.Parameters.AddWithValue("@content", schedule.content);
            command.Parameters.AddWithValue("@startTime", schedule.startTime);
            command.Parameters.AddWithValue("@endTime", schedule.endTime);

            command.ExecuteNonQuery();
        }

        public static void UpdateSchedule(Schedule schedule)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE schedule " +
                                  "SET category = @category, title = @title, content = @content, " +
                                  "start_time = @startTime, end_time = @endTime " +
                                  "WHERE schedule_id = @scheduleId;";
            command.Parameters.AddWithValue("@category", schedule.category);
            command.Parameters.AddWithValue("@title", schedule.title);
            command.Parameters.AddWithValue("@content", schedule.content);
            command.Parameters.AddWithValue("@startTime", schedule.startTime);
            command.Parameters.AddWithValue("@endTime", schedule.endTime);

            command.ExecuteNonQuery();
        }

        public static void DeleteSchedule(int scheduleId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM schedule WHERE schedule_id = @scheduleId;";
            command.Parameters.AddWithValue("@scheduleId", scheduleId);

            command.ExecuteNonQuery();
        }



    }





    public class Program
    {

        public static Packet LoginProcess(User user)
        {
            Packet sendPacket = new Packet();

            User result = DBProcess.SelectUser(user.id, user.pwd);

            // select 결과가 비어있으면 
            if (result.isEmpty())
            {
                sendPacket.data = null;
                Console.WriteLine(".. id:{0}, pwd:{1}.. fail", user.id, user.pwd);
            }
            else
            {
                sendPacket.data = result;
                Console.WriteLine(".. id:{0}, pwd:{1}.. success", user.id, user.pwd);
            }
            sendPacket.action = ActionType.Response;

            return sendPacket;
        }

        public static Packet ReadAllDataProcess(User user)
        {
            Packet sendPacket = new Packet();

            Dictionary<String, Object> fullData = new Dictionary<String, Object>();

            List<User> friends = DBProcess.SelectFriendship(user);
            List<Schedule> schedules = DBProcess.SelectSchedules(user);
            Dictionary<String, List<User>> groups = DBProcess.SelectGroupsWithFriends(user);

            fullData.Add("friends", friends);
            fullData.Add("schedules", schedules);
            fullData.Add("groups", groups);

            sendPacket.action = ActionType.Response;
            sendPacket.data = fullData;

            return sendPacket;
        }


        async static void AsyncProcess(Object o)
        {
            TcpClient client = (TcpClient)o;
            NetworkStream netstrm = client.GetStream();

            // TcpClient의 Socket 객체를 가져옴
            Socket socket = client.Client;
            string remoteAddress = socket.RemoteEndPoint.ToString();

            while (client.Connected)
            {
                PacketInfo packetInfo = new PacketInfo();
                Packet receivedPacket;
                Packet sendPacket = new Packet();

                byte[] size = new byte[4];

                int recv = await netstrm.ReadAsync(size, 0, 4).ConfigureAwait(false);
                packetInfo.size = BitConverter.ToInt32(size, 0);

                byte[] data = new byte[packetInfo.size];

                recv = await netstrm.ReadAsync(data, 0, packetInfo.size);

                receivedPacket = Packet.Desserialize(data, packetInfo);


                switch (receivedPacket.action)
                {
                    case ActionType.login:
                        Console.Write("[{0}] login request", remoteAddress);

                        User user = (User)receivedPacket.data;

                        sendPacket = LoginProcess(user);
                        break;
                    case ActionType.readAllData:
                        Console.WriteLine("[{0}] readAllData request", remoteAddress);

                        User user1 = (User)receivedPacket.data;

                        sendPacket = ReadAllDataProcess(user1);
                        break;
                    case ActionType.deleteUser:
                        break;
                    case ActionType.editUser:
                        break;
                    default:
                        break;
                }

                // 응답을 전송함

                data = Packet.Serialize(sendPacket, packetInfo);
                size = BitConverter.GetBytes(packetInfo.size); ;

                // packet의 size를 먼저 전송
                await netstrm.WriteAsync(size, 0, 4);
                // 그 다음 packet을 전송
                await netstrm.WriteAsync(data, 0, packetInfo.size);
                netstrm.Flush();
            }

            netstrm.Close();
            client.Close();
        }

        async static Task AsyncServer() {


            TcpListener server = new TcpListener(9050);

            server.Start();


            while(true)
            {
                TcpClient client = await server.AcceptTcpClientAsync().ConfigureAwait(false);

                Task.Run( () => AsyncProcess(client));

            }
        }

        /*public static void Main(string[] args)
        {
            DBProcess.ConnectDB();

            AsyncServer().Wait();*/

        public static async Task Main(string[] args)
        {
            DBProcess.ConnectDB();

            await AsyncServer();




            /*TcpListener server = new TcpListener(9050);

            server.Start();

            while(true)
            {
                server.BeginAcceptTcpClient(new AsyncCallback(AcceptCallback), server);
            }
            */


            // TCP 통신
            TcpListener server = new TcpListener(9050);

            server.Start();
            Console.WriteLine("Waiting for a client....");

            TcpClient client = server.AcceptTcpClient();
            NetworkStream netstrm = client.GetStream();

            Console.WriteLine("Client Connected.. : {0}", client.Client.RemoteEndPoint);

            // 반복문 내에서 실행될 예정임
            //while (true) {  }
            Packet receivedPacket = Packet.ReceivePacket(netstrm);

            switch(receivedPacket.action)
            {
                case ActionType.saveUser:
                    User user = (User)receivedPacket.data;
                    // saveUser(User)함수 실행
                    Console.WriteLine("action : {0}", receivedPacket.action.ToString());
                    Console.WriteLine("id : {0}, pwd : {1}, name : {2}", user.id, user.pwd, user.name);
                    break;
                case ActionType.deleteUser:
                    break;
                case ActionType.editUser:
                    break;
                default:
                    break;
            }
            
            netstrm.Close();
            client.Close();
            server.Stop();

            
        }
    }
}