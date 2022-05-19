using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{
    class Participants
    {
        #region Instance fields

        private int _userId;
        private int _eventId;
        private int _parking;

        #endregion

        #region Constructor

        public Participants()
        {
            
        }

        public Participants(int userId, int eventId, int parking)
        {
            _userId = userId;
            _eventId = eventId;
            _parking = parking;
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

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(_userId)}: {_userId}, {nameof(_eventId)}: {_eventId}, {nameof(_parking)}: {_parking}";
        }

        #endregion


    }
}
