using RestApi.Data.VO;
using RestApi.Model;

namespace RestApi.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User RefreshUserInformation(User user);
    }
}
