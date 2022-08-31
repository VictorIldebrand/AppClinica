using Contracts.DTO.User;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services
{
    public interface IUserService
    {
        Task<RequestResult<LoginResponseDto>> Register(UserDto registerRequest);
        Task<RequestResult<LoginResponseDto>> Login(LoginRequestDto loginRequest);
        Task<RequestResult<UserDto>> GetUserById(int id);
        Task<RequestResult<UserDto>> GetUserByEmail(string email);
        Task<RequestResult<RequestAnswer>> UpdateUser(UserDto user);
        Task<RequestResult<RequestAnswer>> DeleteUser(int id);
    }
}
