using AnimalLibrary.DTOs;
using AnimalLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalLibrary.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        //Methods   
        Task <IEnumerable<Animal>> GetAllAsync();
        Task<Animal?> GetByIdAsync (int id); //can be null
        Task AddAsync (Animal animal);
        Task UpdateAsync (Animal animal);
        Task DeleteAsync (int id);
        Task<IEnumerable<Animal>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<Animal>> GetByHabitatIdAsync (int habitatId);
    }
}
