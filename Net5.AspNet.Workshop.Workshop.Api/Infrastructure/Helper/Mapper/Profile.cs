using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Helper.Mapper
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<User, InstructorDto>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Person.Title))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
               .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.Person.SurName))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Person.FirstName} {src.Person.LastName} {src.Person.SurName}"))
               .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.Person.IdentificationNumber));               
               
            CreateMap<Data.Entities.Workshop, WorkshopDto>()
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorPersonId))
                .ForMember(dest => dest.Instructor, opt => opt.MapFrom(src => src.InstructorPerson))
                .ForMember(dest => dest.StartTimeString, opt => opt.MapFrom(src => $"{src.StartTime.Hours}:{src.StartTime.Minutes}"))                
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Enrollments.Count));

            CreateMap<WorkshopDto, Data.Entities.Workshop>()
                .ForMember(dest => dest.InstructorPersonId, opt => opt.MapFrom(src => src.InstructorId))
                .ForMember(dest => dest.InstructorPerson, opt => opt.MapFrom(src => src.Instructor))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => 
                    src.StartTimeString.Length == 0 ?
                        new TimeSpan() :
                        new TimeSpan(int.Parse(src.StartTimeString.Split(':', StringSplitOptions.None)[0]), int.Parse(src.StartTimeString.Split(':', StringSplitOptions.None)[1]), 0)
                 ));

            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.EnrolledId, opt => opt.MapFrom(src => src.EnrolledPersonId))
                .ForMember(dest => dest.Enrolled, opt => opt.MapFrom(src => src.EnrolledPerson));
            CreateMap<EnrollmentDto, Enrollment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} {src.SurName}"));
            CreateMap<PersonDto, Person>();                

            CreateMap<Person, InstructorDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} {src.SurName}"));
            CreateMap<InstructorDto, Person>();

            CreateMap<Person, EnrolledDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} {src.SurName}"));
            CreateMap<EnrolledDto, Person>();

            CreateMap<WorkshopState, WorkshopStateDto>();            
            CreateMap<WorkshopStateDto, WorkshopState>();

            CreateMap<EnrollmentState, EnrollmentStateDto>();
            CreateMap<EnrollmentStateDto, EnrollmentState>();

            CreateMap<FileDatum, FileDatumDto>();
            CreateMap<FileDatumDto, FileDatum>();
        }
    }
}
