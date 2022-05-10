using Microsoft.EntityFrameworkCore;
using Shoping.Domain.Entities.Product;
using Shoping.Persistance.Context;
using Shoping.Persistance.Services.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Persistance.Services.Repositories.Repository
{
    public class Category : ICategory
    {
        private readonly DataBaseContext _dataBaseContext;
        public Category(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public void Delit(Domain.Entities.Product.Category category)
        {
            _dataBaseContext.Entry(category).State = EntityState.Deleted;
        }

        

        public long GetId(Domain.Entities.Product.Category category)
        {
           var c =_dataBaseContext.Categores.Find(category);
            return c.Category_Id;
        }

        

        public Domain.Entities.Product.Category Get_Parent(long? ParentId)
        {
           return _dataBaseContext.Categores.Where(p => p.ParentCategoryId == ParentId).FirstOrDefault();
        }

        public bool InsertCategory(Domain.Entities.Product.Category category)
        {
            _dataBaseContext.Categores.Add(category);
            return false;
        }

        public void Save()
        {
            _dataBaseContext.SaveChanges();
        }

        public void UpdateCategory(Domain.Entities.Product.Category category)
        {
            _dataBaseContext.Entry(category).State = EntityState.Modified;
        }
    }
}
