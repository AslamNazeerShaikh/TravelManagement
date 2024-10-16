using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelManagement.Application.Interfaces.Repositories;
using TravelManagement.Domain.Interfaces;

namespace TravelManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public IDbContext Context => _context;

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task RollbackAsync()
        {
            await Task.CompletedTask; // Implement rollback logic if needed
        }

        public void Dispose()
        {
            _context?.Dispose(); // Dispose logic
        }
    }
}
