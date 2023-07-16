using Abstraction.Models;

namespace Abstraction.Services;

public interface IPersonService
{
    Task<PersonGetModel> CreatePersonAsync(PersonModel model);

    Task<PersonGetModel> UpdatePersonAsync(int id, PersonModel model);

    Task<PersonGetModel> GetPersonAsync(int id);

    Task DeletePersonAsync(int id);

    Task<List<PersonGetModel>> GetAllAsync();
}
