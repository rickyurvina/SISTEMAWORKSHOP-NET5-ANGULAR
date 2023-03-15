using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System.Collections.Generic;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public interface IWorkshopRepository : IGenericRepository<Entities.Workshop>
    {
        List<Entities.Workshop> ListWorkshops(WorkshopFilter workshopFilter);
        Entities.Workshop GetWorkshopByWorshopId(int workshopId);
    }
}
