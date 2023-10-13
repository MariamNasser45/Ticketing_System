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


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GellAll()
        {
            return Context.Categories.ToList();
        }

        public Category Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
