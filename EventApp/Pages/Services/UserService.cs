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
        private const string connectionString = @"Server=tcp:frederik-nissen-zealand-server.database.windows.net,1433;Initial Catalog=SecondSemesterProject;Persist Security Info=False;User ID=fred145aAdmin;Password=Fred145a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public UserService()
        {
            
        }

        public User Create(User newEvent)
        {
            throw new NotImplementedException();
        }

        public User Delete(string txt)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            string sql = "select * from User where Id=@Id";

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
                    User owner = ReadPerson(reader);
                    return owner;
                }
            }

            return null;
        }

        public User Modify(User modifiedUserStory, string txt)
        {
            throw new NotImplementedException();
        }

        public bool Contains(User user)
        {
            return _users.Contains(user);
        }

        public RoleType ContainsAndGiveRole(User user)
        {
            if (!Contains(user))
            {
                user.Role = RoleType.Guest;
            }
            else
            {
                user.Role = user.UserName.Equals("Frederik") ? RoleType.Admin : RoleType.Guest;
            }

            return user.Role;
        }

        private User ReadPerson(SqlDataReader reader)
        {
            User h = new User();

            //h.Id = reader.GetInt32(0);
            //h.Name = reader.GetString(4);
            


            return h;
        }
    }
}
