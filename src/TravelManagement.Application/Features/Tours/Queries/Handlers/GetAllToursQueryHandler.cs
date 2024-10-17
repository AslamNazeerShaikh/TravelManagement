using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TravelManagement.Application.Interfaces.Repositories;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Application.Features.Tours.Queries.Handlers
{
    public class GetAllToursQueryHandler : IRequestHandler<GetAllToursQuery, IEnumerable<Tour>>
    {
        private readonly IGenericRepository<Tour> _tourRepository;

        public GetAllToursQueryHandler(IGenericRepository<Tour> context)
        {
            _tourRepository = context;
        }

        public async Task<IEnumerable<Tour>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            return await _tourRepository.GetAllAsync(cancellationToken);
        }
    }
}
