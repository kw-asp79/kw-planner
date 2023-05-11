using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;

namespace Server
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
                // 데이터베이스 연결
                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                //초기값 설정 
                string name = "testGroup";
                string pwd = "password123";
                int User_id = 100;
                int schedule_id = 0;
                string category = "카테고리";
                string title = "제목";
                string content = "내용";
                DateTime datetime = DateTime.Now;
                int group_id = 10090;
                int friendship_id = 0;
                int friend_id = 0;
                int user_group_id = 0;
                int user_schedule_id = 0;
                
                //command.CommandText는 객체의 속성, 퀴리문 저장하는데 사용 
                command.CommandText = "INSERT INTO asp.group (name, group_id) VALUES (@name1, @group_id1);";
                command.Parameters.AddWithValue("@name1", name);
                command.Parameters.AddWithValue("@group_id1", group_id);
                //쿼리를 실행하는 메서드
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO asp.Schedule(schedule_id, category, title, content, datetime) VALUES (@schedule_id1, @category, @title, @content, @datetime);";
                command.Parameters.AddWithValue("@schedule_id1", schedule_id); // 올리는 과정@ 
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@datetime", datetime);
                command.ExecuteNonQuery();// 업데이트하는 과정@ 

                command.CommandText = "INSERT INTO asp.User(user_id, pwd, name) VALUES (@user_id1, @pwd, @name2);";
                command.Parameters.AddWithValue("@user_id1", User_id);
                command.Parameters.AddWithValue("@pwd", pwd);
                command.Parameters.AddWithValue("@name2", name);
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO asp.Friendship(friendship_id, user_id, friend_id) VALUES (@friendship_id, @user_id2, @friend_id);";
                command.Parameters.AddWithValue("@friendship_id", friendship_id);
                command.Parameters.AddWithValue("@user_id2", User_id);
                command.Parameters.AddWithValue("@friend_id", friend_id);
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO asp.User_group(user_group_id, group_id, user_id) VALUES (@user_group_id, @group_id2, @user_id3);";
                command.Parameters.AddWithValue("@user_group_id", user_group_id);
                command.Parameters.AddWithValue("@group_id2", group_id);
                command.Parameters.AddWithValue("@user_id3", User_id);
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO asp.User_schedule(user_schedule_id, user_id, schedule_id) VALUES (@user_schedule_id, @user_id4, @schedule_id2);";
                command.Parameters.AddWithValue("@user_schedule_id", user_schedule_id);
                command.Parameters.AddWithValue("@user_id4", User_id);
                command.Parameters.AddWithValue("@schedule_id2", schedule_id);
                command.ExecuteNonQuery();

                Console.WriteLine("데이터가 성공적으로 삽입되었습니다.");
            }
            catch (Exception ex)
            {
                // 예외 처리
                Console.WriteLine("오류 발생: " + ex.Message);
            }
            finally
            {
                // 연결 해제
                connection.Close();
            }





            // TCP 통신
            int receive;
            byte[] data = new byte[1024];

            TcpListener newSock = new TcpListener(9050);

            newSock.Start();
            Console.WriteLine("Waiting for a client....");

            TcpClient client = newSock.AcceptTcpClient();
            // NetworkStream ns = client.GetStream();

            Console.WriteLine("Client Connected.. : {0}", client.Client.RemoteEndPoint);

            // ns.Close();
            client.Close();
            newSock.Stop();
        }
    }
}
