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




    }
}
