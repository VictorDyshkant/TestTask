namespace Abstraction.Entities;

public class Address : Entity<int>
{
    public string City { get; set; }

    public string Street { get; set; }
    
    public string State { get; set; }
    
    public string ZipPostalCode { get; set; }
    
    public string Country { get; set; }
    
    public virtual Person Person { get; set; } = null!;
}
