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
        using(var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<Accreditation, AccredetationModel>();
            });

            IMapper mapper = config.CreateMapper();


            return _mapper.Map<PersonGetModel>(person);
        }
    }

    public async Task<PersonGetModel> CreatePersonAsync(PersonModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = _mapper.Map<Person>(model);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>(); 
                cfg.CreateMap<Accreditation, AccredetationModel>();
                cfg.CreateMap<Person, PersonGetModel>()
                    .ForMember(dest => dest.AddressModel, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.AccredetationModel, opt => opt.MapFrom(src => src.Accreditation));
            });

            var mapper = config.CreateMapper();

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
                throw new Exception($"Person with id = {id} was not found.");
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
}
