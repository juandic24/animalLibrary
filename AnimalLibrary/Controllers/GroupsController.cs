using AnimalLibrary.DTOs;
using AnimalLibrary.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalLibrary.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // /api/groups
    public class GroupsController : ControllerBase
    {

        private readonly IGroupService _groupService;
        private readonly IAnimalService _animalService;
        public GroupsController(IGroupService groupService, IAnimalService animalService)
        {
            _groupService = groupService;
            _animalService = animalService;
        }

        [HttpGet] // get api/groups
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")] //get api/groups/1

        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group is null) return NotFound();
            return Ok(group);
        }

        [HttpPost] // POST api/groups

        public async Task<IActionResult> Create(CreateGroupDTO createdGroupDTO, CancellationToken ct)
        {
            var newId = await _groupService.AddAsync(createdGroupDTO);
            var group = await _groupService.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, group);
        }

        [HttpPut("{id}")] //PUT api/groups/1

        public async Task<IActionResult> Update(int id, UpdateGroupDTO updatedGroupDTO, CancellationToken ct)
        {
            var updated = await _groupService.UpdateAsync(id, updatedGroupDTO);
            if(!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE api/groups/1

        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _groupService.DeleteAsync(id);
            if(!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/animals")] // GET api/groups/1/animals
        public async Task<IActionResult> GetAnimalsByGroupId(int id, CancellationToken ct)
        {
            var animals = await _animalService.GetByGroupIdAsync(id);
            return Ok(animals);
        }

    }
}
