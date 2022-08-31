using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<string> GetUserPasswordByUserEmail(string email);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<bool> CheckIfUserExistsById(int id);
        Task<bool> CheckIfUserExistsByEmail(string email);
        Task<User> Register(User user);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}
