using AutoMapper;
using Domain.ExpenseUnitAgg;

namespace Application.AutoMapperProfiles
{
    public class ExpenseUnitProfile : Profile
    {
        public ExpenseUnitProfile()
        {
            CreateMap<ExpenseUnits, Application.Feature.Query.ExpenseUnit.GetAllExpenseUnits.ExpenseUnitViewModel>()
                .ForMember(dest => dest.ExpenseDescription, opt => opt.MapFrom(src => src.Expenses != null ? src.Expenses.Description : string.Empty))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty));

            CreateMap<ExpenseUnits, Application.Feature.Query.ExpenseUnit.GetExpenseUnitById.ExpenseUnitViewModel>()
                .ForMember(dest => dest.ExpenseDescription, opt => opt.MapFrom(src => src.Expenses != null ? src.Expenses.Description : string.Empty))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty));

            CreateMap<ExpenseUnits, Application.Feature.Query.ExpenseUnit.GetExpenseUnitsByExpenseId.ExpenseUnitViewModel>()
                .ForMember(dest => dest.ExpenseDescription, opt => opt.MapFrom(src => src.Expenses != null ? src.Expenses.Description : string.Empty))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty));
        }
    }
}
