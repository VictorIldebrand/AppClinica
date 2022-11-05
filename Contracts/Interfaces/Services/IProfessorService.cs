using Contracts.Dto.Professor;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IProfessorService {
        Task<RequestResult<ProfessorDto>> CreateProfessor(ProfessorDto ProfessorDto);
        Task<RequestResult<ProfessorDto>> GetProfessorById(int id);
        Task<RequestResult<RequestAnswer>> UpdateProfessor(ProfessorDto ProfessorDto);
        Task<RequestResult<RequestAnswer>> DeleteProfessor(int id);
    }
}
