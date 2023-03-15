using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Helper.Mapper
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Person.Title))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.Person.SurName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Person.FirstName} {src.Person.LastName} {src.Person.SurName}"))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.Person.IdentificationNumber))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Person.AddressId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Person.Address))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles));

            CreateMap<UserDto, User>()
                .ForPath(dest => dest.Person.Title, opt => opt.MapFrom(src => src.Title))
                .ForPath(dest => dest.Person.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.Person.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForPath(dest => dest.Person.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForPath(dest => dest.Person.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                .ForPath(dest => dest.Person.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForPath(dest => dest.Person.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<UserRole, RoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.Role.NormalizedName))
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.MapFrom(src => src.Role.ConcurrencyStamp));

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();

            CreateMap<Province, ProvinceDto>();
            CreateMap<ProvinceDto, Province>();

            CreateMap<District, DistrictDto>();
            CreateMap<DistrictDto, District>();
        }
    }
}
