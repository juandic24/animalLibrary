using AnimalLibrary.Models;


namespace AnimalLibrary.Interfaces.Repositories
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetByGroupIdAsync(int groupId, CancellationToken ct = default);
        Task<IEnumerable<Animal>> GetByHabitatIdAsync (int habitatId, CancellationToken ct = default);
    }
}
