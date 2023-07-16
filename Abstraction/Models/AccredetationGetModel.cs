using Abstraction.Entities.Enums;

namespace Abstraction.Models;

public class AccredetationGetModel
{
    public int Id { get; set; }

    public Status Status { get; set; }

    public DateOnly Expires { get; set; }
}
