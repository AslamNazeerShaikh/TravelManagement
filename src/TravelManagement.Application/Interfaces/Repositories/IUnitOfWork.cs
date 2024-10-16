using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelManagement.Domain.Common;

namespace TravelManagement.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        public Task<int> Save(CancellationToken cancellationToken);
        public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        public Task Rollback();
    }
}
