using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The maximum length for the name is 100 characters.")]
        public string? Name { get; set; }
        [Required]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double? Latitude { get; set; }
        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double? Longitude { get; set; }
    }
}
