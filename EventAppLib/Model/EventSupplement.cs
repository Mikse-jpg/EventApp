using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppLib.Model
{
    public class EventSupplement
    {
        private int _userId;
        private int _champagne;
        private string _menu;

        public EventSupplement()
        {
            
        }

        public EventSupplement(int userId, int champagne, string menu)
        {
            _userId = userId;
            _champagne = champagne;
            _menu = menu;
        }


        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int Champagne
        {
            get => _champagne;
            set => _champagne = value;
        }

        public string Menu
        {
            get => _menu;
            set => _menu = value;
        }


        public override string ToString()
        {
            return $"{nameof(_userId)}: {_userId}, {nameof(_champagne)}: {_champagne}, {nameof(_menu)}: {_menu}";
        }
    }
}
