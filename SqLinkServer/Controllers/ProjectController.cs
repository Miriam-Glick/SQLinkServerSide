using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqLinkServer.Models;
using SqLinkServer.services;
using System.Diagnostics;

namespace SqLinkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
         
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;

        }


        [HttpPost]
        [Route("login")]
        public GetAllProjectsResponse GetAllProjectsByUserId(int userId)
        {
            try 
            {  
                GetAllProjectsResponse response = _projectService.GetAllProjectsByUserId(userId);
                return response;
            }
           
            catch (Exception ex) 
            {
                Debug.Write(ex);    
                return null;
            }

          
        }

    }
}
