namespace Abstraction.Entities;

public class Accreditation : Entity<int>
{
    public Status Status { get; set; }

    public DateOnly Expires { get; set; }

    public Person Person { get; set; } = null!;
}
