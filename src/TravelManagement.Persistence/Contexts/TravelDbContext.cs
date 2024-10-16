using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Interfaces;

namespace TravelManagement.Persistence.Contexts
{
    public class TravelDbContext : DbContext, IDbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
