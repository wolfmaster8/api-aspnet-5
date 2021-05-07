using RestApi.Data.VO;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public User ValidateCredentials(UserVO user)
        {
            throw new NotImplementedException();
        }
    }
}
