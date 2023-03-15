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
    public class WorkshopRepository : GenericRepository<Entities.Workshop>, IWorkshopRepository
    {
        private readonly WorkshopContext _context;        
        public WorkshopRepository(WorkshopContext context) : base(context)
        {
            _context = context;            
        }     
        
        public List<Entities.Workshop> ListWorkshops(WorkshopFilter workshopFilter)
        {
            var query = from w in _context.Workshops
                        select w;

            if (!string.IsNullOrEmpty(workshopFilter.Title))
            {
                query = query.Where(w => w.Title.Contains(workshopFilter.Title));
            }

            if (workshopFilter.CategoriesIds.Any())
            {                
                query = query.Where(w => workshopFilter.CategoriesIds.Contains(w.CategoryId));
            }

            if (workshopFilter.WorkshopStatesIds.Any())
            {                
                query = query.Where(w => workshopFilter.WorkshopStatesIds.Contains(w.WorkshopStateId));
            }

            if (workshopFilter.InstructorId > 0)
            {
                query = query.Where(w => w.InstructorPersonId == workshopFilter.InstructorId);
            }

            if(workshopFilter.StartDate != null)
            {
                query = query.Where(w => w.StartDate >= workshopFilter.StartDate);
            }

            if (workshopFilter.EndDate != null)
            {
                query = query.Where(w => w.StartDate <= workshopFilter.EndDate);
            }

            query = query
                    .Include(w => w.Category)
                    .Include(w => w.InstructorPerson)
                    .Include(w => w.WorkshopState)
                    .Include(w => w.Enrollments)
                    .Include(w=>w.AgendaFileData)
                    .Include(w => w.CoverFileData);

            List<Entities.Workshop> workshops = query.ToList();

            return workshops;
        }

        public Entities.Workshop GetWorkshopByWorshopId(int workshopId)
        {
            var query = from w in _context.Workshops
                        where w.WorkshopId == workshopId
                        select w;

            query = query
                    .Include(w => w.Category)
                    .Include(w => w.InstructorPerson)
                    .Include(w => w.WorkshopState)
                    .Include(w => w.Enrollments)
                    .Include(w => w.AgendaFileData)
                    .Include(w => w.CoverFileData);

            Entities.Workshop workshop = query.FirstOrDefault();

            return workshop;
        }
    }
}
