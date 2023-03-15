using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly WorkshopContext _context;        
        public EnrollmentRepository(WorkshopContext context) : base(context)
        {
            _context = context;            
        }

        public List<Enrollment> ListEnrollments(EnrollmentFilter enrollmentFilter)
        {
            var query = from e in _context.Enrollments
                        select e;

            if (!string.IsNullOrEmpty(enrollmentFilter.EnrolledName))
            {
                query = query.Where(e => e.EnrolledPerson.FirstName.Contains(enrollmentFilter.EnrolledName) || e.EnrolledPerson.LastName.Contains(enrollmentFilter.EnrolledName) || e.EnrolledPerson.SurName.Contains(enrollmentFilter.EnrolledName));
            }

            if (!string.IsNullOrEmpty(enrollmentFilter.WorshopTitle))
            {
                query = query.Where(e=>e.Workshop.Title.Contains(enrollmentFilter.WorshopTitle));
            }

            if (!string.IsNullOrEmpty(enrollmentFilter.EnrolledIdentificationNumber))
            {
                query = query.Where(e => e.EnrolledPerson.IdentificationNumber.Contains(enrollmentFilter.EnrolledIdentificationNumber));
            }

            if (enrollmentFilter.WorkshopId > 0)
            {
                query = query.Where(e => e.WorkshopId == enrollmentFilter.WorkshopId);
            }

            if (enrollmentFilter.EnrolledId > 0)
            {
                query = query.Where(e => e.EnrolledPersonId == enrollmentFilter.EnrolledId);
            }

            if (enrollmentFilter.EnrollmentStatesIds.Any())
            {
                query = query.Where(e => enrollmentFilter.EnrollmentStatesIds.Contains(e.EnrollmentStateId));
            }

            if (enrollmentFilter.StarDate != null)
            {
                query = query.Where(e => e.EnrollmentDate >= enrollmentFilter.StarDate);
            }

            if (enrollmentFilter.EndDate != null) {
                query = query.Where(e => e.EnrollmentDate <= enrollmentFilter.EndDate);
            }

            query = query
                    .Include(e => e.EnrolledPerson)
                    .Include(e => e.EnrollmentState)
                    .Include(w => w.Workshop);                    

            List<Enrollment> enrollments = query.ToList();

            return enrollments;
        }

        public Enrollment GetEnrollmentByEnrollmentId(int enrollmentId)
        {
            return null;
            //var query = from w in _context.Workshops
            //            where w.WorkshopId == workshopId
            //            select w;

            //query = query
            //        .Include(w => w.Category)
            //        .Include(w => w.InstructorPerson)
            //        .Include(w => w.WorkshopState)
            //        .Include(w => w.Enrollments)
            //        .Include(w => w.AgendaFileData)
            //        .Include(w => w.CoverFileData);

            //Entities.Workshop workshop = query.FirstOrDefault();

            //return workshop;
        }
    }
}
