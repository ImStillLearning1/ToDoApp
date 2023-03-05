using AutoMapper;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public class SchedulerRepository : ISchedulerRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public SchedulerRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _db = appDbContext;
            _mapper = mapper;
        }
        
        public async Task<SchedulerDto> CreateScheduler(SchedulerDto schedulerDto)
        {
            Scheduler scheduler = _mapper.Map<Scheduler>(schedulerDto);
            _db.Schedulers.Add(scheduler);

            await _db.SaveChangesAsync();

            return _mapper.Map<SchedulerDto>(scheduler);
        }

        public Task<SchedulerDto> DeleteScheduler(SchedulerDto schedulerDto)
        {
            throw new NotImplementedException();
        }

        public Task<SchedulerDto> GetScheduler(Guid schedulerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SchedulerDto>> GetSchedulers()
        {
            throw new NotImplementedException();
        }

        public Task<SchedulerDto> UpdateScheduler(SchedulerDto schedulerDto)
        {
            throw new NotImplementedException();
        }
    }
}
