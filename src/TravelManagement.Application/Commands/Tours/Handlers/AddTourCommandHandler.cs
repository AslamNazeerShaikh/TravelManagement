using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Application.Commands.Tours.Handlers
{
    public class AddTourCommandHandler : IRequestHandler<AddTourCommand, Tour>
    {
        private readonly TravelDbContext _context;

        public AddTourCommandHandler(TravelDbContext context)
        {
            _context = context;
        }

        public async Task<Tour> Handle(AddTourCommand request, CancellationToken cancellationToken)
        {
            var tour = new Tour
            {
                Name = request.Name,
                FromLocation = request.FromLocation,
                ToLocation = request.ToLocation,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = request.Price
            };

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync(cancellationToken);
            return tour;
        }
    }
}
