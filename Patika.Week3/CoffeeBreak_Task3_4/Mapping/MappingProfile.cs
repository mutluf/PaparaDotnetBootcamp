using AutoMapper;
using CoffeeBreak_Task3_4.Entities;
using CoffeeBreak_Task3_4.ViewModels;

namespace CoffeeBreak_Task3_4.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Coffee, CoffeeViewModel>();
    }
}
