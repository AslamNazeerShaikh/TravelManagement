using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Application.Features.Tours.Queries
{
    public class GetAllToursQuery : IRequest<IEnumerable<Tour>>
    {
    }
}
