using Abstraction.Entities;
using Abstraction.Exceptions;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;

namespace Services.Services;

public class AddressService : IAddressService
{
    private Func<IUnitOfWork> _unitOfWorkFactory { get; }
    private readonly IMapper _mapper;

    public AddressService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }

    public async Task<AddressGetModel> CreateAddressAsync(int personId, AddressModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
            if (person == null)
            {
                throw new Exception($"Person with this id = {personId} has an address!");
            }

            person.Address = _mapper.Map<Address>(model);

            unitOfWork.PersonRepository.Update(person);
            await unitOfWork.CommitAsync();

            return _mapper.Map<AddressGetModel>(person.Address);
        }
    }

    public async Task<AddressGetModel> GetAddressAsync(int id)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var address = await unitOfWork.AddressRepository.GetByIdAsync(id);
            return _mapper.Map<AddressGetModel>(address);
        }
    }

    public async Task<AddressGetModel> UpdateAddressAsync(int personId, AddressModel model)
    {
        using (var unitOfWork = _unitOfWorkFactory())
        {
            var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
            if (person == null)
            {
                throw new NotFoundException($"Person with id = {personId} was not found!");
            }

            var address = person.Address;
            if(address is null)
            {
                throw new NotFoundException("Address was not found.");
            }

            address.Street = model.Street;
            address.City = model.City;
            address.Country = model.Country;
            address.State = model.State;
            address.ZipPostalCode = model.ZipPostalCode;

            unitOfWork.AddressRepository.Update(address);
            await unitOfWork.CommitAsync();

            return _mapper.Map<AddressGetModel>(address);
        }
    }
}
