using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoApp.DbContexts;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class UserPanelController : Controller
    {
        private IUserRepository _userRepository;

        public UserPanelController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/dashboard")]
        public async Task<object> Index()
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
    }
}
