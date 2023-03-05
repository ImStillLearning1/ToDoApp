using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
	public class Duty
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid DutyId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime EndDate { get; set;}

        [EnumDataType(typeof(DutyStatus))]
        public DutyStatus DutyStatus { get; set; }

        public Guid ProjectId { get; set; }
		public Project Project{ get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }


	}
}
