using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindByID(long id);
        void Delete(long id);
    }
}
