using Abstraction.Entities;
using Abstraction.Models;
using AutoMapper;
namespace Services.Mapper;

public class EntityToGetModelMapperProfile : Profile
{
    public EntityToGetModelMapperProfile()
    {
        CreateMap<Person, PersonGetModel>();
        CreateMap<Address, AddressGetModel>();
        CreateMap<Accreditation, AccredetationGetModel>();
    }
}
