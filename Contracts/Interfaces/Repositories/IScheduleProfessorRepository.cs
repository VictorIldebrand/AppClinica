using Contracts.Entities;
using System.Threading.Tasks;
namespace Contracts.Interfaces.Repositories {
    public interface IScheduleProfessorRepository {
        Task<ScheduleProfessor> GetScheduleProfessorById(int id);
        Task<ScheduleProfessor> GetScheduleProfessorByProfessorId(int idProfessor);
        Task<ScheduleProfessor> GetScheduleProfessorByScheduleId(int idSchedule);
    }
}
