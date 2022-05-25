using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;
using Microsoft.Data.SqlClient;

namespace EventApp.Pages.Services
{
    public class ParticipantsService : IService<Participants>
    {

        private const string connectionString =
            @"Server=tcp:frederik-nissen-zealand-server.database.windows.net,1433;Initial Catalog=SecondSemesterProject;Persist Security Info=False;User ID=fred145aAdmin;Password=Fred145a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public ParticipantsService()
        {
            
        }



        public Participants AddParticipation(Participants addToEvent)
        {
            Participants createEvent = addToEvent;

            string sql = $"insert into [Participants] values('" + addToEvent.UserId + "', '" + addToEvent.EventId + "', '" + addToEvent.Parking + "', '" + addToEvent.Reservations + "')";

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
                    Participants owner = ReadParticipants(reader);

                }
            }

            return addToEvent;
        }

        public Participants AddReservation(Participants addToEvent)
        {
            throw new NotImplementedException();
        }

        public bool Check(Participants check)
        {
            throw new NotImplementedException();
        }

        public Participants Create(Participants newEvent)
        {
            throw new NotImplementedException();
        }

        public string Delete(Participants newEvent)
        {
            throw new NotImplementedException();
        }

        public List<Participants> GetAll()
        {
            List<Participants> participants = new List<Participants>();

            string sql = "select * from Participants";

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
                    Participants owner = ReadParticipants(reader);
                    participants.Add(owner);
                }
            }

            return participants;
        }

        public List<Participants> GetAllSorted()
        {
            throw new NotImplementedException();
        }

        public Participants GetById(int id)
        {
            string sql = "select * from Participants where Event_Id=" + id;

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
                    Participants owner = ReadParticipants(reader);
                    return owner;
                }
            }

            return null;

        }

        public Participants Modify(Participants modifiedUserStory, string txt)
        {
            throw new NotImplementedException();
        }
        private Participants ReadParticipants(SqlDataReader reader)
        {
            Participants owner = new Participants();

            owner.UserId = reader.GetInt32(0);
            owner.EventId = reader.GetInt32(1);
            owner.Parking = reader.GetInt32(2);
            owner.Reservations = reader.GetInt32(3);

            return owner;
        }
    }
}
