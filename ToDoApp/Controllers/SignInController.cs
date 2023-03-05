using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
	
	public class SignInController : Controller
	{

		private IUserRepository _userRepository;
		private IDutyRepository _dutyRepository;

		public SignInController(IUserRepository userRepository, IDutyRepository dutyRepository)
		{
			_userRepository = userRepository;
			_dutyRepository = dutyRepository;
		}
        [Route("/logowanie")]
        public IActionResult Index()
		{
			return View();
		}

		public async Task<object> SignIn(UserSignedInDto userSignedInDto)
		{
            if (ModelState.IsValid)
			{
                UserDto userDto = await _userRepository.GetUser(userSignedInDto);
				if(userDto != null)
				{
                    HttpContext.Session.SetString("_userId", userDto.UserId.ToString());
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller="UserPanel", action = "Index" }));
                }
				else
				{
                    return View("SignInFailed", userSignedInDto);
                }
                    
            }
			else
			{
                return View("SignInFailed", userSignedInDto);
            }
		}
    }
}
