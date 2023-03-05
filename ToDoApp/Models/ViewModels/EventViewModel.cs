namespace ToDoApp.Models.ViewModels
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfOccurence { get; set; }
    }
}
