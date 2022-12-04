using Contracts.Dto.Professor;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IProfessorService {
        Task<RequestResult<RequestAnswer>> CreateProfessor(ProfessorDto ProfessorDto);
        Task<RequestResult<ProfessorDto>> GetProfessorById(int id);
        Task<RequestResult<RequestAnswer>> UpdateProfessor(ProfessorDto ProfessorDto, int id);
        Task<RequestResult<RequestAnswer>> DeleteProfessor(int id);
        Task<FilterInfoDto[]> GetAllProfessors();
    }
}
