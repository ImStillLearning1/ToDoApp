using ToDoApp.Models.Dtos;

namespace ToDoApp.Models.ViewModels
{
    public class MonthSummaryViewModel
    {
        public IEnumerable<DutyDto> AllDuties;
        public IEnumerable<DutyDto> NewDuties;
        public IEnumerable<DutyDto> CompletedDuties;
        public IEnumerable<DutyDto> CanceledDuties;
    }
}
