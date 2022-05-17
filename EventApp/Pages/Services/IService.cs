using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Pages.Services
{
    public interface IService<T>
    {
        List<T> GetAll();

        T GetById(int id);

        T Create(T newEvent);

        T Delete(string txt);

        T Modify(T modifiedUserStory, string txt);
    }
}
