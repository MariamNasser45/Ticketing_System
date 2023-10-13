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


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Severity> GellAll()
        {
           return Context.Severities.ToList();

        }

        public Severity Update(Severity severity)
        {
            throw new NotImplementedException();
        }
    }
}
