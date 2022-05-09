using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Pages.Services
{
    public class EventService : IEventService
    {
        private List<EventAppLib.Model.Event> _events;

        private const string connectionString = @"Server=tcp:frederik-nissen-zealand-server.database.windows.net,1433;Initial Catalog=SecondSemesterProject;Persist Security Info=False;User ID=fred145aAdmin;Password=Fred145a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public void Create(EventAppLib.Model.Event newEvent)
        {
            throw new NotImplementedException();
        }

        public void Delete(int eventId)
        {
            throw new NotImplementedException();
        }

        public List<EventAppLib.Model.Event> GetAllEvents()
        {
            List<EventAppLib.Model.Event> events = new List<EventAppLib.Model.Event>();

            string queryString = "select * from Event";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EventAppLib.Model.Event h = ReadPerson(reader);
                    events.Add(h);
                }
            }

            return events;

        }

        public EventAppLib.Model.Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public EventAppLib.Model.Event Modify(EventAppLib.Model.Event modifiedUserStory)
        {
            throw new NotImplementedException();
        }

        private EventAppLib.Model.Event ReadPerson(SqlDataReader reader)
        {
            EventAppLib.Model.Event h = new EventAppLib.Model.Event();

            //h.Address = reader.GetString(2);
            //h.Name = reader.GetString(1);
            //h.RoomNumber = reader.GetInt32(0);

            return h;
        }
    }
}
