using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TravelManagement.Domain.Entities;

namespace TravelManagement.Application.Features.Tours.Commands
{
    public class AddTourCommand : IRequest<Tour>
    {
        public string? Name { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
