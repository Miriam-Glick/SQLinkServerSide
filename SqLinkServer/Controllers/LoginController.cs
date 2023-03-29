using Catel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using SqLinkServer.Models;
using SqLinkServer.services;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace SqLinkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticateService _authenticateService;
        public LoginController(IConfiguration config, IAuthenticateService authenticateService)
        {
            _config = config;
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("login")]



        public LoginResponse Login([FromBody] LoginRequest userLogin)
        {
            LoginResponse loginResponse;
            try
            {
                LoginResponse user = _authenticateService.Authenticate(userLogin);
                return user;
            }
            catch (Exception ex)
            {


                Debug.Print(ex.ToString());
                return null;
            }
        }
            
        }
    }


