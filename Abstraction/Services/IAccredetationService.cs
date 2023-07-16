using Abstraction.Models;

namespace Abstraction.Services;

public interface IAccredetationService
{
    Task AssigneAccredetation(int personId, AccredetationModel model);

    Task UpdateAccredetation(int personId, AccredetationModel model);

    Task UnAssigneAccredetation(int personId);
}
