using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;
using TravelManagement.Persistence.Data.Contexts;

namespace TravelManagement.Application.Queries.Tours.Handlers
{
    public class GetAllToursQueryHandler : IRequestHandler<GetAllToursQuery, IEnumerable<Tour>>
    {
        private readonly TravelDbContext _context;

        public GetAllToursQueryHandler(TravelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tours.ToListAsync(cancellationToken);
        }
    }
}
