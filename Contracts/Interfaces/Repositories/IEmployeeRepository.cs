using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IEmployeeRepository
    {
        Task<Employee> Register(Employee employee);
        Task<Employee> GetEmployeeByEmailAndPassword(string email, string password);
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<bool> CheckIfEmployeeExistsById(int id);
        Task<bool> CheckIfEmployeeExistsByEmail(string email);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}

