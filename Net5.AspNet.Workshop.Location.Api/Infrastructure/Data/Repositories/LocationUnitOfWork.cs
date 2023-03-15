using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Repositories
{
    public class LocationUnitOfWork:UnitOfWork
    {
        public IDepartmentRepository Departments { get; }
        public IProvinceRepository Provinces { get; }
        public IDistrictRepository Districts { get; }

        public LocationContext _context { get; }

        public LocationUnitOfWork(
            LocationContext context,
            IDepartmentRepository departmentRepository,
            IProvinceRepository provinceRepository,
            IDistrictRepository districtRepository
        ):base(context)
        {
            Departments = departmentRepository;
            Provinces = provinceRepository;
            Districts = districtRepository;
        }

    }
}
