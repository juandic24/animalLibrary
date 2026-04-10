using AnimalLibrary.Models;

namespace AnimalLibrary.Interfaces.Repositories
{
    public interface IGroupRepository
    {
        Task <IEnumerable<Group>> GetAllAsync();
        Task <Group?> GetByIdAsync(int id);
        Task AddAsync (Group group);
        Task UpdateAsync (Group group);
        Task DeleteAsync (int id);
    }
}
