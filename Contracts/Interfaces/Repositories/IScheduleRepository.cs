using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IScheduleRepository {
        Task<Schedule> GetScheduleById(int id);
        Task<Schedule> CreateSchedule(Schedule schedule);
        Task UpdateSchedule(Schedule schedule);
        Task DeleteSchedule(int id);
        Task<bool> CheckIfScheduleExistsById(int id);
    }
}
