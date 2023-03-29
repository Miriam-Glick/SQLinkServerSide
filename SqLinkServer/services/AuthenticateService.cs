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
        //        // here I have  hardcoded user for simplicity
        //        private List<User> _users = new List<User> {
        //            new User {
        //                Id = 1, FirstName = "mytest", LastName = "User", Username = "mytestuser", Password = "test123"
        //            }
        //        };
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
            // return null if user not found
            if (user == null) return null;
            // authentication successful so generate jwt token
            var token = GenerateToken(user);
            // Returns User details and Jwt token in HttpResponse which will be user to authenticate the user.
            return new LoginResponse(user, token);
        }

   
    //        //Generate Jwt Token
    //        //private string generateJwtToken(User user)
    //        //{
    //        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
    //        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    //        //    // Here you  can fill claim information from database for the users as well
    //        //    var claims = new[] {
    //        //        new Claim("id", user.Id.ToString()),
    //        //            new Claim(JwtRegisteredClaimNames.Sub, "atul"),
    //        //            new Claim(JwtRegisteredClaimNames.Email, ""),
    //        //            new Claim("Role", "Admin"),
    //        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //        //    };
    //        //    var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer, claims, expires: DateTime.Now.AddHours(24), signingCredentials: credentials);
    //        //    return new JwtSecurityTokenHandler().WriteToken(token);
    //        //}
    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ACDt1vR3lXToPQ1g3MyN");
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
