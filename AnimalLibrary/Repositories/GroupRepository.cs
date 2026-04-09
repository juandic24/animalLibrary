using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AnimalLibraryContext _context;

        public GroupRepository(AnimalLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.AsNoTracking().ToListAsync();
            
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _context.Groups.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
        }


        public async Task AddAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await GetByIdAsync(id);
            if(group is not null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            
        }
 
        
    }
}
