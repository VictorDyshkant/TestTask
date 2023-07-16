using Abstraction.Models;

namespace Abstraction.Services;


// TODO needed to be realized and registrated in DI, Address Controller should be created
public interface IAddressService
{
    Task<AddressGetModel> CreateAddressAsync(int personId, AddressModel model);

<<<<<<< HEAD
    Task<AddressGetModel> UpdateAddressAsync(int personId, AddressModel model);

    Task<AddressGetModel> GetAddressAsync(int id);
=======
    Task UpdateAddressAsync(int personId, AddressModel model);
>>>>>>> 0f24a34e1386e9c0b05d6bde2970e7275c9db246
}
