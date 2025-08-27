using AutoMapper;
using Domain.ExpenseAgg;

namespace Application.AutoMapperProfiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expenses, Application.Feature.Query.Expense.GetAllExpenses.ExpenseViewModel>()
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.Name : string.Empty))
                .ForMember(dest => dest.ExpenseUnitsCount, opt => opt.MapFrom(src => src.ExpenseUnits != null ? src.ExpenseUnits.Count : 0));

            CreateMap<Expenses, Application.Feature.Query.Expense.GetExpenseById.ExpenseViewModel>()
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.Name : string.Empty));

            CreateMap<Expenses, Application.Feature.Query.Expense.SearchExpenses.ExpenseViewModel>()
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.Name : string.Empty))
                .ForMember(dest => dest.ExpenseUnitsCount, opt => opt.MapFrom(src => src.ExpenseUnits != null ? src.ExpenseUnits.Count : 0));
        }
    }
}
