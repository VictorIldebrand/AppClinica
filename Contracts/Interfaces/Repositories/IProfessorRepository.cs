using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IProfessorRepository {
        Task<Professor> GetProfessorById(int id);
        Task<Professor> GetProfessorByEmailAndPassword(string email, string password);
        Task<bool> CheckIfProfessorExistsByEmail(string email);
        Task<bool> CheckIfProfessorExistsById(int id);
        Task<Professor> GetProfessorByEmail(string email);
        Task<Professor> CreateProfessor(Professor professor);
        Task UpdateProfessor(Professor professor);
        Task DeleteProfessor(int id);
        Task<Professor[]> GetAllProfessors();
    }
}
