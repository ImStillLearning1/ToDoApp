using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
	
	public class SignUpController : Controller
	{

		private IUserRepository _userRepository;
		private ISchedulerRepository _schedulerRepository;
		private IProjectRepository _projectRepository;
		private IDutyRepository _dutyRepository;
		public SignUpController(IUserRepository userRepository, ISchedulerRepository schedulerRepository, IProjectRepository projectRepository, IDutyRepository dutyRepository)
		{
			_userRepository = userRepository;
			_schedulerRepository = schedulerRepository;
			_projectRepository = projectRepository;
			_dutyRepository = dutyRepository;
		}
		// GET: SignUpController
		[Route("/rejestracja")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: SignUpController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SignUpController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SignUpController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("/rejestracja")]
		public async Task<ActionResult> Create(UserDto userDto)
		{
            if (ModelState.IsValid)
			{
				
				SchedulerDto schedulerDto = new SchedulerDto()
				{
					Title = userDto.Login + "'s scheduler",
					Description = "It's the first user's scheduler",
				};
				
                userDto.Scheduler = schedulerDto;
				UserDto userModel = await _userRepository.CreateUser(userDto);

                ProjectDto projectDto = new ProjectDto()
                {
                    Title = "Nieprzypisany",
                    Description = "Domyślny projekt dla nowych zadań",
					UserId = userModel.UserId
                };

                ProjectDto projectModel = await _projectRepository.CreateProject(projectDto);

                DutyDto dutyDto = new DutyDto()
                {
                    Title = "Witaj świecie!",
                    Description = "Pierwsze nowe zadanie do ukończenia w aplikacji.",
                    DutyStatus = 0,
					UserId = userModel.UserId,
					ProjectId = projectModel.ProjectId,
                };

				dutyDto = await _dutyRepository.CreateDuty(dutyDto);
				return View(userModel);
			}
			else
			{
				return View(userDto);
			}
		}

		// GET: SignUpController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SignUpController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SignUpController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SignUpController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
