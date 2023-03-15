
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class WorkshopUnitOfWork:UnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IFileDatumRepository FileDatum { get; }
        public IPersonRepository People { get; }
        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }
        public IWorkshopRepository Workshops { get; }
        public IWorkshopStateRepository WorkshopStates { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IEnrollmentStateRepository EnrollmentStates { get; }

        public WorkshopContext _context { get; }

        public WorkshopUnitOfWork(
            WorkshopContext context,
            ICategoryRepository categoryRepository,
            IFileDatumRepository fileDatumRepository,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IPersonRepository personRepository,
            IWorkshopRepository workshopRepository,
            IWorkshopStateRepository workshopStateRepository,
            IEnrollmentRepository enrollmentRepository,
            IEnrollmentStateRepository enrollmentStateRepository
        ):base(context)
        {
            Categories = categoryRepository;
            FileDatum = fileDatumRepository;
            Users = userRepository;
            UserRoles = userRoleRepository;
            People = personRepository;
            Workshops = workshopRepository;
            WorkshopStates = workshopStateRepository;
            Enrollments = enrollmentRepository;
            EnrollmentStates = enrollmentStateRepository;
        }
    }
}
