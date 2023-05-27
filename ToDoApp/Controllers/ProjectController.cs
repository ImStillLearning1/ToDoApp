using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;


        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [Route("/dodaj-projekt")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "SignIn", action = "Index" }));
            }
            return View();
        }

        public async Task<object> Create(ProjectDto projectDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                projectDto.UserId = Guid.Parse(HttpContext.Session.GetString("_userId"));
                if(ModelState.IsValid)
                {
                    ProjectDto projectModel = await _projectRepository.CreateProject(projectDto);
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
                }
                else
                {
                    return View("Index", projectDto);
                }
                
            }
        }

        [HttpPost]
        public async Task<object> Delete(Guid projectId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _projectRepository.DeleteProject(projectId);
                return RedirectToAction("Index", new { controller = "UserPanel", action = "Index" });
            }
        }

        [HttpPost]
        public async Task<object> Edit(Guid projectId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                ProjectDto projectDto = await _projectRepository.GetProjectWithDuties(projectId, Guid.Parse(HttpContext.Session.GetString("_userId")));
                return View(projectDto);
            }
        }
        public async Task<object> Update(ProjectDto projectDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _projectRepository.UpdateProject(projectDto);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
            }
        }
    }
}
