using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindByID(long id);
        void Delete(long id);
    }
}
