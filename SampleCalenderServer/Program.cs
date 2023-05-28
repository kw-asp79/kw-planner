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

        public static Packet CreateProcess(Object obj)
        {
            Packet sendPacket = new Packet();

            if (obj is User)
            {
                User user = (User)obj;
                // UserRepository.InsertUser(user);
            } else if (obj is Schedule)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;
                // ScheduleRepository.InsertSchedule(schedule, user);
                // 연관관계를 맺어주는 메서드
            }
            else if(obj is Group)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                User user = fullData["user"] as User;
                // GroupRepository.InsertGroup(group, user);
            }

            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet UpdateProcess(Object obj)
        {
            Packet sendPacket = new Packet();

            if (obj is User)
            {
                User user = (User)obj;
                // UserRepository.UpdateUser(user);
            }
            else if (obj is Schedule)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;
                // ScheduleRepository.UpdateSchedule(schedule, user);
            }
            else if (obj is Group)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                User user = fullData["user"] as User;
                // GroupRepository.UpdateGroup(group, user);
            }

            sendPacket.action = ActionType.Success;
            sendPacket.data = null;

            return sendPacket;
        }

        public static Packet DeleteProcess(Object obj)
        {
            Packet sendPacket = new Packet();

            if (obj is User)
            {
                User user = (User)obj;
                // UserRepository.DeleteUser(user);
            }
            else if (obj is Schedule)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Schedule schedule = fullData["schedule"] as Schedule;
                User user = fullData["user"] as User;
                // ScheduleRepository.DeleteSchedule(schedule, user);
            }
            else if (obj is Group)
            {
                Dictionary<string, Object> fullData = obj as Dictionary<string, object>;

                Group group = fullData["group"] as Group;
                User user = fullData["user"] as User;
                // GroupRepository.DeleteGroup(group, user);
            }

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
                        case ActionType.login:
                            Console.Write("[{0}] login request", remoteAddress);
                            user = (User)receivedPacket.data;
                            sendPacket = LoginProcess(user);
                            break;
                        case ActionType.readAllData:
                            Console.WriteLine("[{0}] readAllData request", remoteAddress);
                            user = (User)receivedPacket.data;
                            sendPacket = ReadAllDataProcess(user);
                            break;
                        case ActionType.saveUser:
                            Console.WriteLine("[{0}] saveUser request", remoteAddress);
                            user = (User)receivedPacket.data;
                            sendPacket = CreateProcess(user);
                            break;
                        case ActionType.deleteUser:
                            Console.WriteLine("[{0}] deleteUser request", remoteAddress);
                            user = (User)receivedPacket.data;
                            sendPacket = DeleteProcess(user);
                            break;
                        case ActionType.editUser:
                            Console.WriteLine("[{0}] editUser request", remoteAddress);
                            user = (User)receivedPacket.data;
                            sendPacket = UpdateProcess(user);
                            break;
                        case ActionType.saveSchedule:
                            Console.WriteLine("[{0}] saveSchedule request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = CreateProcess(fullData);
                            break;
                        case ActionType.deleteSchedule:
                            Console.WriteLine("[{0}] deleteSchedule request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = DeleteProcess(fullData);
                            break;
                        case ActionType.editSchedule:
                            Console.WriteLine("[{0}] editSchedule request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = UpdateProcess(fullData);
                            break;
                        case ActionType.saveGroup:
                            Console.WriteLine("[{0}] saveGroup request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = CreateProcess(fullData);
                            break;
                        case ActionType.deleteGroup:
                            Console.WriteLine("[{0}] deleteGroup request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = DeleteProcess(fullData);
                            break;
                        case ActionType.editGroup:
                            Console.WriteLine("[{0}] editGroup request", remoteAddress);
                            fullData = receivedPacket.data as Dictionary<string, object>;
                            sendPacket = UpdateProcess(fullData);
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
                catch (Exception e)
                {

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
