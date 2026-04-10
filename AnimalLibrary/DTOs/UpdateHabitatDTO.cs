using System.ComponentModel.DataAnnotations;

namespace AnimalLibrary.DTOs
{
    public record UpdateHabitatDTO
    (
        [Required] string Name
    );
}
