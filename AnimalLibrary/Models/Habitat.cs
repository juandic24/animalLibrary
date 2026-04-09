namespace AnimalLibrary.Models
{
    public class Habitat : INamedEntity 
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public ICollection<Animal>? Animals { get; set; } = [];
    }
}
