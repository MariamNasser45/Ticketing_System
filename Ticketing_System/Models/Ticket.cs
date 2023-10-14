using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Ticket
    {
        [Display(Name ="Ticket Id")]
        public int TicketId { get; set; }

        //[ForeignKey("Category")]
        public Category? category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Severity? severity { get; set; }
        
        [Display(Name = "Severity")]
        public int SeverityId { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; } = 1;
        public Status? status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Issue Start Date")]
        public DateTime IssueStartDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "SL In Hours")]
        public double SLInHours { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created By")]
        public string CreatorId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Creation Date/Time ")]
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Last Action Date/Time ")]

        public DateTime? LastActionDateTime { get; set; }
        
        [Display(Name = "Last Updated By ")]
        public string? LastUpdatedBy { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "SL End Date/Time ")]

        public DateTime? SLEndDateTime { get; set; }

        //// This to calculated column for SL end date/time
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime SLEndDateTime => IssueStartDate.AddHours(SLInHours);  // other syntax is 
        //                                                                      //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime SLEndDateTim{get; private set;} then
        //using HasComputedColumn in OnModelCreating Method


    }
}
