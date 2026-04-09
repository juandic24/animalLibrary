using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/animals
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet] //get api/animals
        public async Task<IActionResult> GetAll()
        {
            var animals = await _animalService.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")] //get api/animals/1
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal is null) return NotFound();
            return Ok(animal);
        }

        [HttpPost] // POST api/animals
        public async Task<IActionResult> Create(CreateAnimalDTO createdAnimalDTO)
        {
            var newId = await _animalService.AddAsync(createdAnimalDTO);
            var animal = await _animalService.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, animal);
        }

        [HttpPut("{id}")] // PUT api/animals/1
        public async Task<IActionResult> Update(int id, CreateAnimalDTO updatedAnimalDTO)
        {
            var updated = await _animalService.UpdateAsync(id, updatedAnimalDTO);
            if(!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE api/animals/1
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _animalService.DeleteAsync(id);
            if(!deleted) return NotFound();
            return NoContent();

        }



    }
}
