using Ticketing_System.Models;

namespace Ticketing_System.Interfaces
{
    public interface ITicket
    {
        public List<Ticket> GetAll();
        public List<Ticket> GetAllForUser(string id);

        public List<Ticket> GetByStatus(int id);

        public Ticket GetById(int id);
        public bool CheckExistance(int id);

        public void Insert(Ticket ticket);

        public void Update(Ticket ticket);

        public void Delete(int id);
    }
}
