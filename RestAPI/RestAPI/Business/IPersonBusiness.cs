using System.Collections.Generic;
using RestApi.Data.VO;

namespace RestApi.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        void Delete(long id);
    }
}
