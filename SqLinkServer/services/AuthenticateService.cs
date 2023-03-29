using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SqLinkServer.DataDB;
using SqLinkServer.Helpers;
using SqLinkServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SqLinkServer.services
{
    public class AuthenticationService : IAuthenticateService
    {
       
        private readonly IConfiguration _config;
        private readonly ProjectsContext _projectsContext;
        public AuthenticationService(IConfiguration config, 
            ProjectsContext projectsContext)
        {
            _config = config;
            _projectsContext = projectsContext;
            
        }

        public LoginResponse Authenticate(LoginRequest model)
        {
            var user = _projectsContext.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
           
            if (user == null) return null;
          
            var token = GenerateToken(user);
           
            return new LoginResponse(user, token);
        }

   
   private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
         new Claim(ClaimTypes.NameIdentifier,user.Name),
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);

    }



}
}
