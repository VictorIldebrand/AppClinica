using Contracts.Dto.Schedule;
using Contracts.RequestHandle;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<RequestResult<RequestAnswer>> CreateSchedule(ScheduleDto ScheduleDTO);
        Task<RequestResult<ScheduleDto>> GetScheduleById(int id);
        Task<RequestResult<RequestAnswer>> UpdateSchedule(ScheduleDto ScheduleDTO, int id);
        Task<RequestResult<RequestAnswer>> DeleteSchedule(int id);
    }
}
