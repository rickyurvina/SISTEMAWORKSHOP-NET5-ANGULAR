using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
    }
}
