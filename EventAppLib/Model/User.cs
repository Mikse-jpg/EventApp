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

        private string _name;
        private string _password;
        private int _id;
        private int _numberReservations;
        private int _eventId;

        #endregion

        #region Constructor
        public User()
        {
            
        }

        public User(string name, string password, int id, int numberReservations, int eventId)
        {
            _name = name;
            _password = password;
            _id = id;
            _numberReservations = numberReservations;
            _eventId = eventId;
        }

        #endregion

        #region Properties

        [Required(ErrorMessage = "Remember to pick a username.")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Dit navn skal være mellem 4 og 12 tegn.")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [Required(ErrorMessage = "Remember to pick a password")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Din kode skal være mellem 6 og 16 tegn.")]
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int NumberReservations
        {
            get => _numberReservations;
            set => _numberReservations = value;
        }

        public int EventId
        {
            get => _eventId;
            set => _eventId = value;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(_name)}: {_name}, {nameof(_password)}: {_password}, {nameof(_id)}: {_id}, {nameof(_numberReservations)}: {_numberReservations}, {nameof(_eventId)}: {_eventId}";
        }

        #endregion

    }
}
