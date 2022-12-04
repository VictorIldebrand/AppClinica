using Contracts.Dto.ScheduleProfessor;
using Contracts.RequestHandle;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IScheduleProfessorService {
        Task<RequestResult<RequestAnswer>> CreateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto);
        Task<RequestResult<ScheduleProfessorDto>> GetScheduleProfessorById(int id);
        Task<RequestResult<RequestAnswer>> UpdateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto);
        Task<RequestResult<RequestAnswer>> DeleteScheduleProfessor(int id);
    }
}
