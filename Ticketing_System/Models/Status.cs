using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Status
    {
        //to using it instead of implicit "magic" number
        public enum status
        {
            New=1,
            Assigned,
            Resolved,
            Escalated
        }
        public int StatusId { get; set; }

        [Required]
        [StringLength(15)]
        public string StatusName { get; set; }

    }
}
