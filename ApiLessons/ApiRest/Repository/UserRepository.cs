using ApiRest.Data.VO;
using ApiRest.Model;
using ApiRest.Model.Context;
using ApiRest.Repository.Token;

namespace ApiRest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository (MySQLContext context)
        {
            _context = context;
        }

        public AuthUser ValidateUser(AuthUserVO authUser)
        {

            return null;
        }
    }
}
