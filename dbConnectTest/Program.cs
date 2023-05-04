using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dbConnectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost;Database=schema;Uid=root;Pwd=deokwon11@");

                connection.Open();

                string Query = "INSERT INTO `schema`.`user` (`user_id`, `pwd`, `name`) VALUES ('12', '12', 'abc');";

                MySqlCommand command = new MySqlCommand(Query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}

