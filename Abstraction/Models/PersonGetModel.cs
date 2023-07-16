namespace Abstraction.Models;

public class PersonGetModel
{
    public int Id { get; set; }

    public string LocationId { get; set; }

    public string TrackCode { get; set; }

    public int Type { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string WebSite { get; set; }

    // TODO needed to be maped where person is returned
    public AccredetationModel AccredetationModel { get; set;}

    // TODO needed to be maped where person is returned
    public AddressModel AddressModel { get; set;}
}
