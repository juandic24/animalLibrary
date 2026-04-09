using System.ComponentModel.DataAnnotations;

namespace AnimalLibrary.DTOs
{
    public record CreateAnimalDTO(
        [Required] string Name,
        [Required] string ScientificName,
        string Description, 
        string ImageUrl,
        [Required] int GroupId,
        [Required] int HabitatId);
}
