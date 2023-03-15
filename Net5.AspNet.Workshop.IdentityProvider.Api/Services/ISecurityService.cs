using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Services
{
    public interface ISecurityService
    {
        Task<bool> ForgotPasswordAsync(string userName, string email);
        UserDto GetUserByUserName(string userName);
        Task<UserDto> InsertUserAsync(UserDto userDto);
    }
}