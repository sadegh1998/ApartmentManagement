using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.DTO.Building;
using Application.Feature.Command.Expense.CreateExpense;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpenseCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreateExpenseCommand expense = new()
        {
            BuildingId = Guid.Empty,
            Description = string.Empty,
            Amount = 0,
            DateIncurred = DateTime.Now,
            AllocationMethod = string.Empty
        };
        private Guid? selectedBuildingId;
        private List<BuildingViewModel> buildings = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadBuildings();
        }

        async Task LoadBuildings()
        {
            buildings = (await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>("Building/GetAllBuilding"))?.ToList() ?? new();
        }

        async Task CreateExpense()
        {
            if (selectedBuildingId.HasValue)
            {
                expense.BuildingId = selectedBuildingId.Value;
                
                var result = await _httpServiceProvider.Post<CreateExpenseCommand, object>("Expense/CreateExpense", expense);
                if (result != null)
                {
                    var parameters = new DialogParameters
                    {
                        { "ContentText", "هزینه با موفقیت ایجاد شد" },
                        { "ButtonText", "باشه" },
                        { "Color", Color.Success }
                    };
                    var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                    await dialog.Result;
                    
                    NavigationManager.NavigateTo("/Expense/List");
                }
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Expense/List");
        }
    }


}
