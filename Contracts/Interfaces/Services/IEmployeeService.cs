using Contracts.DTO.Employee;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IEmployeeService {
        Task<RequestResult<RequestAnswer>> CreateEmployee(EmployeeDTO EmployeeDTO);
        Task<RequestResult<EmployeeDTO>> GetEmployeeById(int id);
        Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDTO EmployeeDTO);
        Task<RequestResult<RequestAnswer>> DeleteEmployee(int id);
    }
}
