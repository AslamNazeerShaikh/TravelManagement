using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.Interfaces.Repositories;
using TravelManagement.Domain.Common;

namespace TravelManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repositories = new();
        private bool _disposed;

        // Constructor to inject DbContext
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Get repository for the entity type T
        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
        {
            var typeName = typeof(T).Name;
            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryInstance = new GenericRepository<T>(_dbContext);
                _repositories[typeName] = repositoryInstance;
            }

            return (IGenericRepository<T>)_repositories[typeName];
        }

        // Save changes to the database asynchronously
        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Save changes and remove cache entries
        public async Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            var result = await Save(cancellationToken);

            // Example cache invalidation logic (you would replace this with your actual cache removal logic)
            foreach (var cacheKey in cacheKeys)
            {
                // Invalidate cache for each key
                // _cacheService.Remove(cacheKey); (assume you have a cache service)
            }

            return result;
        }

        // Rollback changes in case of error
        public Task Rollback()
        {
            // This is more of a no-op in EF Core, as changes are not committed until SaveChanges is called.
            // Just clear the change tracker if needed.
            _dbContext.ChangeTracker.Clear();
            return Task.CompletedTask;
        }

        // Dispose of the context and managed resources
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        // Implement IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
