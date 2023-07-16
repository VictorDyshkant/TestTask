using Abstraction.Entities;
using Abstraction.Models;
using AutoMapper;

namespace Services.Mapper;

public class EntityToDtoMapperProfile : Profile
{
    public EntityToDtoMapperProfile()
    {
        CreateMap<Person, PersonModel>();
    }
}
