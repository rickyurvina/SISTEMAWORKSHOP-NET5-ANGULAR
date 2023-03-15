using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System.Collections.Generic;

namespace Net5.AspNet.Workshop.Location.Api.Services
{
    public interface ILocationService
    {
        List<DepartmentDto> ListDepartments();
        List<DistrictDto> ListDistricts(int provinceId);
        List<ProvinceDto> ListProvinces(int departmentId);
    }
}