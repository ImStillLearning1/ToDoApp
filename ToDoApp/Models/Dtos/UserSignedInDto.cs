using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.Dtos
{
    public class UserSignedInDto
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
