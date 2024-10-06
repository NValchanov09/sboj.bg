using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
