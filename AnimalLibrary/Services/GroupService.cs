using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Models;
using AnimalLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimalLibrary.Services
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<int> AddAsync(CreateGroupDTO createdGroupDto)
        {
            Group group = new Group
            {
                Name = createdGroupDto.Name
            };
            await _groupRepository.AddAsync(group);
            return group.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group is null) return false;
            await _groupRepository.DeleteAsync(id);
            return true;

        }

        public async Task<IEnumerable<GroupDetailsDTO>> GetAllAsync()
        {
            var groups = await  _groupRepository.GetAllAsync();

            return groups.Select(g => new GroupDetailsDTO
            (
                g.Id,
                g.Name
            ));

        }

        public async Task<GroupDetailsDTO?> GetByIdAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group is null) return null;
            return new GroupDetailsDTO
            (
                group.Id,
                group.Name
            );
        }

        public async Task<bool> UpdateAsync(int id, UpdateGroupDTO updatedGroupDto)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group is null) return false;
            group.Name = updatedGroupDto.Name;
            await _groupRepository.UpdateAsync(group);
            return true;

        }
    }
}
