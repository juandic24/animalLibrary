using AnimalLibrary.DTOs;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDetailsDTO>> GetAllAsync();
        Task<AnimalDetailsDTO?> GetByIdAsync(int id);
        Task<int> AddAsync(CreateAnimalDTO createdAnimalDto);
        Task<bool> UpdateAsync(int id, CreateAnimalDTO updatedAnimalDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AnimalDetailsDTO>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<AnimalDetailsDTO>> GetByHabitatIdAsync(int habitatId);

    }
}
