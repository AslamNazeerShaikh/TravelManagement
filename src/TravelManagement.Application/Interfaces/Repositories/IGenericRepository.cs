using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        public Task UpdateAsync(T entity, CancellationToken cancellationToken);
        public Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
