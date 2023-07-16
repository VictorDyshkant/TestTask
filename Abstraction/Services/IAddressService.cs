using Abstraction.Models;
namespace Abstraction.Services;

public interface IAddressService
{
    Task<AddressGetModel> CreateAddressAsync(int personId, AddressModel model);

    Task<AddressGetModel> UpdateAddressAsync(int personId, AddressModel model);

    Task<AddressGetModel> GetAddressAsync(int id);
}
