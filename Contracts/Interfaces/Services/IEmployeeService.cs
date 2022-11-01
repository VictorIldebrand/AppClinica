using Contracts.Dto.Employee;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IEmployeeService {
        Task<RequestResult<EmployeeMinDto>> CreateEmployee(EmployeeDto EmployeeDTO);
        Task<RequestResult<EmployeeDto>> GetEmployeeById(int id);
        Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDto EmployeeDTO);
        Task<RequestResult<RequestAnswer>> DeleteEmployee(int id);
    }
}
