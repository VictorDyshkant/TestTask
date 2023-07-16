using Abstraction.Entities.Enums;

namespace Abstraction.Entities;

public class Accreditation : Entity<int>
{
    public Status Status { get; set; }

    public DateTime Expires { get; set; }

    public virtual Person Person { get; set; } = null!;
}
