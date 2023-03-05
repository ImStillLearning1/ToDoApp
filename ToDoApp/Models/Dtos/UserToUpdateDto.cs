using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.Dtos
{
    public class UserToUpdateDto
    {
        public Guid UserId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
