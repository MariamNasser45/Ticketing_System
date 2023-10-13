using Ticketing_System.Data;
using Ticketing_System.Models;

namespace Ticketing_System.Interfaces.Implemintation
{
    public class StatusImp : IStatus
    {
        private readonly ApplicationDbContext Context;
        public StatusImp(ApplicationDbContext context)
        {
            Context = context;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Status> GellAll()
        {
            return Context.Statuses.ToList();
        }

        public Status Update(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
