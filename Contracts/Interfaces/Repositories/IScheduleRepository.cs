using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IScheduleRepository {
        Task<Schedule> GetScheduleById(int id);
    }
}
