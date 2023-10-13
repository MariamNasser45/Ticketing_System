using Ticketing_System.Models;

namespace Ticketing_System.Interfaces
{
    public interface IStatus
    {
        public List<Status> GellAll();

        public Status Update(Status status);

        public void Delete(int id);

    }
}
