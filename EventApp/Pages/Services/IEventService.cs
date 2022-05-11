using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;

namespace EventApp.Pages.Services
{
    public interface IEventService
    {
        List<EventAppLib.Model.Event> GetAllEvents();

        public EventAppLib.Model.Event GetById(int id);

        public void Create(EventAppLib.Model.Event newEvent);

        public void Delete(int eventId);

        public EventAppLib.Model.Event Modify(EventAppLib.Model.Event modifiedUserStory);

    }
}
