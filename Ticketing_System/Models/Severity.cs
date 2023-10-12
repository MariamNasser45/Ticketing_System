using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Severity
    {
        public int SeverityId { get; set; }

        [Required]
        [StringLength(15)]
        public string SeverityName { get; set; }
    }
}
