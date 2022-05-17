using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{

    public enum RoleType
    {
        Guest,
        Admin
    }
    public class User
    {

        #region InstanceFields

        
        #endregion

        #region Constructor

        public User():this("","")
        {
            
        }

        public User(string userName, string passWord):this(userName, passWord, RoleType.Guest)
        {
            
        }

        public User(string userName, string passWord, RoleType role)
        {
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }

        #endregion

        #region Properties
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public RoleType Role { get; set; }


        #endregion

        #region Methods

        public bool IsGuest
        {
            get
            {
                return Role == RoleType.Guest;
            }
            
        }

        public bool IsAdmin
        {
            get
            {
                return Role == RoleType.Admin;
            }

        }



        public override string ToString()
        {
            return $"{nameof(UserName)}: {UserName}, {nameof(PassWord)}: {PassWord}, {nameof(Role)}: {Role}";
        }

        #endregion

    }
}
