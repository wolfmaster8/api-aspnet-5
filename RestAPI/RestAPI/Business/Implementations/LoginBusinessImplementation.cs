using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RestApi.Configurations;
using RestApi.Data.VO;
using RestApi.Repository;
using RestApi.Services;

namespace RestApi.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;

        private readonly ITokenService _tokenService;
        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpire);
            
            DateTime createdDate = DateTime.Now;
            DateTime expirationDate = createdDate.AddMinutes(_configuration.Minutes);

            _repository.RefreshUserInformation(user);
            
            return new TokenVO(
                true, 
                createdDate.ToString(DATE_FORMAT), 
                expirationDate.ToString(DATE_FORMAT),
                accessToken, refreshToken);
        }
    }
}