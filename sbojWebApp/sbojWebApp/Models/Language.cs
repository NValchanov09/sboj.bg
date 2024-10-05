using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
    }
}
