using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{

    public class User
    {

        #region InstanceFields

        private int _id;
        private string _password;
        private string _username;

        #endregion

        #region Constructor

        public User()
        {
            
        }

        public User(int id, string password, string username)
        {
            _id = id;
            _password = password;
            _username = username;
        }


        #endregion

        #region Properties
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(_password)}: {_password}, {nameof(_username)}: {_username}";
        }

        #endregion

    }
}
