using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models.Dtos
{
	public class ProjectDto
	{
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }   = DateTime.Now;
        public IEnumerable<DutyDto> Duties { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
