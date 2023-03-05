using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.ViewComponents
{
    [ViewComponent(Name = "User")]
    public class UserViewComponent : ViewComponent
    {
        private IUserRepository _userRepository;

        public UserViewComponent(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("Index");
            }
            UserDto userDto = await _userRepository.GetUserById(Guid.Parse(HttpContext.Session.GetString("_userId")));
            return View("Index", userDto);

        }


    }
}
