using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Required]
        [StringLength(15)]
        public string StatusName { get; set; }

    }
}
