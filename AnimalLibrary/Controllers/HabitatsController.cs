using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/habitats
    public class HabitatsController : ControllerBase
    {

        private readonly IHabitatService _habitatService;
        private readonly IAnimalService _animalService;
        public HabitatsController(IHabitatService habitatService, IAnimalService animalService)
        {
            _habitatService = habitatService;
            _animalService = animalService;
        }

        [HttpGet] // get api/habitats
        public async Task<IActionResult> GetAll()
        {
            var habitats = await _habitatService.GetAllAsync();
            return Ok(habitats);
        }

        [HttpGet("{id}")] //get api/habitats/1

        public async Task<IActionResult> GetById(int id)
        {
            var habitat = await _habitatService.GetByIdAsync(id);
            if (habitat is null) return NotFound();
            return Ok(habitat);
        }

        [HttpPost] // POST api/habitats

        public async Task<IActionResult> Create(CreateHabitatDTO createdHabitatDto)
        {
            var newId = await _habitatService.AddAsync(createdHabitatDto);
            var habitat = await _habitatService.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, habitat);
        }

        [HttpPut("{id}")] //PUT api/habitats/1

        public async Task<IActionResult> Update(int id, UpdateHabitatDTO updatedHabitatDto)
        {
            var updated = await _habitatService.UpdateAsync(id, updatedHabitatDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE api/habitas/1

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _habitatService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/animals")] // GET api/habitats/1/animals
        public async Task<IActionResult> GetAnimalsByHabitatId(int id)
        {
            var animals = await _animalService.GetByHabitatIdAsync(id);
            return Ok(animals);
        }

    }
}
