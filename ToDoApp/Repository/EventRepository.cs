using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public EventRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EventDto> CreateEvent(EventDto eventDto)
        {
            Event eventModel = _mapper.Map<Event>(eventDto);
            _db.Events.Add(eventModel);

            await _db.SaveChangesAsync();
            _db.Entry(eventModel).State = EntityState.Detached;

            return _mapper.Map<EventDto>(eventModel);
        }

        public async Task<bool> DeleteEvent(Guid eventId)
        {
            try
            {
                Event eventModel = await _db.Events.Where(x => x.EventId == eventId).FirstOrDefaultAsync();
                _db.Events.Remove(eventModel);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }

        public async Task<EventDto> GetEvent(Guid eventId)
        {
            Event eventModel = await _db.Events.Where(x => x.EventId == eventId).FirstOrDefaultAsync();

            return _mapper.Map<EventDto>(eventModel);
        }

        public async Task<List<EventDto>> GetUserEvents(Guid userId)
        {
            List<Event> events = await _db.Events.Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<List<EventDto>>(events);
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            List<Event> events = await _db.Events.Include(x => x.User).AsNoTracking().ToListAsync();
            return _mapper.Map<List<EventDto>>(events);
        }

        public async Task<EventDto> UpdateEvent(EventDto eventDto)
        {
            Event eventToUpdate = await _db.Events.Where(x => x.EventId == eventDto.EventId).AsNoTracking().FirstOrDefaultAsync();
            eventToUpdate = _mapper.Map<Event>(eventDto);
;            _db.Events.Update(eventToUpdate);

            await _db.SaveChangesAsync();

            return _mapper.Map<EventDto>(eventToUpdate);

        }
    }
}
