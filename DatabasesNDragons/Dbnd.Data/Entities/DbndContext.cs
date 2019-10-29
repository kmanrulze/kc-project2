using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dbnd.Data.Entities
{
    public class DbndContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<DungeonMaster> DungeonMaster { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<CharacterGameXRef > CharacterGameXRef { get; set; }
        
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

            modelBuilder.Entity<Character>()
                .Property(p => p.CharacterId)
                .IsRequired();
            modelBuilder.Entity<Character>()
                .Property(p => p.CharacterFirstName)
                .HasMaxLength(75)
                .IsRequired();
            modelBuilder.Entity<Character>()
                .Property(p => p.CharacterLastName)
                .HasMaxLength(75)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(p => p.GameId)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(p => p.DungeonMasterId)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(p => p.GameName)
                .HasMaxLength(225)
                .IsRequired();

            // Setup Composite Key for this table
            modelBuilder.Entity<CharacterGameXRef>()
                .HasKey(k => new { k.GameId, k.ClientId });
        }

        public DbndContext(DbContextOptions<DbndContext> options)
            : base(options)
        {
        }

    }
}
