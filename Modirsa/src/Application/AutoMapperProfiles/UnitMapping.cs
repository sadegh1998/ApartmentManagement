using Application.Feature.Command.Unit.CreateUnit;
using Application.Feature.Command.Unit.EditUnit;
using AutoMapper;
using Domain.UnitAgg;

namespace Application.AutoMapperProfiles
{
    public class UnitMapping : Profile
    {
        public UnitMapping()
        {
            CreateMap<Unit, CreateUnitCommand>().ReverseMap();
            CreateMap<Unit, EditUnitCommand>().ReverseMap();

        }
    }
}
