using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Register(Employee employee);
        Task<Employee> GetEmployeeByEmailAndPassword(string email, string password);
        Task<bool> GetEmployeeByEmail(string email);
        Task<bool> CheckIfUserExistsByEmail(string email);
    }
}

