using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Repositories
{
    public class AnimalRepository : IAnimalRepository

    {
        // The DbContext is injected 
        private readonly AnimalLibraryContext _context;

        public AnimalRepository(AnimalLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking() // not need to track only reead
                .ToListAsync();
        }

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _context.Animals
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking() // not need to track
                .FirstOrDefaultAsync(a => a.Id == id);
            // FirstOrDefaultAsync returns null if nothing matches
        }

        public async Task AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            // SaveChangesAsync commits the transaction to the database
        }

        public async Task UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var animal = await GetByIdAsync(id);
            if (animal is not null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Animal>> GetByGroupIdAsync(int groupId)
        {
            return await _context.Animals
                .Where(a => a.GroupId == groupId)
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IEnumerable<Animal>> GetByHabitatIdAsync(int habitatId)
        {
            return await _context.Animals
                .Where(a => a.HabitatId == habitatId)
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking()
                .ToListAsync();
        }


    }
}
