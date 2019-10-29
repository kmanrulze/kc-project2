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
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<Character>();
            modelBuilder.Entity<DungeonMaster>();
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<CharacterGameXRef>();
        }

        public DbndContext(DbContextOptions<DbndContext> options)
            : base(options)
        {
        }

    }
}
