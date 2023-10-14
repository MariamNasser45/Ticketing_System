using Ticketing_System.Models;

namespace Ticketing_System.Interfaces
{
    public interface IStatus
    {
        public List<Status> GetAll();
        public List<Status> GetAllForMan();



    }
}
