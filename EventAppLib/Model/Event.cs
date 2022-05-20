﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{

    public class Event
    {
        #region Instance fields
        private int _id;
        private string _title;
        private string _description;
        private int _reservations;
        private DateTime _date;
        private static int NextID = 1;

        #endregion

        #region Constructor

        public Event()
        {

        }

        public Event(int id, string title, string description, int reservations, DateTime date)
        {
            _id = id;
            _title = title;
            _description = description;
            _reservations = reservations;
            _date = date;
        }

        #endregion

        #region Properties

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public int Reservations
        {
            get => _reservations;
            set => _reservations = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public static int NextId
        {
            get => NextID;
            set => NextID = value;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(_title)}: {_title}, {nameof(_description)}: {_description}, {nameof(_reservations)}: {_reservations}, {nameof(_date)}: {_date}";
        }

        #endregion
    }
}
