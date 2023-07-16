using Abstraction.Entities;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;

namespace Services.Services;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private IUnitOfWorkFactory _unitOfWorkFactory { get; }

    public PersonService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<PersonGetModel> GetPersonAsync(int id)
    {
        using(var unitOfWork = _unitOfWorkFactory.Create())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            return _mapper.Map<PersonGetModel>(person);
        }
    }

    public async Task<PersonGetModel> CreatePersonAsync(PersonModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory.Create())
        {
            var person = _mapper.Map<Person>(model);

            unitOfWork.PersonRepository.Insert(person);
            await unitOfWork.CommitAsync();

            return _mapper.Map<PersonGetModel>(person);
        }
    }

    public async Task DeletePersonAsync(int id)
    {
        using (var unitOfWork = _unitOfWorkFactory.Create())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new Exception($"Person with id = {id} was not found.");
            }

            unitOfWork.PersonRepository.Delete(id);
            await unitOfWork.CommitAsync();
        }
    }

    public async Task<List<PersonGetModel>> GetAllAsync()
    {
        using (var unitOfWork = _unitOfWorkFactory.Create())
        {
            var persons = await unitOfWork.PersonRepository.GetAllAsync();
            return _mapper.Map<List<PersonGetModel>>(persons);
        }
    }

    public async Task<PersonGetModel> UpdatePersonAsync(int id, PersonModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory.Create())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new Exception($"Person with id = {id} was not found.");
            }

            person.Name = model.Name;
            person.Email = model.Email;
            person.Phone = model.Phone;

            unitOfWork.PersonRepository.Update(person);
            await unitOfWork.CommitAsync();

            return _mapper.Map<PersonGetModel>(person);
        }
    }
}
