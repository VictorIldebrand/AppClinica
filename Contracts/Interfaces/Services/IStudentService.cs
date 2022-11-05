using Contracts.Dto.Student;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IStudentService
    {
        Task<RequestResult<StudentDto>> CreateStudent(StudentDto StudentDto);
        //Task<RequestResult<StudentDto>> Login(StudentDto StudentDto);
        Task<RequestResult<StudentDto>> GetStudentById(int id);
        Task<RequestResult<StudentDto>> GetStudentByEmail(string email);
        Task<RequestResult<StudentDto>> GetStudentByRa(string ra);
        Task<RequestResult<RequestAnswer>> UpdateStudent(StudentDto student);
        Task<RequestResult<RequestAnswer>> DeleteStudent(int id);
        Task<RequestResult<RequestAnswer>> RequestPatient();


    }
}
