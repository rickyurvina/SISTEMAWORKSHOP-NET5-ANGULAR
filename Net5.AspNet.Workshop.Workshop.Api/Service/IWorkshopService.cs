using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Services
{
    public interface IWorkshopService
    {        
        List<CategoryDto> ListCategories();
        List<InstructorDto> ListInstructors(InstructorFilter instructorFilter);
        List<WorkshopStateDto> ListWorkshopStates();
        List<EnrollmentStateDto> ListEnrollmentStates(EnrollmentStateFilter enrollmentStateFilter);

        List<WorkshopDto> ListWorkshops(WorkshopFilter workshopFilter);
        WorkshopDto GetWorkshopByWorshopId(int wWorkshopId);
        WorkshopDto InsertWorkshop(WorkshopDto workshopDto);
        WorkshopDto UpdateWorkshop(WorkshopDto workshopDto);
        WorkshopDto DeleteWorkshop(int workshopId);

        List<EnrollmentDto> ListEnrollments(EnrollmentFilter enrollmentFilter);
        List<EnrollmentDto> ChangeEnrollmentStates(ChangeEnrollmentStatesFilter changeEnrollmentStatesFilter);
        EnrollmentDto InsertEnrollment(EnrollmentDto enrollmentDto);

        FileDatumDto GetFileDatumByFileDataId(int fileDataId);
    }
}