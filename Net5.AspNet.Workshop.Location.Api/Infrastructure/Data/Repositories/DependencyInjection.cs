using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Repositories
{
    public static class DependencyInjection
    {
        public class LocationRepositoriesOptions
        {
            public string ConnectionString { get; set; }
        }
        public static IServiceCollection AddLocationRepositories(this IServiceCollection services, Action<LocationRepositoriesOptions> configureOptions)
        {
            var options = new LocationRepositoriesOptions();
            configureOptions(options);

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<LocationUnitOfWork>();

            services.AddDbContext<LocationContext>(opt =>
            {
                opt.UseSqlServer(options.ConnectionString);
            });
            return services;
        }
    }
}
