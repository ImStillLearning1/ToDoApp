using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public class DutyRepository : IDutyRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        public DutyRepository(AppDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<DutyDto> CreateDuty(DutyDto dutyDto)
        {
            Duty duty = _mapper.Map<Duty>(dutyDto);
            _db.Duties.Add(duty);

            await _db.SaveChangesAsync();

            //_db.Entry(duty).State = EntityState.Detached;

            return _mapper.Map<DutyDto>(duty);
        }

        public async Task<bool> DeleteDuty(Guid dutyId)
        {
            try
            {
                Duty duty = await _db.Duties.Where(x => x.DutyId == dutyId).FirstOrDefaultAsync();
                _db.Duties.Remove(duty);

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<DutyDto> GetDuty(Guid dutyId)
        {
            Duty duty = await _db.Duties
                .Include(b => b.Project)
                .Where(x => x.DutyId == dutyId)
                //.AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<DutyDto>(duty);
        }

        public async Task<List<DutyDto>> GetUserDuties(Guid userId)
        {
            List<Duty> duties = await _db.Duties.
                Where(x => x.UserId == userId)
                //.AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<DutyDto>>(duties);
        }

        public async Task<DutyDto> UpdateDuty(DutyDto dutyDto)
        {
            var dutyToUpdate = await _db.Duties.Where(x => x.DutyId == dutyDto.DutyId).AsNoTracking().FirstOrDefaultAsync();

            //if (duty == null)
            //{
            //    throw new Exception("Stało się coś dziwnego, nie znaleziono takiego zadania");
            //}

            dutyToUpdate =  _mapper.Map<Duty>(dutyDto);

            _db.Duties.Update(dutyToUpdate);

            await _db.SaveChangesAsync();

            return _mapper.Map<DutyDto>(dutyToUpdate);
        }
    }
}
