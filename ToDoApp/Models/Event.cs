using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class Event
{ 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EventId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateOfOccurence { get; set; }
    public bool ReminderSent { get; set; } = false;

    public Guid UserId { get; set; }
    public User User { get; set; }
}
