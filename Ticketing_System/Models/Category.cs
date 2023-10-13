using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(25)]
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
