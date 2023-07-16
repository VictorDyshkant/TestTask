using Abstraction.Models;

namespace Abstraction.Services;

// TODO needed to be realized and registrated in DI, Accredetation Controller should be created
public interface IAccredetationService
{
    Task AssigneAccredetation(int personId, AccredetationModel model);

    Task UnAssigneAccredetation(int personId, AccredetationModel model);
}
