using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class UserAccountController : Controller
    {
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private IDutyRepository _dutyRepository;

        public UserAccountController(IUserRepository userRepository, IProjectRepository projectRepository, IDutyRepository dutyRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _dutyRepository = dutyRepository;
        }

        [Route("/konto-uzytkownika/edytuj-konto")]
        public async Task<object> EditUserDetails()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                UserDto userDto = await _userRepository.GetUserById(Guid.Parse(HttpContext.Session.GetString("_userId")));
                return View(userDto);
            }
            
        }

        [Route("/konto-uzytkownika/edytuj-projekty")]
        public async Task<object> EditUserProjects()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                List<ProjectDto> projectsDto = await _projectRepository.GetUserProjects(Guid.Parse(HttpContext.Session.GetString("_userId")));
                return View(projectsDto);
            }
            
        }

        [Route("/konto-uzytkownika/podsumowanie-miesiaca")]
        public async Task<object> GetMonthSummary()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                List<DutyDto> dutiesDto = await _dutyRepository.GetUserDuties(Guid.Parse(HttpContext.Session.GetString("_userId")));
                var today = DateTime.Now;
                var startDate = new DateTime(today.Year, today.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                MonthSummaryViewModel monthSummaryModel = new MonthSummaryViewModel()
                {
                    AllDuties = dutiesDto,
                    NewDuties = dutiesDto.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate),
                    CompletedDuties = dutiesDto.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate).Where(x => x.DutyStatus == Models.DutyStatus.Ukończony),
                    CanceledDuties = dutiesDto.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate).Where(x => x.DutyStatus == Models.DutyStatus.Anulowany)
                };
                return View(monthSummaryModel);
            }
        }

        public async Task<object> Update(UserDto userDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _userRepository.UpdateUser(userDto);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
            }
        }
    }
}
