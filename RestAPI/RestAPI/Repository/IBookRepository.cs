using System.Collections.Generic;
using RestApi.Model;

namespace RestApi.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book Update(Book book);

        List<Book> FindAll();

        Book FindById(long id);

        void Delete(long id);

        bool Exists(long id);
    }
}