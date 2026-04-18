using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Repositories
{
    public class AnimalRepository : EfRepository<Animal>, IAnimalRepository

    {

        public AnimalRepository(AnimalLibraryContext context) : base(context) {}

        public new async Task<IEnumerable<Animal>> GetAllAsync(CancellationToken ct = default)
        {
            return await _set.AsNoTracking()
                             .Where(e => !e.IsDeleted)
                             .Include(e => e.Habitat)
                             .Include(e => e.Group)
                             .ToListAsync(ct);
        }

        public new async Task<Animal?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _set.AsNoTracking()
                             .Include(e => e.Habitat)
                             .Include(e => e.Group)
                             .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted, ct);
        }


        public async Task<IEnumerable<Animal>> GetByGroupIdAsync(int groupId, CancellationToken ct = default)
        {
            return await _set
                .Where(a => a.GroupId == groupId)
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking()
                .ToListAsync(ct);
        }
        public async Task<IEnumerable<Animal>> GetByHabitatIdAsync(int habitatId, CancellationToken ct = default)
        {
            return await _set
                .Where(a => a.HabitatId == habitatId)
                .Include(a => a.Group)
                .Include(a => a.Habitat)
                .AsNoTracking()
                .ToListAsync(ct);
        }


    }
}
