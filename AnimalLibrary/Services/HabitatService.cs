using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Models;

namespace AnimalLibrary.Services
{
    public class HabitatService : IHabitatService
    {
        private readonly IHabitatRepository _habitatRepository;
        public HabitatService(IHabitatRepository habitatRepository)
        {
            _habitatRepository = habitatRepository;
        }

        public async Task<IEnumerable<HabitatDetailsDTO>> GetAllAsync()
        {
            var habitats = await _habitatRepository.GetAllAsync();
            return habitats.Select(h => new HabitatDetailsDTO
            (
                h.Id,
                h.Name
            ));
        }

        public async Task<HabitatDetailsDTO?> GetByIdAsync(int id)
        {
            var habitat = await _habitatRepository.GetByIdAsync(id);
            if (habitat is null) return null;
            return new HabitatDetailsDTO
            (
                habitat.Id,
                habitat.Name
            );
        }

        public async Task<int> AddAsync (CreateHabitatDTO createdHabitatDto)
        {
            Habitat habitat = new Habitat
            {
                Name = createdHabitatDto.Name
            };
            await _habitatRepository.AddAsync(habitat);
            return habitat.Id;
        }

        public async Task<bool> UpdateAsync (int id, UpdateHabitatDTO updatedHabitatDto)
        {
            var habitat = await _habitatRepository.GetByIdAsync(id);
            if (habitat is null) return false;
            habitat.Name = updatedHabitatDto.Name;
            await _habitatRepository.UpdateAsync(habitat);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var habitat = await _habitatRepository.GetByIdAsync(id);
            if (habitat is null) return false;
            await _habitatRepository.DeleteAsync(id);
            return true;
        }
    }
}
