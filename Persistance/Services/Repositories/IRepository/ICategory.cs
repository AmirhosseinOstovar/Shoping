
using Shoping.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Persistance.Services.Repositories.IRepository
{
   public interface ICategory
    {
        public Category Get_Parent(long? ParentId);
        public void Save();
        public void Delit(Category category);
        public bool InsertCategory(Category category);
        public void UpdateCategory(Category category);
        public long GetId(Category category);
    }
}
