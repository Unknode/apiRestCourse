using ApiRest.Data.VO;
using ApiRest.Model;
using ApiRest.Model.Context;
using ApiRest.Repository.Token;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            var password = ComputeHash(authUser.Password, new SHA256CryptoServiceProvider());

            return _context.Users.FirstOrDefault(u => (u.UserName == authUser.UserName) && (u.Password == password));
        }

        private string ComputeHash(string password, SHA256CryptoServiceProvider hash)
        {
            if (password == null || hash == null)
                return String.Empty;

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = hash.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
