using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public SchedulerViewModel Scheduler { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
        public List<DutyViewModel> Duties { get; set; }
        public List<EventViewModel> Events { get; set; }
    }
}
