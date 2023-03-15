using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Data.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
