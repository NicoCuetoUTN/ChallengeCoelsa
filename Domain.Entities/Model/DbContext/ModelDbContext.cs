using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Model
{
    public class ModelDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {
        }
        
    }
}
