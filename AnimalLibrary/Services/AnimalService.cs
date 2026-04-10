using AnimalLibrary.Data;
using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using AnimalLibrary.Models;      
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AnimalLibrary.Repositories;

namespace AnimalLibrary.Services
{
    public class AnimalService: IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IEnumerable<AnimalDetailsDTO>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync(); //get all animals from the repository
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

        public async Task<AnimalDetailsDTO?> GetByIdAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
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

        public async Task<int> AddAsync(CreateAnimalDTO createdAnimalDto)
        {
            Animal animal = new() {
                Name = createdAnimalDto.Name,
                ScientificName = createdAnimalDto.ScientificName,
                Description = createdAnimalDto.Description,
                ImageUrl = createdAnimalDto.ImageUrl,
                GroupId = createdAnimalDto.GroupId,
                HabitatId = createdAnimalDto.HabitatId};
            await _animalRepository.AddAsync(animal);
            return animal.Id;
        }
            
        

        public async Task<bool> UpdateAsync(int id, UpdateAnimalDTO updatedAnimalDto)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal is null) return false; //no lo encontró

            animal.Name = updatedAnimalDto.Name;
            animal.ScientificName = updatedAnimalDto.ScientificName;
            animal.Description = updatedAnimalDto.Description;
            animal.ImageUrl = updatedAnimalDto.ImageUrl;
            animal.GroupId = updatedAnimalDto.GroupId;
            animal.HabitatId = updatedAnimalDto.HabitatId;

            await _animalRepository.UpdateAsync(animal);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {   
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal is null) return false;
            await _animalRepository.DeleteAsync(id);
            return true;

        }

        public async Task<IEnumerable<AnimalDetailsDTO>> GetByGroupIdAsync(int groupId)
        {
            var animals = await _animalRepository.GetByGroupIdAsync(groupId);
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

        public async Task<IEnumerable<AnimalDetailsDTO>> GetByHabitatIdAsync(int habitatId)
        {
            var animals = await _animalRepository.GetByHabitatIdAsync(habitatId);
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
