using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAppLib.Model;

namespace EventApp.Pages.Services
{
    public interface IService<T>
    {

        List<T> GetAll();

        T GetById(int id);

        T Create(T newEvent);

        bool Check(T check);

        T AddReservation(T addToEvent);

        T AddParticipation(T addToEvent);

        string Delete(T newEvent);

        T Modify(T modifiedUserStory, string txt);
    }
}
