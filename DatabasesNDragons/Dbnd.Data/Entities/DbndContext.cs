using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dbnd.Data.Entities
{
    public class DbndContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(b => b.ClientId)
                .IsRequired();
        }

        public DbndContext(DbContextOptions<DbndContext> options)
            : base(options)
        {
        }

    }
}
