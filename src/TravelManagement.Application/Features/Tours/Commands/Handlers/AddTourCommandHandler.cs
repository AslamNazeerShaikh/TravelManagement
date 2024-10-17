using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TravelManagement.Application.Interfaces.Repositories;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Application.Features.Tours.Commands.Handlers
{
    public class AddTourCommandHandler : IRequestHandler<AddTourCommand, Tour>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTourCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tour> Handle(AddTourCommand? request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "AddTourCommand cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.FromLocation) ||
                string.IsNullOrWhiteSpace(request.ToLocation))
            {
                throw new ArgumentException("Command contains invalid or missing data.");
            }

            var tour = new Tour
            {
                Name = request.Name,
                FromLocation = request.FromLocation,
                ToLocation = request.ToLocation,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = request.Price
            };

            // await _unitOfWork.Context.Tours.AddAsync(tour, cancellationToken);
            // await _tourRepository.(cancellationToken);
            return tour;
        }
    }
}
