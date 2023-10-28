using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ticketing_System.Data;
using Ticketing_System.Models;

namespace Ticketing_System.Interfaces.Implemintation
{
    public class TicketIMP : ITicket
    {
        private readonly ApplicationDbContext Context;

        public TicketIMP(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<Ticket> GetAll()
        {
           return Context.Tickets.ToList();
        }
        public List<Ticket> GetAllForUser(string id)
        {
            return Context.Tickets
                .Include(t=>t.status).Include(t=>t.category).Include(t=>t.severity)
                .Where(t=>t.CreatorId==id).ToList();
        }
        public List<Ticket> GetByStatus(int id)
        {
            return Context.Tickets.Include(t=>t.category)
                .Include(t=>t.severity)
                .Include(t => t.status).Where(t=>t.StatusId==id).OrderBy(s=>s.SLEndDateTime).ToList();
        }


        public Ticket GetById(int id)
        {
                return Context.Tickets.Include(t=>t.status)
                .Include(t=>t.severity)
                .Include(t=>t.category)
                .SingleOrDefault(t => t.TicketId == id);

            throw new NullReferenceException();
        }

        public bool CheckExistance(int id)
        {
            return Context.Tickets.Any(s=>s.TicketId==id);
        }

        public void Insert(Ticket ticket)
        {
            if(ticket!=null)
            {
                
                ticket.LastActionDateTime = ticket.IssueStartDate;
                ticket.SLEndDateTime = ticket.IssueStartDate.AddHours(ticket.SLInHours);

                Context.Add(ticket);
                Context.SaveChanges();

            }
        }

        public void Update(Ticket ticket)
        {
            if (ticket!=null)
            {
                ticket.LastActionDateTime = DateTime.UtcNow;
                ticket.SLEndDateTime = ticket.IssueStartDate.AddHours(ticket.SLInHours);
                Context.Update(ticket);
                Context.SaveChanges();
            }
           
        }

        public void Delete(int id)
        {
            if(Context.Tickets.Any(t=>t.TicketId==id))
            {
                Context.Tickets.Where(t => t.TicketId == id).ExecuteDelete();
            }
        }
    }
}
