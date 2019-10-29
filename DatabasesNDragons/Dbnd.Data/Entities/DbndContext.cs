using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dbnd.Data.Entities
{
    public class DbndContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(p => p.ClientId)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(p => p.Username)
                .HasMaxLength(75)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(p => p.PasswordHash)
                .HasMaxLength(25)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(p => p.Email)
                .HasMaxLength(75)
                .IsRequired();

            modelBuilder.Entity<DungeonMaster>()
                .Property(p => p.DungeonMasterId)
                .IsRequired();
            modelBuilder.Entity<DungeonMaster>()
                .Property(p => p.ClientId)
                .IsRequired();

            modelBuilder.Entity<Character>();
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<CharacterGameXRef>();
        }

        public DbndContext(DbContextOptions<DbndContext> options)
            : base(options)
        {
        }

    }
}
