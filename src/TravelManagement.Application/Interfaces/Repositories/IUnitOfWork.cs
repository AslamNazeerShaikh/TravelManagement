using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelManagement.Domain.Interfaces;

namespace TravelManagement.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }     // Expose the DbContext
        Task<int> SaveAsync();          // Method to save changes
        Task RollbackAsync();           // Method for rollback if needed
    }
}
