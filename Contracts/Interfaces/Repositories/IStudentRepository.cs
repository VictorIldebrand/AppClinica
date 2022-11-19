using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IStudentRepository {
        Task<Student> CreateStudent(Student student);
        Task UpdateStudent(Student Student);
        Task DeleteStudent(int id);
        Task<Student> GetStudentById(int id);
        Task<bool> CheckIfStudentExistsById(int id);
        Task<bool> CheckIfStudentExistsByEmail(string email);
        Task<bool> CheckIfStudentExistsByRa(string ra);
        Task<string> GetStudentPasswordByEmail(string email);
        Task<Student> GetStudentByEmailAndPassword(string email, string password);
        Task<Student> GetStudentByEmail(string email);
        Task<Student> GetStudentByRa(string ra);
        Task<Student[]> GetAllStudents();
    }   
}
