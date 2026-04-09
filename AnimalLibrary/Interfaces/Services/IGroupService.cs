using AnimalLibrary.DTOs;
using AnimalLibrary.Models;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDetailsDTO>> GetAllAsync();
        Task<GroupDetailsDTO?> GetByIdAsync(int id);

        Task<int> AddAsync(CreateGroupDTO createdGroupDto);

        Task<bool> UpdateAsync(int id, CreateGroupDTO updatedGroupDto);

        Task<bool> DeleteAsync(int id);

    }
}
