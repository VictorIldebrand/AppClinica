using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IEmployeeRepository {
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Register(User user);
        Task<Employee> GetEmployeeByEmailAndPassword(string email, string password);
        Task<Employee> GetEmployeeByEmail(string email);
    }
}
