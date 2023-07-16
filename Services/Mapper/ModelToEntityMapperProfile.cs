using Abstraction.Entities;
using Abstraction.Models;
using AutoMapper;

namespace Services.Mapper;

// TODO provide correct mapping
public class ModelToEntityMapperProfile : Profile
{
    public ModelToEntityMapperProfile()
    {
        CreateMap<PersonModel, Person>();
    }
}
