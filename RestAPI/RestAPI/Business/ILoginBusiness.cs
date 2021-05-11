using RestApi.Data.VO;

namespace RestApi.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}