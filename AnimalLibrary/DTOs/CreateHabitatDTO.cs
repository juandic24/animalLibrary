using System.ComponentModel.DataAnnotations;

namespace AnimalLibrary.DTOs
{
    public record CreateHabitatDTO
    (
        [Required] string Name
    );
}
