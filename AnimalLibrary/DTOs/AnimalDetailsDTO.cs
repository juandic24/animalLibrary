namespace AnimalLibrary.DTOs
{
    public record AnimalDetailsDTO(
        int Id,
        string Name,
        string ScientificName,
        string? Description,
        string? ImageUrl,
        string? GroupName,
        string? HabitatName);
}
