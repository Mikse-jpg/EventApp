using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;
using Microsoft.Data.SqlClient;

namespace EventApp.Pages.Services
{
    public class UserService : IService<User>
    {
        private readonly List<User> _users;
        private const string connectionString = @"";

        


        public UserService()
        {
            
        }

        public User Create(User newUser)
        {

            string sql = $"insert into [User] values('" + newUser.Id + "', '" + newUser.Username + "', '" + newUser.Password + "', '1')";

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
                    User owner = ReadPerson(reader);
                    

                }
            }

            return newUser;
        }

        public string Delete(User newEvent)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            string sql = "select * from [User]";

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
                    User owner = ReadPerson(reader);
                    users.Add(owner);
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Modify(User modifiedUserStory, string txt)
        {
            throw new NotImplementedException();
        }

        public bool Check(User check)
        {
            if (check == null)
            {
                return false;
            }

            foreach (var us in GetAll())
            {
                if (us.Username == check.Username && us.Password == check.Password)
                {
                    check.Id = us.Id;
                    check.Roletype = us.Roletype;
                    return true;
                }
            }


            return false;
        }


        private User ReadPerson(SqlDataReader reader)
        {
            User h = new User();

            h.Id = reader.GetInt32(0);
            h.Username = reader.GetString(1);
            h.Password = reader.GetString(2);
            h.Roletype = reader.GetInt32(3);


            return h;
        }

        public User AddReservation(User addToEvent)
        {
            throw new NotImplementedException();
        }

        public User AddParticipation(User addToEvent)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllSorted()
        {
            throw new NotImplementedException();
        }
    }
}
