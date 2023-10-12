using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

namespace Ticketing_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.Entity<Ticket>().Property(t => t.SLEndDateTime)
            //    .HasComputedColumnSql("[IssueStartDate] [SLInHours]");

            builder.Entity<Category>().HasData(
        new Category { CategoryId = 1, CategoryName = "Hardware" },
        new Category { CategoryId = 2, CategoryName = "Software" },
        new Category { CategoryId = 3, CategoryName = "Network" }
    );

            builder.Entity<Severity>().HasData(
                new Severity { SeverityId = 1, SeverityName = "Low" },
                new Severity { SeverityId = 2, SeverityName = "Medium" },
                new Severity { SeverityId = 3, SeverityName = "High" }
            );

            builder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "New" },
                new Status { StatusId = 2, StatusName = "Assigned" },
                new Status { StatusId = 3, StatusName = "Resolved" },
                new Status { StatusId = 4, StatusName = "Escalated" }
            );

        }

        DbSet<Category> Categories { get; set; }

        DbSet<Severity> Severities { get; set; }

        DbSet<Status> Statuses { get; set; }

        DbSet<Ticket> Tickets { get; set; }

    }
}