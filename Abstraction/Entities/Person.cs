namespace Abstraction.Entities;

public class Person : Entity<int>
{
    public string LocationId { get; set; }

    public Address? Address { get; set; }
    
    public string TrackCode { get; set; }
    
    public int Type { get; set; }
    
    public Accreditation? Accreditation { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string WebSite { get; set; }
}
