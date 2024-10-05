using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Commands.Tours.Handlers
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTourCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTourCommand request, CancellationToken cancellationToken)
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

            await _unitOfWork.Tours.AddAsync(tour);
            await _unitOfWork.CompleteAsync();
            return tour.Id; // Return the new Tour ID
        }
    }
}
