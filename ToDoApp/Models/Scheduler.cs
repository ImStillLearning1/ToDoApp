using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
	public class Scheduler
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid SchedulerId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
