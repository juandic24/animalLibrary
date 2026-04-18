using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Models;

namespace AnimalLibrary.Services
{
    public class HabitatService : IHabitatService
    {
        private readonly IRepository<Habitat> _repository;
        public HabitatService(IRepository<Habitat> habitatRepository)
        {
            _repository = habitatRepository;
        }

        public async Task<IEnumerable<HabitatDetailsDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var habitats = await _repository.GetAllAsync(ct);
            return habitats.Select(h => new HabitatDetailsDTO
            (
                h.Id,
                h.Name
            ));
        }

        public async Task<HabitatDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var habitat = await _repository.GetByIdAsync(id, ct);
            if (habitat is null) return null;
            return new HabitatDetailsDTO
            (
                habitat.Id,
                habitat.Name
            );
        }

        public async Task<int> AddAsync (CreateHabitatDTO createdHabitatDto, CancellationToken ct = default)
        {
            Habitat habitat = new Habitat
            {
                Name = createdHabitatDto.Name
            };
            await _repository.AddAsync(habitat, ct);
            return habitat.Id;
        }

        public async Task<bool> UpdateAsync (int id, UpdateHabitatDTO updatedHabitatDto, CancellationToken ct = default)
        {
            var habitat = await _repository.GetByIdAsync(id, ct);
            if (habitat is null) return false;
            habitat.Name = updatedHabitatDto.Name;
            await _repository.UpdateAsync(habitat, ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var habitat = await _repository.GetByIdAsync(id, ct);
            if (habitat is null) return false;
            await _repository.DeleteAsync(id, ct);
            return true;
        }
    }
}
