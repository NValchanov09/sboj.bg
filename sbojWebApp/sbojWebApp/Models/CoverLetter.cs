using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class CoverLetter
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public string? Conclusion { get; set; }
    }
}
