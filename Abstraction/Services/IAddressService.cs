using Abstraction.Models;

namespace Abstraction.Services;


// TODO needed to be realized and registrated in DI, Address Controller should be created
public interface IAddressService
{
    Task CreateAddressAsync(int personId, AddressModel model);

    Task UpdateAddressAsync(int personId, AddressModel model);
}
