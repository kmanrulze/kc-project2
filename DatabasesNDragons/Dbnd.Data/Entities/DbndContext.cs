using Microsoft.EntityFrameworkCore;

namespace Dbnd.Data.Entities
{
    public class DbndContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<DungeonMaster> DungeonMaster { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<CharacterGameXRef> CharacterGameXRef { get; set; }
        public DbSet<Overview> Overview { get; set; }
        public DbSet<OverviewType> OverviewType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(p => p.ClientID)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(p => p.UserName)
                .HasMaxLength(75)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .HasAlternateKey(p => p.UserName); // Unique
            modelBuilder.Entity<Client>()
                .Property(p => p.Email)
                .HasMaxLength(175)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .HasAlternateKey(p => p.Email); // Unique

            modelBuilder.Entity<DungeonMaster>()
                .Property(p => p.DungeonMasterID)
                .IsRequired();
            modelBuilder.Entity<DungeonMaster>()
                .Property(p => p.ClientID)
                .IsRequired();

            modelBuilder.Entity<Character>()
                .Property(p => p.CharacterID)
                .IsRequired();
            modelBuilder.Entity<Character>()
                .Property(p => p.FirstName)
                .HasMaxLength(75)
                .IsRequired();
            modelBuilder.Entity<Character>()
                .Property(p => p.LastName)
                .HasMaxLength(75)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(p => p.GameID)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(p => p.DungeonMasterID)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(p => p.GameName)
                .HasMaxLength(225)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .HasAlternateKey(p => p.GameName); // Unique

            modelBuilder.Entity<Overview>()
                .Property(p => p.OverviewID)
                .IsRequired();
            modelBuilder.Entity<Overview>()
                .Property(p => p.TypeID)
                .IsRequired();
            modelBuilder.Entity<Overview>()
                .Property(p => p.GameID)
                .IsRequired();

            modelBuilder.Entity<OverviewType>()
                .Property(p => p.TypeID)
                .IsRequired();

            // Setup Composite Key for this CharGameXRef
            modelBuilder.Entity<CharacterGameXRef>()
                .HasKey(k => new { k.GameID, k.CharacterID });
        }

        public DbndContext(DbContextOptions<DbndContext> options)
            : base(options)
        {
        }

    }
}
