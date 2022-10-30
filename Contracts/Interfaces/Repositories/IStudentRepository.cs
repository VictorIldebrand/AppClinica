using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IStudentRepository {
        Task<Student> GetStudentById(int id);
        Task UpdateStudent(User user);
        Task DeleteStudent(int id);
        Task<Student> GetStudentByEmailAndPassword(string email, string password);
        Task<Student> GetStudentByEmail(string email);
    }
}
