using ApiRest.Data.VO;

namespace ApiRest.Business.Interfaces
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(AuthUserVO user);

    }
}
