using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;

namespace SampleCalenderServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            // TCP 통신
            int receive;
            byte[] data = new byte[1024];

            TcpListener newSock = new TcpListener(9050);

            newSock.Start();
            Console.WriteLine("Waiting for a client....");

            TcpClient client = newSock.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            Console.WriteLine("Client Connected.. : {0}", client.Client.RemoteEndPoint);

            ns.Close();
            client.Close();
            newSock.Stop();
        }
    }
}
