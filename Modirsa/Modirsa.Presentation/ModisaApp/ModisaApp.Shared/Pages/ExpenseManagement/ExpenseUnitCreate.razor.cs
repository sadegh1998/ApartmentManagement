using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.ExpenseUnit;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.DTO.Unit;
using Application.Feature.Command.ExpenseUnit.CreateExpenseUnit;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpenseUnitCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreateExpenseUnitCommand expenseUnit = new()
        {
            AmountDue = 0,
            ExpenseId = Guid.Empty,
            UnitId = Guid.Empty
        };
        private Guid? selectedExpenseId;
        private Guid? selectedUnitId;
        private List<ExpenseViewModel> expenses = new();
        private List<UnitViewModel> units = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadExpenses();
            await LoadUnits();
        }

        async Task LoadExpenses()
        {
            try
            {
                expenses = (await _httpServiceProvider.Get<IEnumerable<ExpenseViewModel>?>("Expense/GetAllExpenses"))?.ToList() ?? new();
            }
            catch (Exception ex)
            {
                // Log error
                expenses = new();
            }
        }

        async Task LoadUnits()
        {
            try
            {
                units = (await _httpServiceProvider.Get<IEnumerable<UnitViewModel>?>("Unit/GetAllUnitsAsync"))?.ToList() ?? new();
            }
            catch (Exception ex)
            {
                // Log error
                units = new();
            }
        }

        async Task CreateExpenseUnit()
        {
            if (selectedExpenseId.HasValue && selectedUnitId.HasValue)
            {
                expenseUnit.ExpenseId = selectedExpenseId.Value;
                expenseUnit.UnitId = selectedUnitId.Value;

                var result = await _httpServiceProvider.Post<CreateExpenseUnitCommand, object>("ExpenseUnit/CreateExpenseUnit", expenseUnit);
                if (result != null)
                {
                    var parameters = new DialogParameters
                    {
                        { "ContentText", "تخصیص هزینه با موفقیت ایجاد شد" },
                        { "ButtonText", "باشه" },
                        { "Color", Color.Success }
                    };
                    var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                    await dialog.Result;
                    
                    NavigationManager.NavigateTo("/ExpenseUnit/List");
                }
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/ExpenseUnit/List");
        }
    }


}
