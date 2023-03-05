using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models.Dtos
{
	public class UserDto
	{
        public Guid UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public SchedulerDto Scheduler { get; set; }
        public IEnumerable<ProjectDto> Projects { get; set; }
        public IEnumerable<EventDto> Events { get; set; }

    }
}
