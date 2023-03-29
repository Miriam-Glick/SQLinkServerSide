using SqLinkServer.Models;

namespace SqLinkServer.services
{
    public interface IProjectService
    {       
        GetAllProjectsResponse GetAllProjectsByUserId(int userId);

    }
}
