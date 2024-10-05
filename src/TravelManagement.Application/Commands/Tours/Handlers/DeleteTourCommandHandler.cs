using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Commands.Tours.Handlers
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTourCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _unitOfWork.Tours.GetByIdAsync(request.Id);
            if (tour == null) return false;

            _unitOfWork.Tours.Remove(tour);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
