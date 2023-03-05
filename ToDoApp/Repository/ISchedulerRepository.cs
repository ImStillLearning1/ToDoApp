using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public interface ISchedulerRepository
    {
        Task<SchedulerDto> CreateScheduler(SchedulerDto schedulerDto);
        Task<SchedulerDto> UpdateScheduler(SchedulerDto schedulerDto);
        Task<SchedulerDto> DeleteScheduler(SchedulerDto schedulerDto);
        Task<IEnumerable<SchedulerDto>> GetSchedulers();
        Task<SchedulerDto> GetScheduler(Guid schedulerId);
    }
}
