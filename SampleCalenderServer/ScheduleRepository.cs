using EntityLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static int SelectScheduleId(Schedule schedule, string userId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

            command.CommandText = "SELECT schedule_id FROM schedule JOIN user_schedule WHERE schedule.category = @category and schedule.title = @title and schedule.content = @content" +
                " and schedule.start_time = @startTime and schedule.end_time = @endTime" +
                " and user_schedule.user_id = @userId and schedule.schedule_id = user_schedule.schedule.id;";
            command.Parameters.AddWithValue("@category", schedule.category);
            command.Parameters.AddWithValue("@title", schedule.title);
            command.Parameters.AddWithValue("@content", schedule.content);
            command.Parameters.AddWithValue("startTime", schedule.startTime);
            command.Parameters.AddWithValue("endTime", schedule.endTime);
            command.Parameters.AddWithValue("@userId", userId);

            MySqlDataReader reader = command.ExecuteReader();

            int id = -1;

            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32("schedule_id");
            }

            reader.Close();

            return id;
        }

        public static void CreateUserSchedule(string userId, int scheduleId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();

            command.CommandText = "INSERT INTO user_schedule (user_id, schedule_id) " +
                                  "VALUES (@userId, @scheduleId);";
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@scheduleId", scheduleId);

            MySqlDataReader reader = command.ExecuteReader();

            reader.Close();

            return;
        }


        public static int CreateSchedule(Schedule schedule)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "INSERT INTO schedule (category, title, content, start_time, end_time) " +
                                  "VALUES (@category, @title, @content, @startTime, @endTime);";
            command.Parameters.AddWithValue("@category", schedule.category);
            command.Parameters.AddWithValue("@title", schedule.title);
            command.Parameters.AddWithValue("@content", schedule.content);
            command.Parameters.AddWithValue("@startTime", schedule.startTime);
            command.Parameters.AddWithValue("@endTime", schedule.endTime);

            command.ExecuteNonQuery();

            command.CommandText = "SELECT LAST_INSERT_ID();";
            int id = (int)command.ExecuteScalar();

            return id;
        }

        public static void UpdateSchedule(Schedule schedule)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "UPDATE schedule " +
                                  "SET category = @category, title = @title, content = @content, " +
                                  "start_time = @startTime, end_time = @endTime " +
                                  "WHERE schedule_id = @scheduleId;";
            command.Parameters.AddWithValue("@category", schedule.category);
            command.Parameters.AddWithValue("@title", schedule.title);
            command.Parameters.AddWithValue("@content", schedule.content);
            command.Parameters.AddWithValue("@startTime", schedule.startTime);
            command.Parameters.AddWithValue("@endTime", schedule.endTime);
            command.Parameters.AddWithValue("@scheduleId", schedule.id);

            command.ExecuteNonQuery();
        }

        public static void DeleteSchedule(int scheduleId)
        {
            MySqlCommand command = DBProcess.connection.CreateCommand();
            command.CommandText = "DELETE FROM schedule WHERE schedule_id = @scheduleId;";
            command.Parameters.AddWithValue("@scheduleId", scheduleId);

            command.ExecuteNonQuery();
        }


    }
}
