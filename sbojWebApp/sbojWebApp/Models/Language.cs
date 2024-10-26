using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The maximum length for the name is 50 characters.")]
        public string? Name { get; set; }
        [Required]
        [StringLength(2048, ErrorMessage = "The maximum length for the URL is 2048 characters.")]
        public string? ImageURL { get; set; }
    }
}
