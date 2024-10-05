using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Commands.Tours.Handlers
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTourCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _unitOfWork.Tours.GetByIdAsync(request.Id);
            if (tour == null) return false;

            tour.Name = request.Name;
            tour.FromLocation = request.FromLocation;
            tour.ToLocation = request.ToLocation;
            tour.StartDate = request.StartDate;
            tour.EndDate = request.EndDate;
            tour.Price = request.Price;

            _unitOfWork.Tours.Update(tour);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
