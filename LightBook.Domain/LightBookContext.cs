using Microsoft.EntityFrameworkCore;
using LightBook.Domain.Entities;

namespace LightBook.Domain
{
    public class LightBookContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BookApp> Books { get; set; }
        public LightBookContext(DbContextOptions options) :base(options) 
        {
        }
    }
}
