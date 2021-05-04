using System.Collections.Generic;
using RestApi.Model.Base;

namespace RestApi.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity

    {
    T Create(T person);
    T Update(T person);
    List<T> FindAll();
    T FindById(long id);
    void Delete(long id);
    bool Exists(long id);
    }
}