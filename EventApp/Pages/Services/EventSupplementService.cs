using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;
using Microsoft.Data.SqlClient;

namespace EventApp.Pages.Services
{
    public class EventSupplementService : IService<EventSupplement>
    {
        private const string connectionString =
            @"Server=tcp:frederik-nissen-zealand-server.database.windows.net,1433;Initial Catalog=SecondSemesterProject;Persist Security Info=False;User ID=fred145aAdmin;Password=Fred145a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public EventSupplementService()
        {
            
        }

        public EventSupplement AddParticipation(EventSupplement addToEvent)
        {
            throw new NotImplementedException();
        }

        public EventSupplement AddReservation(EventSupplement addToEvent)
        {
            throw new NotImplementedException();
        }

        public bool Check(EventSupplement check)
        {
            throw new NotImplementedException();
        }

        public EventSupplement Create(EventSupplement newEvent)
        {
            EventSupplement createEvent = newEvent;

            string sql = $"insert into [Event] values('" + newEvent.UserId + "', '" + newEvent.Champagne + "', '" + newEvent.Menu + "')";

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
                    EventSupplement owner = ReadEventSupplement(reader);

                }
            }

            return newEvent;
        }

        public string Delete(EventSupplement newEvent)
        {
            throw new NotImplementedException();
        }

        public List<EventSupplement> GetAll()
        {
            List<EventSupplement> events = new List<EventSupplement>();

            string sql = "select * from Event_Supplement";

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
                    EventSupplement owner = ReadEventSupplement(reader);
                    events.Add(owner);
                }
            }

            return events;
        }

        public EventSupplement GetById(int id)
        {
            string sql = "select * from Event_Supplement where User_Id=" + id;

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
                    EventSupplement owner = ReadEventSupplement(reader);
                    return owner;
                }
            }

            return null;
        }

        public EventSupplement Modify(EventSupplement modifiedUserStory, string txt)
        {
            throw new NotImplementedException();
        }

        private EventSupplement ReadEventSupplement(SqlDataReader reader)
        {
            EventSupplement owner = new EventSupplement();

            owner.UserId = reader.GetInt32(0);
            owner.Champagne = reader.GetInt32(1);
            owner.Menu = reader.GetString(2);

            return owner;
        }

    }
}
