using Ticketing_System.Data;
using Ticketing_System.Models;

namespace Ticketing_System.Interfaces.Implemintation
{
    public class CategoryImp : ICategory
    {
        private readonly ApplicationDbContext Context;
        public CategoryImp(ApplicationDbContext context)
        {
            Context = context;
        }


        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

    }
}
