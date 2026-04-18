using AnimalLibrary.DTOs;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDetailsDTO>> GetAllAsync(CancellationToken ct = default);
        Task<AnimalDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> AddAsync(CreateAnimalDTO createdAnimalDto, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, UpdateAnimalDTO updatedAnimalDto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<AnimalDetailsDTO>> GetByGroupIdAsync(int groupId, CancellationToken ct = default);
        Task<IEnumerable<AnimalDetailsDTO>> GetByHabitatIdAsync(int habitatId, CancellationToken ct = default);

    }
}
