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

        public List<Ticket> GetOnlyNews()
        {
            return Context.Tickets.Where(t=>t.StatusId==1).ToList();
        }

        public Ticket GetById(int id)
        {
            if (Context.Tickets.Any(t => t.TicketId == id))
                return Context.Tickets.SingleOrDefault(t => t.TicketId == id);

            throw new NullReferenceException();
        }

        public void Insert(Ticket ticket)
        {
            if(ticket!=null)
            {
                //ticket.StatusId = 1;
                ticket.LastActionDateTime = ticket.IssueStartDate;

                Context.Add(ticket);
                Context.SaveChanges();

            }
        }

        public Ticket Update(Ticket ticket)
        {
            if (ticket!=null)
            {
                Context.Tickets.Where(t=>t.TicketId==ticket.TicketId).ExecuteUpdate(t=>t.SetProperty(t=>t,ticket));
            }
            throw new NullReferenceException();
        }

        public void Delete(int id)
        {
            if(Context.Tickets.Any(t=>t.TicketId==id))
            {
                Context.Tickets.Where(t => t.TicketId == id).ExecuteDelete();
            }
            throw new NotImplementedException();
        }
    }
}
