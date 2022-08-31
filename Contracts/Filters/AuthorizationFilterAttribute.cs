using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Filters
{
    public class AuthorizationFilterAttribute : IAsyncActionFilter
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationFilterAttribute(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isSignRequest = context.RouteData.IsSignRequest();

            if (!isSignRequest)
            {
                var resource = context.RouteData.GetResource();
                var userEmail = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("username"))?.Value;

                if (userEmail != null)
                {
                    var user = await _userRepository.GetUserByEmail(userEmail);
                }
            }

            var result = await next();
        }
    }
}
