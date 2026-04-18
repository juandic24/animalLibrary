using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Models;
using AnimalLibrary.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity, ISoftDeletable, INamedEntity, IAuditable

    {

        protected readonly AnimalLibraryContext _db;
        protected DbSet<T> _set => _db.Set<T>();

        public EfRepository(AnimalLibraryContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _set.AsNoTracking()
                             .Where(e => !e.IsDeleted)
                             .ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _set.AsNoTracking()
                             .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted, ct);
        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            _set.Add(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct) //soft delete
        {
            var entity = await _set.FindAsync(id);
            if (entity is not null)
            {
                entity.IsDeleted = true;              
                await _db.SaveChangesAsync(ct);
            }
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            _set.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

    }
}
