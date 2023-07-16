using Abstraction.Models;
namespace Abstraction.Services;

public interface IAddressService
{
    Task CreateAddressAsync(int personId, AddressModel model);

    Task UpdateAddressAsync(int personId, AddressModel model);

    Task<AddressModel> GetAddressAsync(int id);
}
