using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public interface IEventRepository
    {
        Task<EventDto> CreateEvent(EventDto eventDto);
        Task<EventDto> UpdateEvent(EventDto eventDto);
        Task<bool> DeleteEvent(Guid eventId);
        Task<EventDto> GetEvent(Guid eventId);
        Task<List<EventDto>> GetUserEvents(Guid userId);
        Task<IEnumerable<EventDto>> GetAllEvents();
    }
}
