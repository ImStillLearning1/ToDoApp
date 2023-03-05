using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public interface IDutyRepository
    {
        Task<DutyDto> CreateDuty(DutyDto dutyDto);
        Task<DutyDto> UpdateDuty(DutyDto dutyDto);
        Task<bool> DeleteDuty(Guid dutyId);
        Task<DutyDto> GetDuty(Guid dutyId);
        Task<List<DutyDto>> GetUserDuties(Guid userId);

    }
}
