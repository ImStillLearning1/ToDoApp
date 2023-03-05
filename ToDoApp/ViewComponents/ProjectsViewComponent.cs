using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.ViewComponents
{
    [ViewComponent(Name = "Projects")]
    public class ProjectsViewComponent : ViewComponent
    { 
        private IProjectRepository _projectRepository;

        public ProjectsViewComponent(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProjectDto> projectsDto = await _projectRepository.GetUserProjects(Guid.Parse(HttpContext.Session.GetString("_userId")));
            return View("Index", projectsDto);
        }
    }
}
