using System.ComponentModel.DataAnnotations;

namespace AnimalLibrary.DTOs
{
    public record CreateGroupDTO
    (
        [Required] string Name
    );
}
