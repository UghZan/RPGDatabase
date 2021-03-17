using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RPGDatabase.DataAccess.Entities;

namespace RPGDatabase.DataAccess.Context
{
    class RPGContext : DbContext
    {
        public DbSet<DAItem> Items;
        public DbSet<DAPlayer> Players;

        public RPGContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=rpgdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DAItem>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Rarity).IsRequired();

                entity.HasOne(d => d.Owner)
                      .WithMany(p => p.Items)
                      .HasForeignKey(d => d.OwnerID)
                      .HasConstraintName("FK_Item_Player");
            });

            modelBuilder.Entity<DAPlayer>(entity =>
            {
                entity.Property(e => e.PlayerId).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Level).IsRequired();
                entity.Property(e => e.Money).IsRequired();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}
