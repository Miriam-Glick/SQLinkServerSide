using SqLinkServer.Models;

namespace SqLinkServer.services
{
    public interface IAuthenticateService
    {
        LoginResponse Authenticate(LoginRequest model);
    }
}
