using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public interface IUserRepository: IGenericRepository<User> 
    {
        User GetUserByUserName(string userName);
        User UpdatePassword(string userName, string newPassword);
    }
}