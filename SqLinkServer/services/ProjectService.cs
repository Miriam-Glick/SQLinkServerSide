using SqLinkServer.DataDB;
using SqLinkServer.Models;

namespace SqLinkServer.services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectsContext _projectsContext;
        public ProjectService(ProjectsContext projectsContext) {
            _projectsContext = projectsContext;
        }

        public GetAllProjectsResponse GetAllProjectsByUserId(int userId)
        {
            List<Project> projects = _projectsContext.Projects.Where(p => p.UserId == userId
            ).ToList();
            GetAllProjectsResponse response = new GetAllProjectsResponse();
            response.projects = projects;
            return response;
        }

        
    }
}
