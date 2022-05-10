using Microsoft.EntityFrameworkCore;
using Shoping.Domain.Entities.Product;
using Shoping.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Persistance.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options):base (options)
        {
                
        }
        public DbSet <User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet <UserInRole>  UserInRoles { get; set; }
        public DbSet<Category> Categores { get; set; }
    }
}
