using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{

    public class Participants
    {
        #region Instance fields

        private int _userId;
        private int _eventId;
        private int _parking;
        private int _reservations;

        #endregion

        #region Constructor

        public Participants()
        {
            
        }

        public Participants(int userId, int eventId, int parking, int reservations)
        {
            _userId = userId;
            _eventId = eventId;
            _parking = parking;
            _reservations = reservations;
        }

        #endregion

        #region Properties

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int EventId
        {
            get => _eventId;
            set => _eventId = value;
        }

        public int Parking
        {
            get => _parking;
            set => _parking = value;
        }

        public int Reservations
        {
            get => _reservations;
            set => _reservations = value;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(_userId)}: {_userId}, {nameof(_eventId)}: {_eventId}, {nameof(_parking)}: {_parking}, {nameof(_reservations)}: {_reservations}";
        }

        #endregion


    }
}
