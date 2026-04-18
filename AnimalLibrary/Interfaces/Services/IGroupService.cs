using AnimalLibrary.DTOs;
using AnimalLibrary.Models;

namespace AnimalLibrary.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDetailsDTO>> GetAllAsync(CancellationToken ct = default);
        Task<GroupDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<int> AddAsync(CreateGroupDTO createdGroupDto, CancellationToken ct = default);

        Task<bool> UpdateAsync(int id, UpdateGroupDTO updatedGroupDto, CancellationToken ct = default);

        Task<bool> DeleteAsync(int id, CancellationToken ct = default);

    }
}
