using Contracts.DTO.Professor;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IProfessorService {
        Task<RequestResult<RequestAnswer>> CreateProfessor(ProfessorDTO ProfessorDTO);
        Task<RequestResult<ProfessorDTO>> GetProfessorById(int id);
        Task<RequestResult<RequestAnswer>> UpdateProfessor(ProfessorDTO ProfessorDTO);
        Task<RequestResult<RequestAnswer>> DeleteProfessor(int id);
    }
}
