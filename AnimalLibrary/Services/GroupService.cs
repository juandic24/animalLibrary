using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Models;


namespace AnimalLibrary.Services
{
    public class GroupService : IGroupService
    {

        private readonly IRepository<Group> _repository;

        public GroupService(IRepository<Group> groupRepository)
        {
            _repository = groupRepository;
        }

        public async Task<int> AddAsync(CreateGroupDTO createdGroupDto, CancellationToken ct = default)
        {
            Group group = new Group
            {
                Name = createdGroupDto.Name
            };
            await _repository.AddAsync(group, ct);
            return group.Id;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var group = await _repository.GetByIdAsync(id, ct);
            if (group is null) return false;
            await _repository.DeleteAsync(id, ct);
            return true;

        }

        public async Task<IEnumerable<GroupDetailsDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var groups = await  _repository.GetAllAsync(ct);

            return groups.Select(g => new GroupDetailsDTO
            (
                g.Id,
                g.Name
            ));

        }

        public async Task<GroupDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var group = await _repository.GetByIdAsync(id, ct);
            if (group is null) return null;
            return new GroupDetailsDTO
            (
                group.Id,
                group.Name
            );
        }

        public async Task<bool> UpdateAsync(int id, UpdateGroupDTO updatedGroupDto, CancellationToken ct = default)
        {
            var group = await _repository.GetByIdAsync(id, ct);
            if (group is null) return false;
            group.Name = updatedGroupDto.Name;
            await _repository.UpdateAsync(group, ct);
            return true;

        }
    }
}
