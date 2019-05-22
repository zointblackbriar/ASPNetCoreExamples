using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialAuthentication.Entities;
using TutorialAuthentication.DTOS;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TutorialAuthentication.Services
{
    public class UserAccount
    {
        private readonly IEnumerable<UserIdenfication> _users = new List<UserIdenfication>
        {
            new UserIdenfication { Id = 1, Username = "XMan", Password = "abc"},
            new UserIdenfication { Id = 2, Username = "YMan", Password = "def"}
        };

        //private configuration property
        private IConfiguration _configuration;

        //return a token info with username password pair
        public string Login(Dtos loginInfo)
        {
            var user = _users.Where(x => x.Username == loginInfo.Username && x.Password == loginInfo.Password).SingleOrDefault();

            if(user == null)
            {
                return null;
            }

            var signingKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);
            var expirationTime = int.Parse(_configuration["Jwt:ExpirationDate"]);

            var tokenDescription = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                //One can add new paramaters in the token Description
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                //define the cypher method
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescription);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
