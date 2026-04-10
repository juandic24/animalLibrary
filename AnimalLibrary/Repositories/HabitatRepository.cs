using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Repositories
{
    public class HabitatRepository : IHabitatRepository
    {

        private readonly AnimalLibraryContext _context;

        public HabitatRepository(AnimalLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Habitat>> GetAllAsync()
        {
            return await _context.Habitats.AsNoTracking().ToListAsync();

        }

        public async Task<Habitat?> GetByIdAsync(int id)
        {
            return await _context.Habitats.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
        }


        public async Task AddAsync(Habitat habitat)
        {
            _context.Habitats.Add(habitat);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Habitat habitat)
        {
            _context.Habitats.Update(habitat);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var habitat = await GetByIdAsync(id);
            if(habitat is not null)
            {
                _context.Habitats.Remove(habitat);
                await _context.SaveChangesAsync();
            }
        }

     
    }
}
