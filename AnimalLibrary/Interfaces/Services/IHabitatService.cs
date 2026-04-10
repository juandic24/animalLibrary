using AnimalLibrary.DTOs;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IHabitatService
    {
        Task<IEnumerable<HabitatDetailsDTO>> GetAllAsync();
        Task <HabitatDetailsDTO?> GetByIdAsync(int id);
        Task <int> AddAsync(CreateHabitatDTO createdHabitatDto);
        Task <bool> UpdateAsync (int id, UpdateHabitatDTO updatedHabitatDto);
        Task <bool> DeleteAsync (int id);

    }
}
