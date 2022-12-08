using ApiRest.Business.Interfaces;
using ApiRest.Configurations;
using ApiRest.Data.VO;
using ApiRest.Repository.Token;
using ApiRest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiRest.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private TokenConfiguration _configuration;
        private IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginBusiness(TokenConfiguration configuration, IUserRepository userRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(AuthUserVO userCredentials)
        {
            var user = _userRepository.ValidateUser(userCredentials);

            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim (JwtRegisteredClaimNames.UniqueName,user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshedToken = refreshToken;
            user.RefreshedTokenExpireTime = DateTime.Now.AddDays(_configuration.DaysToExpire);

            DateTime createdDate = DateTime.Now;
            DateTime expirationDate = createdDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createdDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }
    }
}
