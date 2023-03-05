namespace ToDoApp.Models.Dtos
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfOccurence { get; set; }
        public bool ReminderSent { get; set; } = false;

        public Guid UserId { get; set; }
        public UserDto User { get; set; }

    }
}
