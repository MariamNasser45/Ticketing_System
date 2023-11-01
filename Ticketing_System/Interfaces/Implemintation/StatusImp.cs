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

        public List<Status> GetAll()
        {

            //return Context.Statuses.Where(s=>s.StatusName!="New").ToList();
            
            //using const variable instead of magic string to make it easy to update and
            //don't need to change each line contain string but change in only one line 
            return Context.Statuses.Where(s => s.StatusName != Status.state1).ToList();

        }

        public List<Status> GetAllForMan()
        {
            return Context.Statuses.Where(s => s.StatusName == Status.state1 || s.StatusName== Status.state2).ToList();
        }
    }
}
