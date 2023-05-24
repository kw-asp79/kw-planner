using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;
using EntityLibrary;
using Org.BouncyCastle.Bcpg;

namespace Server
{
    public class DBProcess
    {
        public static string connectionString;
        public static MySqlConnection connection;

        public static User SelectUser(string user_id, string user_pwd)
        {
            MySqlCommand command; command = connection.CreateCommand();

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

            User result = DBProcess.SelectUser(user.id, user.pwd);

            // select 결과가 비어있으면 
            if (result.isEmpty())
            {
                sendPacket.data = "fail";
                Console.WriteLine(".. id:{0}, pwd:{1}.. fail", user.id, user.pwd);
            }
            else
            {
                sendPacket.data = "success";
                Console.WriteLine(".. id:{0}, pwd:{1}.. success", user.id, user.pwd);
            }
            sendPacket.action = ActionType.Response;

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
                        User user = (User)receivedPacket.data;

                        Console.Write("[{0}] login request", remoteAddress);

                        sendPacket = LoginProcess(user);

                        break;
                    case ActionType.readAllData:
                        Console.WriteLine("[{0}] readAllData request", remoteAddress);
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

        async static Task AsyncServer()
        {

            TcpListener server = new TcpListener(9050);

            server.Start();

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync().ConfigureAwait(false);

                Task.Factory.StartNew(AsyncProcess, client);
            }
        }

        public static void Main(string[] args)
        {
            DBProcess.ConnectDB();

            AsyncServer().Wait();

            /*

            
            *//*
            TcpListener server = new TcpListener(9050);

            server.Start();

            while(true)
            {
                server.BeginAcceptTcpClient(new AsyncCallback(AcceptCallback), server);
            }
            */

            /*
            // TCP 통신
            TcpListener server = new TcpListener(9050);

            server.Start();
            Console.WriteLine("Waiting for a client....");

            TcpClient client = server.AcceptTcpClient();
            NetworkStream netstrm = client.GetStream();

            Console.WriteLine("Client Connected.. : {0}", client.Client.RemoteEndPoint);

            // 반복문 내에서 실행될 예정임
            // while (true) {  }
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

            */
        }
    }

}
