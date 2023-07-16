using Abstraction.Entities.Enums;

namespace Abstraction.Models;

public class AccredetationModel
{
    public Status Status { get; set; }

    public DateOnly Expires { get; set; }
}
