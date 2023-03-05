using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models.Dtos
{
	public class DutyDto
	{
        public Guid DutyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        [EnumDataType(typeof(DutyStatus))]
        public DutyStatus DutyStatus { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectDto Project { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }

    }
}
