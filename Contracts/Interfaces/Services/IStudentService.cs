using Contracts.Dto.Student;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IStudentService
    {
        Task<RequestResult<RequestAnswer>> Create(StudentDto StudentDTO);
        Task<RequestResult<StudentDto>> Retrieve(int id);
        Task<RequestResult<StudentDto>> GetStudentById(int id);
        Task<RequestResult<RequestAnswer>> Update(StudentDto student);
        Task<RequestResult<RequestAnswer>> Delete(int id);
        Task<RequestResult<RequestAnswer>> RequestPatient();
    }
}
