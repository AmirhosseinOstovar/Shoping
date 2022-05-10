using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Domain.Entities.Product
{
    public class Category
    {
        [Key ]
        public int Category_Id { get; set; }
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }

    }
}
