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

namespace Server
{
    internal class Program
    {


        static void Main(string[] args)
        {
            /*

            // 데이터베이스 연결 
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connectionString);


            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                string name = "testGroup";

                command.CommandText = "INSERT INTO asp.group (name) VALUES (?name);";
                command.Parameters.AddWithValue("?name", name);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            */

            // TCP 통신
            TcpListener newSock = new TcpListener(9050);

            newSock.Start();
            Console.WriteLine("Waiting for a client....");

            TcpClient client = newSock.AcceptTcpClient();
            NetworkStream netstrm = client.GetStream();

            Console.WriteLine("Client Connected.. : {0}", client.Client.RemoteEndPoint);

            Packet packet = new Packet();
            PacketInfo packetInfo = new PacketInfo();

            // 반복문 내에서 실행될 예정임
            // while (true) { }
            byte[] size = new byte[4];
            int recv = netstrm.Read(size, 0, 4);
            packetInfo.size = BitConverter.ToInt32(size, 0);

            byte[] data = new byte[packetInfo.size];
            recv = netstrm.Read(data, 0, packetInfo.size);

            packet = Packet.Desserialize(data, packetInfo);
            
            User user = (User)packet.data;

            switch(packet.action)
            {
                case ActionType.saveUser:
                    // saveUser(User)함수 실행
                    Console.WriteLine("action : {0}", packet.action.ToString());
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
            newSock.Stop();
        }
    }
}
