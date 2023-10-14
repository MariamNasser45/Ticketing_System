using Ticketing_System.Data;
using Ticketing_System.Models;

namespace Ticketing_System.Interfaces.Implemintation
{
    public class SeverityImp : ISeverity
    {
        private readonly ApplicationDbContext Context;
        public SeverityImp(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<Severity> GetAll()
        {
            return Context.Severities.ToList();


        }
    }
}
