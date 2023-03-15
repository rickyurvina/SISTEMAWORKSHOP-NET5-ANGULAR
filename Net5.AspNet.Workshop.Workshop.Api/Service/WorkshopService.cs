using AutoMapper;
using Microsoft.AspNetCore.Http;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Entities = Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Infrastructure.Helper.FileManager;
using System.Linq;
using Net5.AspNet.Workshop.Infrastructure.Constants;

namespace Net5.AspNet.Workshop.Workshop.Api.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly WorkshopUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;        

        public WorkshopService(
            WorkshopUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;            
        }
                
        public List<InstructorDto> ListInstructors(InstructorFilter instructorFilter)
        {
            return _mapper.Map<List<InstructorDto>>(_unitOfWork.Users.ListInstructors(instructorFilter));
        }
        public List<CategoryDto> ListCategories()
        {
            return _mapper.Map<List<CategoryDto>>(_unitOfWork.Categories.GetAll());
        }
        public List<WorkshopStateDto> ListWorkshopStates()
        {
            return _mapper.Map<List<WorkshopStateDto>>(_unitOfWork.WorkshopStates.GetAll());
        }
        public List<EnrollmentStateDto> ListEnrollmentStates(EnrollmentStateFilter enrollmentStateFilter)
        {
            return _mapper.Map<List<EnrollmentStateDto>>(_unitOfWork.EnrollmentStates.ListEnrollmentStates(enrollmentStateFilter));
        }

        public List<WorkshopDto> ListWorkshops(WorkshopFilter workshopFilter)
        {
            return _mapper.Map<List<WorkshopDto>>(_unitOfWork.Workshops.ListWorkshops(workshopFilter));
        }
        public WorkshopDto GetWorkshopByWorshopId(int workshopId)
        {
            WorkshopDto workshopDto = _mapper.Map<WorkshopDto>(_unitOfWork.Workshops.GetWorkshopByWorshopId(workshopId));
            workshopDto.CoverFileData.Base64 = LoadFile(workshopDto.CoverFileData);
            workshopDto.AgendaFileData.Base64 = LoadFile(workshopDto.AgendaFileData);
            return workshopDto;
        }
        public WorkshopDto InsertWorkshop(WorkshopDto workshopDto)
        {            
            Entities.Workshop workshop = _mapper.Map<Entities.Workshop>(workshopDto);
            
            workshop.CoverFileData.Path = "/Images";
            workshop.AgendaFileData.Path = "/Documents";

            workshop.Category = null;
            workshop.InstructorPerson = null;
            workshop.WorkshopState = null;

            _unitOfWork.Workshops.Insert(workshop);
            _unitOfWork.Save();

            workshopDto.AgendaFileData.FileDataId = workshop.AgendaFileData.FileDataId;
            workshopDto.AgendaFileData.Path = workshop.AgendaFileData.Path;
            workshopDto.CoverFileData.FileDataId = workshop.CoverFileData.FileDataId;            
            workshopDto.CoverFileData.Path = workshop.CoverFileData.Path;

            SaveFile(workshopDto.AgendaFileData);
            SaveFile(workshopDto.CoverFileData);

            workshopDto = GetWorkshopByWorshopId(workshop.WorkshopId);
            return workshopDto;
        }
        public WorkshopDto UpdateWorkshop(WorkshopDto workshopDto)
        {
            Entities.Workshop workshop = _unitOfWork.Workshops.GetById(workshopDto.WorkshopId);
            
            workshop.AgendaFileData = _unitOfWork.FileDatum.GetById(workshopDto.AgendaFileDataId);
            workshop.CoverFileData = _unitOfWork.FileDatum.GetById(workshopDto.CoverFileDataId);

            _mapper.Map(workshopDto, workshop);

            workshop.Category = null;
            workshop.InstructorPerson = null;
            workshop.WorkshopState = null;

            _unitOfWork.Workshops.Update(workshop);
            _unitOfWork.Save();

            SaveFile(workshopDto.AgendaFileData);
            SaveFile(workshopDto.CoverFileData);

            workshopDto = GetWorkshopByWorshopId(workshop.WorkshopId);
            return workshopDto;
        }
        public WorkshopDto DeleteWorkshop(int workshopId)
        {
            Entities.Workshop workshop = _unitOfWork.Workshops.GetWorkshopByWorshopId(workshopId);
            WorkshopDto workshopDto = _mapper.Map<WorkshopDto>(workshop);

            _unitOfWork.Workshops.Delete(workshop);
            _unitOfWork.FileDatum.Delete(workshop.AgendaFileData);
            _unitOfWork.FileDatum.Delete(workshop.CoverFileData);
            _unitOfWork.Save();

            DeleteFile(workshopDto.AgendaFileData);
            DeleteFile(workshopDto.CoverFileData);

            return workshopDto;
        }
        
        public List<EnrollmentDto> ListEnrollments(EnrollmentFilter enrollmentFilter)
        {
            return _mapper.Map<List<EnrollmentDto>>(_unitOfWork.Enrollments.ListEnrollments(enrollmentFilter));
        }
        public List<EnrollmentDto> ChangeEnrollmentStates(ChangeEnrollmentStatesFilter changeEnrollmentStatesFilter)
        {
            List<Enrollment> enrollments = _unitOfWork.Enrollments.GetAll(e => changeEnrollmentStatesFilter.EnrollmentIds.Contains(e.EnrollmentId));

            enrollments.ForEach(enrollment =>
            {
                enrollment.EnrollmentStateId = changeEnrollmentStatesFilter.enrollmentStateId;
                _unitOfWork.Enrollments.Update(enrollment);
            });

            _unitOfWork.Save();

            return _mapper.Map<List<EnrollmentDto>>(enrollments);
        }

        public EnrollmentDto InsertEnrollment(EnrollmentDto enrollmentDto)
        {
            Enrollment enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            int personId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == SecurityClaimType.PersonId).FirstOrDefault().Value);

            enrollment.EnrolledPersonId = personId;
            enrollment.EnrollmentDate = DateTime.Now;
            enrollment.WorkshopId = enrollmentDto.WorkshopId;
            enrollment.EnrollmentStateId = EnrollmentStates.Enrolled;

            enrollment.EnrolledPerson = null;
            enrollment.EnrollmentState = null;
            enrollment.Workshop = null;

            _unitOfWork.Enrollments.Insert(enrollment);
            _unitOfWork.Save();

            enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);

            return enrollmentDto;
        }

        public FileDatumDto GetFileDatumByFileDataId(int fileDataId)
        {
            FileDatumDto fileDatum = _mapper.Map<FileDatumDto>(_unitOfWork.FileDatum.GetById(fileDataId));
            fileDatum.ByteArray = LoadByteArray(fileDatum);

            return fileDatum;
        }

        private byte[] LoadByteArray(FileDatumDto fileDatum)
        {
            string filePath = $@"Resources{fileDatum.Path}/{fileDatum.FileDataId}.{fileDatum.Extension}";
            byte[] byteArray =  FileManager.GetBytes(filePath);

            return byteArray;
        }

        private string LoadFile(FileDatumDto fileDatum)
        {
            string filePath = $@"Resources{fileDatum.Path}/{fileDatum.FileDataId}.{fileDatum.Extension}";
            string base64 = FileManager.LoadFileToBase64(filePath);
            string fileBase64 = FileManager.Base64ToFileBase64(base64, fileDatum.Type);

            return fileBase64;
        }
        private void SaveFile(FileDatumDto fileDatum)
        {            
            string filePath = $@"Resources{fileDatum.Path}/{fileDatum.FileDataId}.{fileDatum.Extension}";
            string base64 = fileDatum.Base64.Split(',')[1];
            FileManager.SaveFile(filePath, base64);
        }
        private void DeleteFile(FileDatumDto fileDatum)
        {
            string filePath = $@"Resources{fileDatum.Path}/{fileDatum.FileDataId}.{fileDatum.Extension}";            
            FileManager.DeleteFile(filePath);
        }
    }
}
