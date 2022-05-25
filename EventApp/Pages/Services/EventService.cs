using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EventApp.Pages.Services
{
    public class EventService : IService<EventAppLib.Model.Event>
    {
        private const string connectionString =
            @"Server=tcp:frederik-nissen-zealand-server.database.windows.net,1433;Initial Catalog=SecondSemesterProject;Persist Security Info=False;User ID=fred145aAdmin;Password=Fred145a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public EventService()
        {

        }

        public bool Check(EventAppLib.Model.Event check)
        {
            throw new NotImplementedException();
        }

        public EventAppLib.Model.Event Create(EventAppLib.Model.Event newEvent)
        {

            EventAppLib.Model.Event createEvent = newEvent;

            string sql = $"insert into [Event] values('" + newEvent.Id + "', '" + newEvent.Title + "', '" + newEvent.Description + "', convert(datetime, '" + newEvent.Date + "', 105), '" + newEvent.Reservations + "')";

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);
                    
                }
            }

            return newEvent;

        }

        public EventAppLib.Model.Event AddParticipation(EventAppLib.Model.Event addToEvent)
        {
            throw new NotImplementedException();
        }

        public EventAppLib.Model.Event AddReservation(EventAppLib.Model.Event newEvent)
        {

            EventAppLib.Model.Event createEvent = newEvent;

            string sql = $"update [Event] set Reservations=" + newEvent.Reservations + " + Reservations where Id='" + newEvent.Id + "'";

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);

                }
            }

            return newEvent;

        }

        public string Delete(EventAppLib.Model.Event newEvent)
        {

            EventAppLib.Model.Event createEvent = newEvent;

            //string sql = $"delete from [Event] where Id=" + newEvent.Id + "";
            string sql = $"delete from [Event] where Id=" + newEvent.Id + "";

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);

                }
            }

            return "deleted";
        }

        public List<EventAppLib.Model.Event> GetAll()
        {
            List<EventAppLib.Model.Event> events = new List<EventAppLib.Model.Event>();

            string sql = "select * from Event";

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);
                    events.Add(owner);
                }
            }

            return events;
        }

        public EventAppLib.Model.Event GetById(int id)
        {
            string sql = "select * from Event where Id=" + id;

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //indsæt værdierne
                cmd.Parameters.AddWithValue("@Id", id);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);
                    return owner;
                }
            }

            return null;

        }

        public List<EventAppLib.Model.Event> GetAllSorted()
        {
            List<EventAppLib.Model.Event> events = new List<EventAppLib.Model.Event>();

            string sql = "select * from [Event] order by Date ASC";

            //opret forbindelse til dB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åbner forbindelse
                connection.Open();

                //opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                //læser alle rækker
                while (reader.Read())
                {
                    EventAppLib.Model.Event owner = ReadEvent(reader);
                    events.Add(owner);
                }
            }

            return events;
        }

        public EventAppLib.Model.Event Modify(EventAppLib.Model.Event modifiedUserStory, string txt)
        {
            throw new NotImplementedException();
        }

        private EventAppLib.Model.Event ReadEvent(SqlDataReader reader)
        {
            EventAppLib.Model.Event owner = new EventAppLib.Model.Event();

            owner.Id = reader.GetInt32(0);
            owner.Title = reader.GetString(1);
            owner.Description = reader.GetString(2);
            owner.Date = reader.GetDateTime(3);
            owner.Reservations = reader.GetInt32(4);

            return owner;
        }

        
    }
}