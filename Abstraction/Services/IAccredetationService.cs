using Abstraction.Models;

namespace Abstraction.Services;

// TODO needed to be realized and registrated in DI, Accredetation Controller should be created
public interface IAccredetationService
{
    Task<AccredetationGetModel> AssigneAccredetation(int personId, AccredetationModel model);

    // TODO method should delete Accredetation, person.Accredetation == null
    Task UnAssigneAccredetation(int personId);
}
