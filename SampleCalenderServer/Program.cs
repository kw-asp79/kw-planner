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
using Org.BouncyCastle.Crmf;

namespace SampleCalenderServer
{
    public static class DBProcess
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
    }


    public class Program
    {
        public static Dictionary<string, TcpClient> connectedUsers = new Dictionary<string, TcpClient>();

        public static Packet SignupProcess(User user)
        {
            Packet sendPacket = new Packet();

            User result = UserRepository.SelectUser(user.id);

            if (result.isEmpty())
            {
                sendPacket.action = ActionType.Success;
                Console.WriteLine(".. id:{0}, pwd:{1}.. success", user.id, user.pwd);
            }
            else
            {
                sendPacket.action = ActionType.Fail;
                Console.WriteLine(".. id:{0}, pwd:{1}.. fail", user.id, user.pwd);
            }

            if(sendPacket.action == ActionType.Success)
            {
                UserRepository.CreateUser(user);
            }

            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet LoginProcess(User user)
        {
            Packet sendPacket = new Packet();

            User result = UserRepository.SelectUser(user.id, user.pwd);

            // select 결과가 비어있으면 
            if (result.isEmpty())
            {
                sendPacket.action = ActionType.Fail;
                Console.WriteLine(".. id:{0}, pwd:{1}.. fail", user.id, user.pwd);
            }
            else
            {
                sendPacket.action = ActionType.Success;
                Console.WriteLine(".. id:{0}, pwd:{1}.. success", user.id, user.pwd);
            }
            
            sendPacket.data = result;

            return sendPacket;
        }

        public static Packet ReadAllDataProcess(User user)
        {
            Packet sendPacket = new Packet();

            Dictionary<String, Object> fullData = new Dictionary<String, Object>();

            List<User> friends = UserRepository.SelectFriends(user);
            List<Schedule> schedules = ScheduleRepository.SelectSchedules(user);
            Dictionary<String, List<User>> groups = GroupRepository.SelectGroupsWithFriends(user);

            fullData.Add("friends", friends);
            fullData.Add("schedules", schedules);
            fullData.Add("groups", groups);

            sendPacket.action = ActionType.Success;
            sendPacket.data = fullData;

            return sendPacket;
        }

        public static Packet CreateProcess(Object obj, string forWhatProcess)
        {
            Packet sendPacket = new Packet();

            if (forWhatProcess.Equals("user"))
            {
                User user = (User)obj;
                // UserRepository.InsertUser(user);
            } 
            else if (forWhatProcess.Equals("schedule")){
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;
                int scheduleId = ScheduleRepository.CreateSchedule(schedule);
                // 연관관계를 맺어주는 메서드
                ScheduleRepository.CreateUserSchedule(user.id, scheduleId);
            }
            else if (forWhatProcess.Equals("group")){
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                User user = fullData["user"] as User;
                GroupRepository.CreateGroup(group.name, user.id);
            }else if (forWhatProcess.Equals("friendship")){
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                User user = fullData["user"] as User;
                User friend = fullData["friend"] as User;
                UserRepository.CreateFriendship(user.id, friend.id);
            }else if (forWhatProcess.Equals("user_group"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                string groupName = fullData["groupName"] as string;
                User myUserInfo = fullData["myUserInfo"] as User;
                List<User> friendsInGroup = fullData["friendsInGroup"] as List<User>;

                int groupId = GroupRepository.SelectGroupIdByName(groupName, myUserInfo.id);
                GroupRepository.AddUserListToGroup(groupId, friendsInGroup);
            }

            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet UpdateProcess(Object obj, string forWhatProcess)
        {
            Packet sendPacket = new Packet();

            if (forWhatProcess.Equals("user"))
            {
                User user = (User)obj;
                // UserRepository.UpdateUser(user);
            }
            else if (forWhatProcess.Equals("schedule"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;

                schedule.id = ScheduleRepository.SelectScheduleId(schedule, user.id);
                ScheduleRepository.UpdateSchedule(schedule);
            }
            else if (forWhatProcess.Equals("group"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                string newGroupName = fullData["newGroupName"] as string;
                User user = fullData["user"] as User;

                int groupId = GroupRepository.SelectGroupIdByName(group.name, user.id);
                GroupRepository.UpdateGroup(groupId, newGroupName, user.id);
            }

            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet DeleteProcess(Object obj, string forWhatProcess)
        {
            Packet sendPacket = new Packet();

            if (forWhatProcess.Equals("user"))
            {
                User user = (User)obj;
                // UserRepository.DeleteUser(user);
            }
            else if (forWhatProcess.Equals("schedule"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;
                int scheduleId = ScheduleRepository.SelectScheduleId(schedule, user.id);
                ScheduleRepository.DeleteSchedule(scheduleId);
            }
            else if (forWhatProcess.Equals("group"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                User user = fullData["user"] as User;

                int groupId = GroupRepository.SelectGroupIdByName(group.name, user.id);
                GroupRepository.DeleteGroup(groupId);
            }else if (forWhatProcess.Equals("friendship"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                User user = fullData["user"] as User;
                User friend = fullData["friend"] as User;
                UserRepository.DeleteFriendship(user.id, friend.id);
            }else if (forWhatProcess.Equals("user_group"))
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                string groupName = fullData["groupName"] as string;
                User myUserInfo = fullData["myUserInfo"] as User;
                List<User> friendsInGroup = fullData["friendsInGroup"] as List<User>;

                int groupId = GroupRepository.SelectGroupIdByName(groupName, myUserInfo.id);
                GroupRepository.DeleteUserListFromGroup(groupId, friendsInGroup);
            }

            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet ReadProcess(Object obj, string forWhatProcess)
        {
            Packet sendPacket = new Packet();

            if (forWhatProcess.Equals("user"))
            {
                User user = (User)obj;
                User result = UserRepository.SelectUserIdAndNameById(user.id);

                if (result.isEmpty())
                {
                    sendPacket.action = ActionType.Fail;
                    sendPacket.data = null;
                }
                else
                {
                    sendPacket.action = ActionType.Success;
                    sendPacket.data = result;
                }
            }
            else if (forWhatProcess.Equals("schedule"))
            {

            }
            else if (forWhatProcess.Equals("group"))
            {

            }

            return sendPacket;
        }

        public static Packet ValidateKlasDataProcess(Object obj)
        {
            Dictionary<string, object> fullData = obj as Dictionary<string, object>;

            User user = fullData["user"] as User;
            List<Schedule> schedules = fullData["schedules"] as List<Schedule>;

            foreach(Schedule schedule in schedules)
            {
                // 해당 klas schedule이 데이터베이스에 없으면 -1을 반환함
                int schedule_id = ScheduleRepository.SelectScheduleId(schedule, user.id);

                // 해당 klas schedule이 데이터베이스에 없으면 생성해줌
                if(schedule_id == -1)
                {
                    int created_schedule_id = ScheduleRepository.CreateSchedule(schedule);
                    ScheduleRepository.CreateUserSchedule(user.id, created_schedule_id);
                }
            }

            Packet sendPacket = new Packet();
            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
            
        }

        public static Packet ValidateLibraryDataProcess(Object obj)
        {
            Dictionary<string, object> fullData = obj as Dictionary<string, object>;

            User user = fullData["user"] as User;
            List<Schedule> schedules = fullData["schedules"] as List<Schedule>;

            foreach (Schedule schedule in schedules)
            {
                // 해당 library schedule이 데이터베이스에 없으면 -1을 반환함
                int schedule_id = ScheduleRepository.SelectScheduleId(schedule, user.id);

                // 해당 library schedule이 데이터베이스에 없으면 생성해줌
                if (schedule_id == -1)
                {
                    int created_schedule_id = ScheduleRepository.CreateSchedule(schedule);
                    ScheduleRepository.CreateUserSchedule(user.id, created_schedule_id);
                }
            }

            Packet sendPacket = new Packet();
            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;

        }

        // 일정 공유하기 폼에서 <공유> 버튼 클릭 시
        public static Packet ShareScheduleProcess(Object obj)
        {
            
            Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

            Group group = fullData["group"] as Group;
            Schedule schedule = fullData["schedule"] as Schedule;
            // 아랫줄은 클라이언트에서 초기화한 다음에 넘어와도 괜찮음
            schedule.fromWho = group.user_id;

            int group_id = GroupRepository.SelectGroupIdByName(group.name, group.user_id);

            List<User> userList = GroupRepository.SelectFriendsListByGroupId(group_id);

            // Insert Schedule
            int schedule_id = ScheduleRepository.CreateSchedule(schedule);

            // Insert UserSchedule of me
            ScheduleRepository.CreateUserSchedule(group.user_id, schedule_id);

            // Insert UserSchedule of List<User>
            foreach(User friend in userList)
            {
                ScheduleRepository.CreateUserSchedule(friend.id, schedule_id);
            }

            // Send Packet to Client
            Packet sendPacket = new Packet();
            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        // <요청된 일정 보기> 클릭시
        public static Packet ViewRequestSchedules(Object obj)
        {
            Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

            User myUserInfo = fullData["user"] as User;

            ScheduleRepository.SelectRequestSchedules(myUserInfo);

            Packet sendPacket = new Packet();
            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        // 체크된 일정들에 대해 <수락하기> 클릭시
        public static Packet UpdateRequestToCustom(Object obj)
        {
            Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

            User myUserInfo = fullData["user"] as User;
            List<Schedule> schedules = fullData["schedules"] as List<Schedule>;

            // Schedule이 클라이언트에서 CUSTOM으로 바뀌기 전에 도달해야함
            foreach(Schedule schedule in schedules)
            {
                int schedule_id = ScheduleRepository.SelectScheduleId(schedule, myUserInfo.id);

                // 요청을 보냈던 사람의 schedule_id ..... schedule.fromWho가 잘 채워져있는지 확인할 것
                int schedule_id_of_requester = ScheduleRepository.SelectScheduleId(schedule, schedule.fromWho);

                // 요청을 받은 사람(수락하기 버튼을 누른 유저)의 schedule을 update
                schedule.id = schedule_id;
                schedule.category = "CUSTOM";
                ScheduleRepository.UpdateSchedule(schedule);

                // 요청을 보낸 사람의 schedule을 update
                schedule.id = schedule_id_of_requester;
                ScheduleRepository.UpdateSchedule(schedule);
            }

            Packet sendPacket = new Packet();
            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        async static void AsyncProcess(Object o)
        {
            TcpClient client = (TcpClient)o;
            NetworkStream netstrm = client.GetStream();

            // TcpClient의 Socket 객체를 가져옴
            Socket socket = client.Client;
            string remoteAddress = socket.RemoteEndPoint.ToString();

            Dictionary<string, Object> fullData;
            User user;
            Schedule schedule;
            Group group;

            while (client.Connected)
            {
                try
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
                    case ActionType.signUp:
                        Console.Write("[{0}] login request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = SignupProcess(user);
                        break;
                    case ActionType.login:
                        Console.Write("[{0}] login request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = LoginProcess(user);
                        // 접속중인 유저들 정보를 추가 (채팅과 일정공유에서 사용할 것임)
                        connectedUsers.Add(user.id, client);
                        break;
                    case ActionType.readAllData:
                        Console.WriteLine("[{0}] readAllData request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = ReadAllDataProcess(user);
                        break;
                    case ActionType.readUser:
                        Console.WriteLine("[{0}] readUser request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = ReadProcess(user, "user");
                        break;
                    case ActionType.saveUser:
                        Console.WriteLine("[{0}] saveUser request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = CreateProcess(user, "user");
                        break;
                    case ActionType.deleteUser:
                        Console.WriteLine("[{0}] deleteUser request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = DeleteProcess(user, "user");
                        break;
                    case ActionType.editUser:
                        Console.WriteLine("[{0}] editUser request", remoteAddress);
                        user = (User)receivedPacket.data;
                        sendPacket = UpdateProcess(user, "user");
                        break;
                    case ActionType.saveSchedule:
                        Console.WriteLine("[{0}] saveSchedule request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = CreateProcess(fullData, "schedule");
                        break;
                    case ActionType.deleteSchedule:
                        Console.WriteLine("[{0}] deleteSchedule request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = DeleteProcess(fullData, "schedule");
                        break;
                    case ActionType.editSchedule:
                        Console.WriteLine("[{0}] editSchedule request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = UpdateProcess(fullData, "schedule");
                        break;
                    case ActionType.saveGroup:
                        Console.WriteLine("[{0}] saveGroup request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = CreateProcess(fullData, "group");
                        break;
                    case ActionType.deleteGroup:
                        Console.WriteLine("[{0}] deleteGroup request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = DeleteProcess(fullData, "group");
                        break;
                    case ActionType.editGroup:
                        Console.WriteLine("[{0}] editGroup request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = UpdateProcess(fullData, "group");
                        break;
                    case ActionType.saveFriendship:
                        Console.WriteLine("[{0}] saveFriendship request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = CreateProcess(fullData, "friendship");
                        break;
                    case ActionType.deleteFriendship:
                        Console.WriteLine("[{0}] deleteFriendship request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = DeleteProcess(fullData, "friendship");
                        break;
                    case ActionType.saveUserGroup:
                        Console.WriteLine("[{0}] saveUserGroup request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = CreateProcess(fullData, "user_group");
                        break;
                    case ActionType.deleteUserGroup:
                        Console.WriteLine("[{0}] deleteUserGroup request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = DeleteProcess(fullData, "user_group");
                        break;
                    case ActionType.validateKlasData:
                        Console.WriteLine("[{0}] validateKlasData request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = ValidateKlasDataProcess(fullData);
                        break;
                    case ActionType.validateLibraryData:
                        Console.WriteLine("[{0}] validateLibraryData request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = ValidateLibraryDataProcess(fullData);
                        break;
                    case ActionType.shareSchedule:
                        Console.WriteLine("[{0}] shareSchedule request", remoteAddress);
                        fullData = receivedPacket.data as Dictionary<string, object>;
                        sendPacket = ShareScheduleProcess(fullData);
                        break;
                    case ActionType.ClientClosed:
                        Console.WriteLine("[{0}] ClientClosed request", remoteAddress);
                        throw new Exception("ClientClosed");                   
                    default:
                        break;
                    }

                    // 응답을 전송함
                    data = Packet.Serialize(sendPacket, packetInfo);
                    size = BitConverter.GetBytes(packetInfo.size);

                    // packet의 size를 먼저 전송
                    await netstrm.WriteAsync(size, 0, 4);
                    // 그 다음 packet을 전송
                    await netstrm.WriteAsync(data, 0, packetInfo.size);
                    netstrm.Flush();
                }
              
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                  
                    // 만약 클라이언트가 폼을 종료했다면.. 
                    if (e.Message.Contains("ClientClosed"))
                    {
                        Console.WriteLine("main form closed event: Client closed!!");
                        netstrm.Close();
                        client.Close();

                        return;
                    }


                }



            }


        }

        async static Task AsyncServer()
        {

            TcpListener server = new TcpListener(9050);

            server.Start();

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync().ConfigureAwait(false);

                Task.Run(() => AsyncProcess(client));
            }
        }

        public static void Main(string[] args)
        {
            DBProcess.ConnectDB();

            AsyncServer().Wait();
        }
    }
}
