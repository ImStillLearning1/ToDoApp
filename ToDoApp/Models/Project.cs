using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Models
{
	public class Project
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ProjectId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
        public IEnumerable<Duty> Duties { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
