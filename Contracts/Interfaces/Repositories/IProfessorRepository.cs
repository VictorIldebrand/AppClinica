using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IProfessorRepository {
        Task<Professor> GetProfessorById(int id);
        Task<Professor> GetProfessorByEmailAndPassword(string email, string password);
        Task<Professor> GetProfessorByEmail(string email);
    }
}
