using EntityLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCalenderServer
{
    public static class ScheduleRepository
    {
        public static List<Schedule> SelectSchedules(User user)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

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
    }
}
