using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Repositories
{
    public static class DependencyInjection
    {
        public class WorkshopRepositoriesOptions
        {
            public string ConnectionString { get; set; }
        }
        public static IServiceCollection AddWorkshopRepositories(this IServiceCollection services, Action<WorkshopRepositoriesOptions> configureOptions)
        {
            var options = new WorkshopRepositoriesOptions();
            configureOptions(options);

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFileDatumRepository, FileDatumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IWorkshopRepository, WorkshopRepository>();
            services.AddScoped<IWorkshopStateRepository, WorkshopStateRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IEnrollmentStateRepository, EnrollmentStateRepository>();
            services.AddScoped<WorkshopUnitOfWork>();

            services.AddDbContext<WorkshopContext>(opt =>
            {
                opt.UseSqlServer(options.ConnectionString);
            });
            return services;
        }
    }
}
