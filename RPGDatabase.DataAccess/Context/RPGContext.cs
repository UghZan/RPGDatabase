using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RPGDatabase.DataAccess.Entities;

namespace RPGDatabase.DataAccess.Context
{
    public class RPGContext : DbContext
    {
        public virtual DbSet<DAItem> Item { get; set; }
        public virtual DbSet<DAPlayer> Player{get; set;}

        public RPGContext()
        {
            Database.EnsureCreated();
        }

        public RPGContext(DbContextOptions<RPGContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=rpgdatabase;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DAItem>(entity =>
            {
                entity.Property(e => e.ID).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Rarity).IsRequired();

                entity.HasOne(d => d.Player)
                      .WithMany(p => p.Items)
                      .HasForeignKey(d => d.PlayerId)
                      .HasConstraintName("FK_Item_Player");
            });

            modelBuilder.Entity<DAPlayer>(entity =>
            {
                entity.Property(e => e.ID).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

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
