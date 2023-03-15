using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public static class DependencyInjection
    {
        public class SecurityRepositoriesOptions
        {
            public string ConnectionString { get; set; }
        }
        public static IServiceCollection AddSecurityRepositories(this IServiceCollection services, Action<SecurityRepositoriesOptions> configureOptions)
        {
            var options = new SecurityRepositoriesOptions();
            configureOptions(options);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<SecurityUnitOfWork>();

            services.AddDbContext<SecurityContext>(opt =>
            {
                opt.UseSqlServer(options.ConnectionString);
            });
            return services;
        }
    }
}
