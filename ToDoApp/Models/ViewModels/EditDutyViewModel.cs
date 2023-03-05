using ToDoApp.Models.Dtos;

namespace ToDoApp.Models.ViewModels
{
    public class EditDutyViewModel
    {
        public DutyDto Duty { get; set; }
        public IEnumerable<ProjectDto> Projects { get; set; }
    }
}
