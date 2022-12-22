using ApiRest.Data.VO;
using ApiRest.Model;

namespace ApiRest.Repository.Token
{
    public interface IUserRepository
    {
        AuthUser ValidateUser(AuthUserVO authUser);
        void RefreshUserInfo(AuthUser user);

    }
}
