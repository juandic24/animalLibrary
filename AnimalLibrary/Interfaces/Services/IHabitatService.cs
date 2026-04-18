using AnimalLibrary.DTOs;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IHabitatService
    {
        Task<IEnumerable<HabitatDetailsDTO>> GetAllAsync(CancellationToken ct = default);
        Task <HabitatDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default);
        Task <int> AddAsync(CreateHabitatDTO createdHabitatDto, CancellationToken ct = default);
        Task <bool> UpdateAsync (int id, UpdateHabitatDTO updatedHabitatDto, CancellationToken ct = default);
        Task <bool> DeleteAsync (int id, CancellationToken ct = default);

    }
}
