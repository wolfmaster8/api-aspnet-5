using System.Collections.Generic;
using RestApi.Data.VO;
using RestApi.Model;

namespace RestApi.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO Update(BookVO book);

        List<BookVO> FindAll();

        BookVO FindById(long id);

        void Delete(long id);
    }
}