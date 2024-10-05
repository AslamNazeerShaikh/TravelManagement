using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? FromLocation { get; set; } = string.Empty;
        public string? ToLocation { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
