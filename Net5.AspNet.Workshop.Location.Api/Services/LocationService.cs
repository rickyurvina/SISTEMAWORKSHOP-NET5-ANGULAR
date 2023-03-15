using AutoMapper;
using Microsoft.AspNetCore.Http;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationService(
            LocationUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public List<DepartmentDto> ListDepartments()
        {
            return _mapper.Map<List<DepartmentDto>>(_unitOfWork.Departments.GetAll());
        }
        public List<ProvinceDto> ListProvinces(int departmentId)
        {
            return _mapper.Map<List<ProvinceDto>>(_unitOfWork.Provinces.GetAll(p => p.DepartmentId == departmentId));
        }
        public List<DistrictDto> ListDistricts(int provinceId)
        {
            return _mapper.Map<List<DistrictDto>>(_unitOfWork.Districts.GetAll(d => d.ProvinceId == provinceId));
        }
    }
}
