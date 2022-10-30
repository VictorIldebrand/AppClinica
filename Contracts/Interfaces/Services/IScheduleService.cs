using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<RequestResult<RequestAnswer>> Create(ScheduleDTO ScheduleDTO);
        Task<RequestResult<ScheduleDTO>> GetScheduleById(int id);
        Task<RequestResult<RequestAnswer>> UpdateSchedule(ScheduleDTO ScheduleDTO);
        Task<RequestResult<RequestAnswer>> DeleteSchedule(int id);
    }
}
