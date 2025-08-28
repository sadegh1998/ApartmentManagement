using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.DTO.Building;
using Application.Feature.Command.Expense.CreateExpense;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpenseCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILogger<ExpenseCreate> Logger { get; set; }

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
            Logger.LogInformation("ExpenseCreate.OnInitializedAsync started");
            try
            {
                await LoadBuildings();
                Logger.LogInformation("ExpenseCreate.OnInitializedAsync completed successfully");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in ExpenseCreate.OnInitializedAsync");
                buildings = new();
            }
        }

        async Task LoadBuildings()
        {
            Logger.LogInformation("LoadBuildings started");
            try
            {
                var response = await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>("Building/GetAllBuilding");
                Logger.LogInformation("API Response received: {Response}", response);
                
                buildings = response?.ToList() ?? new();
                Logger.LogInformation("Buildings loaded successfully. Count: {Count}", buildings.Count);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in LoadBuildings");
                buildings = new();
            }
        }

        async Task CreateExpense()
        {
            Logger.LogInformation("CreateExpense started with BuildingId: {BuildingId}", selectedBuildingId);
            try
            {
                if (selectedBuildingId.HasValue)
                {
                    expense.BuildingId = selectedBuildingId.Value;
                    Logger.LogInformation("Sending CreateExpense request: {@Expense}", expense);
                    
                    var result = await _httpServiceProvider.Post<CreateExpenseCommand, object>("Expense/CreateExpense", expense);
                    Logger.LogInformation("CreateExpense API response: {Result}", result);
                    
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
                        
                        Logger.LogInformation("Navigating to Expense/List");
                        NavigationManager.NavigateTo("/Expense/List");
                    }
                }
                else
                {
                    Logger.LogWarning("No building selected for expense creation");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in CreateExpense");
                var parameters = new DialogParameters
                {
                    { "ContentText", $"خطا در ایجاد هزینه: {ex.Message}" },
                    { "ButtonText", "باشه" },
                    { "Color", Color.Error }
                };
                var dialog = await _DialogService.ShowAsync<SimpleDialog>("خطا", parameters);
                await dialog.Result;
            }
        }

        void Cancel()
        {
            Logger.LogInformation("Cancel clicked, navigating to Expense/List");
            NavigationManager.NavigateTo("/Expense/List");
        }
    }
}
