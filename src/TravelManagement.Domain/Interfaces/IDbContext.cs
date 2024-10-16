using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Domain.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<Tour> Tours { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
