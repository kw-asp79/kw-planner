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

namespace Server
{
    public class Program
    {

        public static string connectionString;
        public static MySqlConnection connection;

        public static void ConnectDB()
        {
            /*
            // 데이터베이스 연결 
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
            */

        }
        async static void AsyncProcess(Object o)
        {
            TcpClient client = (TcpClient)o;
            NetworkStream netstrm = client.GetStream();

            while(client.Connected)
            {
                PacketInfo packetInfo = new PacketInfo();

                byte[] size = new byte[4];

                int recv = await netstrm.ReadAsync(size, 0, 4).ConfigureAwait(false);
                packetInfo.size = BitConverter.ToInt32(size, 0);

                byte[] data = new byte[packetInfo.size];

                recv = await netstrm.ReadAsync(data, 0, packetInfo.size);

                Packet receivedPacket = Packet.Desserialize(data, packetInfo);

                User user = (User)receivedPacket.data;
                // saveUser(User)함수 실행
                Console.WriteLine("action : {0}", receivedPacket.action.ToString());
                Console.WriteLine("id : {0}, pwd : {1}, name : {2}", user.id, user.pwd, user.name);



                // 성공적인으로 응답했다고 전송함
                Packet sendPacket = new Packet();
                sendPacket.action = ActionType.Response;
                sendPacket.data = null;

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

                Task.Factory.StartNew(AsyncProcess, client);
            }
        }

        public static void Main(string[] args)
        {
            ConnectDB();

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
