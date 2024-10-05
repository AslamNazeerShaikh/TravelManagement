using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Commands.Tours
{
    public class UpdateTourCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
