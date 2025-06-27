using Application.Feature.Command.Building.CreateBuilding;
using Application.Feature.Command.Building.EditBuilding;
using AutoMapper;
using Domain.BuildingAgg;

namespace Application.AutoMapperProfiles
{
    public class BuildingMapping : Profile
    {
        public BuildingMapping()
        {
            CreateMap<Building,CreateBuildingCommand>().ReverseMap();
            CreateMap<Building, EditBuildingCommand>().ReverseMap();

        }
    }
}
