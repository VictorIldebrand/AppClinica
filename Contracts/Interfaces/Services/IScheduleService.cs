using Contracts.Dto.Schedule;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<RequestResult<ScheduleMinDto>> CreateSchedule(ScheduleDto ScheduleDTO);
        Task<RequestResult<ScheduleDto>> GetScheduleById(int id);
        Task<RequestResult<RequestAnswer>> UpdateSchedule(ScheduleDto ScheduleDTO);
        Task<RequestResult<RequestAnswer>> DeleteSchedule(int id);
    }
}
