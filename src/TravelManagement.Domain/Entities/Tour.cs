using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Domain.Entities
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tour Name is required.")]
        [StringLength(100, ErrorMessage = "Name should be a maximum of 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "From Location is required.")]
        public string FromLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "To Location is required.")]
        public string ToLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
    }
}
