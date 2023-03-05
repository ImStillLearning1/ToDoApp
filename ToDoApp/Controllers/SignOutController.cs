using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class SignOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/wyloguj")]
        public IActionResult SignOut(Guid userId)
        {
            HttpContext.Session.Remove("_userId");
            return View("Index");
        }
    }
}
