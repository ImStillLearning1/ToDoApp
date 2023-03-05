using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models.Dtos
{
	public class SchedulerDto
	{
        public Guid SchedulerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
