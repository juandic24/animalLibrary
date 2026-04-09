using System.Text.RegularExpressions;

namespace AnimalLibrary.Models
{
    public class Animal
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ScientificName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int GroupId { get; set; }
        public int HabitatId { get; set; }

        public Group? Group { get; set; }
        public Habitat? Habitat { get; set; }
  

    }
}
