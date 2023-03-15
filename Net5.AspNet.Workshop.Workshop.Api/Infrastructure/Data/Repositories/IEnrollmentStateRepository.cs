using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System.Collections.Generic;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public interface IEnrollmentStateRepository : IGenericRepository<EnrollmentState>
    {
        List<EnrollmentState> ListEnrollmentStates(EnrollmentStateFilter enrollmentStateFilter);
    }
}
