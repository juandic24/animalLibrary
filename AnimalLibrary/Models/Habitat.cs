
using AnimalLibrary.Interfaces.Models;

namespace AnimalLibrary.Models
{
    public class Habitat :  IEntity, INamedEntity, ISoftDeletable, IAuditable
    {
        public int Id { get; set; } 

        public required string Name { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public ICollection<Animal>? Animals { get; set; } = [];
    }
}
