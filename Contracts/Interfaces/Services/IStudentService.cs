using Contracts.Dto.Student;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IStudentService
    {
        Task<RequestResult<RequestAnswer>> CreateStudent(StudentDto StudentDto);
        Task<RequestResult<StudentMinDto>> GetStudentById(int id);
        Task<RequestResult<StudentMinDto>> GetStudentByEmail(string email);
        Task<RequestResult<StudentMinDto>> GetStudentByRa(string ra);
        Task<RequestResult<RequestAnswer>> UpdateStudent(StudentDto student, int id);
        Task<RequestResult<RequestAnswer>> DeleteStudent(int id);

        Task<FilterInfoDto[]> GetAllStudents();
    }
}
