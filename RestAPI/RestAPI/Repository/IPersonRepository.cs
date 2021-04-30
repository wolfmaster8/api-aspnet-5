using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindByID(long id);
        void Delete(long id);

        bool Exists(long id);
    }
}
