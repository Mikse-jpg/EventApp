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
        private int _roletype;

        #endregion

        #region Constructor

        public User()
        {
            
        }

        public User(int id, string password, string username, int roletype)
        {
            _id = id;
            _password = password;
            _username = username;
            _roletype = roletype;
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
            set
            {
                checkPassword(value);
                _password = value;
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                checkUsername(value);
                _username = value;
            }
        }

        public int Roletype
        {
            get => _roletype;
            set => _roletype = value;
        }

        #endregion

        #region Methods

        private void checkUsername(string username)
        {
            if (username.Length < 8)
            {
                throw new ArgumentException($"Username must be at least 8 characters. Yours is: {username.Length}");
            }
        }

        private void checkPassword(string password)
        {
            if (password.Length < 8)
            {
                throw new ArgumentException($"Password must be at least 8 characters. Yours is: {password.Length}");
            }
        }


        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(_password)}: {_password}, {nameof(_username)}: {_username}, {nameof(_roletype)}: {_roletype}";
        }

        #endregion

    }
}
