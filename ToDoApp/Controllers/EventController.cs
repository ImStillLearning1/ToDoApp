using Microsoft.AspNetCore.Mvc;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository _eventRepository;
        private IUserRepository _userRepository;

        public EventController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        [Route("/dodaj-wydarzenie")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "SignIn", action = "Index" }));
            }
            return View();
        }

        public async Task<object> Create(EventDto eventDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }

            else
            {
                eventDto.UserId = Guid.Parse(HttpContext.Session.GetString("_userId"));

                if (ModelState.IsValid)
                {
                    EventDto eventModel = await _eventRepository.CreateEvent(eventDto);
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
                }
                else
                {
                    return View("Index", eventDto);
                }
            }
        }

        [HttpPost]
        public async Task<object> Delete(Guid eventId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _eventRepository.DeleteEvent(eventId);
                return RedirectToAction("Index", new { controller = "UserPanel", action = "Index" });
            }
        }

        [HttpPost]
        public async Task<object> Edit(Guid eventId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                EventDto eventDto = await _eventRepository.GetEvent(eventId);
                return View(eventDto);
            }
        }

        public async Task<object> Update(EventDto eventDto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId")))
            {
                return View("../SessionExpired");
            }
            else
            {
                await _eventRepository.UpdateEvent(eventDto);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "UserPanel", action = "Index" }));
            }
        }
    }
}
