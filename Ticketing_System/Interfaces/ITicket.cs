using Ticketing_System.Models;

namespace Ticketing_System.Interfaces
{
    public interface ITicket
    {
        public List<Ticket> GetAll();

        public List<Ticket> GetOnlyNews();

        public Ticket GetById(int id);

        public void Insert(Ticket ticket);

        public Ticket Update(Ticket ticket);

        public void Delete(int id);

    }
}
