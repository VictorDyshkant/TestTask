using Abstraction.Entities;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AddressService : IAddressService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }
        public async Task<AddressGetModel> CreateAddressAsync(int personId, AddressModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var address = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                if (address != null)
                {
                    throw new Exception($"Person with this id = {personId} has an address!");
                }
                unitOfWork.PersonRepository.Update(address);
                await unitOfWork.CommitAsync();

                return _mapper.Map<AddressGetModel>(address);
            }
        }

        public async Task<AddressGetModel> GetAddressAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var address = await unitOfWork.PersonRepository.GetByIdAsync(id);
                return _mapper.Map<AddressGetModel>(address);
            }
        }

        public async Task<AddressGetModel> UpdateAddressAsync(int personId, AddressModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {

                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                var address = person.Address;
                if (address == null)
                {
                    throw new Exception($"Person with id = {personId} was not found!");
                }

                address.Street = model.Street;
                address.City = model.City;  
                address.Country = model.Country;
                address.State = model.State;
                address.ZipPostalCode = model.ZipPostalCode;
               
                unitOfWork.PersonRepository.Update(person);
                await unitOfWork.CommitAsync();

                return _mapper.Map<AddressGetModel>(address);
            }
        }
    }
}
