using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class DutyController : Controller
    {
        private IDutyRepository _dutyRepository;
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        public DutyController(IDutyRepository dutyRepository, IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _dutyRepository = dutyRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        [Route("/dodaj-zadanie")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "SignIn", action = "Index" }));
            }
            return View();
        }

        public async Task<object> Create(DutyDto dutyDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }

            else
            {
                dutyDto.UserId = Guid.Parse(HttpContext.Session.GetString("_userId"));
                ProjectDto projectModel = await _projectRepository.GetProjectById(dutyDto.ProjectId);

                dutyDto.DutyStatus = 0;
                dutyDto.ProjectId = projectModel.ProjectId;
                dutyDto.Project = null;
                
                if (ModelState.IsValid)
                {
                    DutyDto dutyModel = await _dutyRepository.CreateDuty(dutyDto);
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
                }
                else
                {
                    return View("Index", dutyDto);
                }
            } 
        }

        [HttpPost]
        public async Task<object> Delete(Guid dutyId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _dutyRepository.DeleteDuty(dutyId);
                return RedirectToAction("Index", new { controller = "UserPanel", action = "Index" });
            }
        }

        [HttpPost]
        public async Task<object> Edit(Guid dutyId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                DutyDto dutyDto = await _dutyRepository.GetDuty(dutyId);
                List<ProjectDto> projectsDto = await _projectRepository.GetUserProjects(dutyDto.UserId);
                EditDutyViewModel dutyViewModel = new EditDutyViewModel()
                {
                    Duty = dutyDto,
                    Projects = projectsDto
                };
                return View(dutyViewModel);
            }
        }

        public async Task<object> Update([Bind(Prefix = "Duty")] DutyDto dutyDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                //DutyDto dutyDto = editDutyViewModel.Duty;
                ProjectDto projectDto = await _projectRepository.GetProjectById(dutyDto.ProjectId);
                UserDto userDto = await _userRepository.GetUserById(dutyDto.UserId);
                dutyDto.UserId = userDto.UserId;
                dutyDto.Project = null;
                dutyDto.ProjectId = projectDto.ProjectId;
                await _dutyRepository.UpdateDuty(dutyDto);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
            }
        }
    }
}
