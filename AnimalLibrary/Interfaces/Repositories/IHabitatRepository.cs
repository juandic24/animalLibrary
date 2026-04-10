using AnimalLibrary.Models;

namespace AnimalLibrary.Interfaces.Repositories
{
    public interface IHabitatRepository
    {
        Task<IEnumerable<Habitat>> GetAllAsync();
        Task<Habitat?> GetByIdAsync(int id);
        Task AddAsync (Habitat habitat);
        Task UpdateAsync (Habitat habitat);
        Task DeleteAsync (int id);

    }
}
