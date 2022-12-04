using Contracts.Dto.Employee;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IEmployeeService {
        Task<RequestResult<RequestAnswer>> CreateEmployee(EmployeeDto EmployeeDTO);
        Task<RequestResult<EmployeeDto>> GetEmployeeById(int id);
        Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDto EmployeeDTO, int id);
        Task<RequestResult<RequestAnswer>> DeleteEmployee(int id);

        Task<FilterInfoDto[]> GetAllEmployees();
    }
}
