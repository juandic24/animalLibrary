using AnimalLibrary.Interfaces.Models;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;



namespace AnimalLibrary.Data
{
    public static class DataExtensions 
    {

        public static void MigrateAndSeedDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AnimalLibraryContext>();
            dbContext.Database.Migrate();
            SeedDb(dbContext);

        }
        public static void AddAnimalLibraryDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AnimalLibraryContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); 

            });

        }

        public static void SeedDb(AnimalLibraryContext dbContext) 
        {

            SeedEntities(dbContext, new List<Group>
            {
                new Group { Name = "Invertebrates" },
                new Group { Name = "Fish" },
                new Group { Name = "Amphibians" },
                new Group { Name = "Reptiles" },
                new Group { Name = "Birds" },
                new Group { Name = "Mammals" }
            }); //groups
            SeedEntities(dbContext, new List<Habitat>
            {
                new Habitat { Name = "Tundra" },
                new Habitat { Name = "Woods" },
                new Habitat { Name = "Ocean" },
                new Habitat { Name = "Lake/River" },
                new Habitat { Name = "Desert" }
            }); //habitats
            dbContext.SaveChanges();

        }



        public static void SeedEntities<T> (AnimalLibraryContext dbContext, List<T> items) where T: class, INamedEntity
        {

            HashSet<String> existingNames = dbContext.Set<T>().Select(x => x.Name).ToHashSet(); // get existing group names from the database
            foreach (var item in items)
            {
                if (!existingNames.Contains(item.Name)) // if the group doesn't exist in the database
                {
                    dbContext.Set<T>().Add(item);
                }

            }
        }
    }
}
