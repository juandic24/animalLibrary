namespace AnimalLibrary.Models
{
    public class Group : INamedEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Animal>? Animals { get; set; } = [];

    }
}
