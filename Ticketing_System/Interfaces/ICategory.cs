using Ticketing_System.Models;

namespace Ticketing_System.Interfaces
{
    public interface ICategory
    {
        public List<Category> GellAll();

        public Category Update(Category category);

        public void Delete(int id);
    }
}
