using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Helper.Mapper
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<Province, ProvinceDto>();
            CreateMap<District, DistrictDto>();
        }
    }
}
