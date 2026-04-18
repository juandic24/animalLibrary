
using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Models;      


namespace AnimalLibrary.Services
{
    public class AnimalService: IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IEnumerable<AnimalDetailsDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var animals = await _animalRepository.GetAllAsync(ct); //get all animals from the repository
            return animals.Select(a => new AnimalDetailsDTO
            (
                a.Id,
                a.Name,
                a.ScientificName,
                a.Description,
                a.ImageUrl,
                a.Group?.Name,
                a.Habitat?.Name
            ));
        }

        public async Task<AnimalDetailsDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var animal = await _animalRepository.GetByIdAsync(id, ct);
            if (animal is null) return null;
            return new AnimalDetailsDTO
            (
                animal.Id,
                animal.Name,
                animal.ScientificName,
                animal.Description,
                animal.ImageUrl,
                animal.Group?.Name,
                animal.Habitat?.Name
            );
        }

        public async Task<int> AddAsync(CreateAnimalDTO createdAnimalDto, CancellationToken ct)
        {
            Animal animal = new() {
                Name = createdAnimalDto.Name,
                ScientificName = createdAnimalDto.ScientificName,
                Description = createdAnimalDto.Description,
                ImageUrl = createdAnimalDto.ImageUrl,
                GroupId = createdAnimalDto.GroupId,
                HabitatId = createdAnimalDto.HabitatId};
            await _animalRepository.AddAsync(animal, ct);
            return animal.Id;
        }
            
        

        public async Task<bool> UpdateAsync(int id, UpdateAnimalDTO updatedAnimalDto, CancellationToken ct)
        {
            var animal = await _animalRepository.GetByIdAsync(id, ct);
            if (animal is null) return false; //no lo encontró

            animal.Name = updatedAnimalDto.Name;
            animal.ScientificName = updatedAnimalDto.ScientificName;
            animal.Description = updatedAnimalDto.Description;
            animal.ImageUrl = updatedAnimalDto.ImageUrl;
            animal.GroupId = updatedAnimalDto.GroupId;
            animal.HabitatId = updatedAnimalDto.HabitatId;

            await _animalRepository.UpdateAsync(animal, ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {   
            var animal = await _animalRepository.GetByIdAsync(id, ct);
            if (animal is null) return false;
            await _animalRepository.DeleteAsync(id, ct);
            return true;

        }

        public async Task<IEnumerable<AnimalDetailsDTO>> GetByGroupIdAsync(int groupId, CancellationToken ct)
        {
            var animals = await _animalRepository.GetByGroupIdAsync(groupId, ct);
            return animals.Select(a => new AnimalDetailsDTO
            (
                a.Id,
                a.Name,
                a.ScientificName,
                a.Description,
                a.ImageUrl,
                a.Group?.Name,
                a.Habitat?.Name
            ));
        }

        public async Task<IEnumerable<AnimalDetailsDTO>> GetByHabitatIdAsync(int habitatId, CancellationToken ct)
        {
            var animals = await _animalRepository.GetByHabitatIdAsync(habitatId, ct);
            return animals.Select(a => new AnimalDetailsDTO
            (
                a.Id,
                a.Name,
                a.ScientificName,
                a.Description,
                a.ImageUrl,
                a.Group?.Name,
                a.Habitat?.Name
            ));
        }


    }
}
