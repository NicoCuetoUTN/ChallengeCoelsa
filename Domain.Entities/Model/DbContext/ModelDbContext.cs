using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
