using AnimalLibrary.Interfaces.Models;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Data
{
    public class AnimalLibraryContext(DbContextOptions<AnimalLibraryContext> options) : DbContext(options)
    {
        public DbSet<Animal> Animals { get; set;  }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Habitat> Habitats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship animals - groups 
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Group)
                .WithMany(g => g.Animals)
                .HasForeignKey(a => a.GroupId);


            //Relationship animals - habitats
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Habitat)
                .WithMany(h => h.Animals)
                .HasForeignKey(a => a.HabitatId);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo(); 

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();

            return base.SaveChanges();
        }

        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }
            }
        }




    }
}
