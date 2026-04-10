using System.ComponentModel.DataAnnotations;

namespace AnimalLibrary.DTOs
{
    public record UpdateGroupDTO
    (
        [Required] string Name
    );
}
