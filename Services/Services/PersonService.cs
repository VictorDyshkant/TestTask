﻿using Abstraction.Entities;
using Abstraction.Exceptions;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;

namespace Services.Services;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private Func<IUnitOfWork> _unitOfWorkFactory { get; }

    public PersonService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<PersonGetModel> GetPersonAsync(int id)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new NotFoundException($"Person with id = {id} was not found.");
            }
            return Map(person);
        }
    }

    public async Task<PersonGetModel> CreatePersonAsync(PersonModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = _mapper.Map<Person>(model);
            unitOfWork.PersonRepository.Insert(person);
            await unitOfWork.CommitAsync();

            return _mapper.Map<PersonGetModel>(person);
        }
    }

    public async Task DeletePersonAsync(int id)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new NotFoundException($"Person with id = {id} was not found.");
            }

            unitOfWork.PersonRepository.Delete(id);
            await unitOfWork.CommitAsync();
        }
    }

    public async Task<List<PersonGetModel>> GetAllAsync()
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var persons = await unitOfWork.PersonRepository.GetAllAsync();
            return _mapper.Map<List<PersonGetModel>>(persons);
        }
    }

    public async Task<PersonGetModel> UpdatePersonAsync(int id, PersonModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new NotFoundException($"Person with id = {id} was not found.");
            }

            person.LocationId = model.LocationId;
            person.TrackCode = model.TrackCode;
            person.Type = model.Type;

            person.Name = model.Name;
            person.Email = model.Email;
            person.Phone = model.Phone;
            person.WebSite = model.WebSite;

            unitOfWork.PersonRepository.Update(person);
            await unitOfWork.CommitAsync();

            return _mapper.Map<PersonGetModel>(person);
        }
    }

    private PersonGetModel Map(Person person)
    {
        var result = _mapper.Map<PersonGetModel>(person);
        if (person.Accreditation is not null)
            result.AccredetationModel = _mapper.Map<AccredetationGetModel>(person.Accreditation);
        if (person.Address is not null)
            result.AddressModel = _mapper.Map<AddressGetModel>(person.Address);
        return result;
    }
}
