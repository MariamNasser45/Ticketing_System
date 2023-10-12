using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        //[ForeignKey("Category")]
        public Category category { get; set; }
        public int CategoryId { get; set; }
        public Severity severity { get; set; }
        public int SeverityId { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime IssueStartDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SLInHours { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public string CreatorId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastActionDateTime { get; set; }
        public string LastUpdatedBy { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime SLEndDateTime { get; set; }

        //// This to calculated column for SL end date/time
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime SLEndDateTime => IssueStartDate.AddHours(SLInHours);  // other syntax is 
        //                                                                      //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime SLEndDateTim{get; private set;} then
        //using HasComputedColumn in OnModelCreating Method
    }
}
