using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.ExpenseUnit;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.ExpenseUnit
{
    public partial class AddExpenseUnitDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }

        private MudForm form;
        private bool success;
        private CreateExpenseUnit expenseUnit = new()
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
            expenses = (await _httpServiceProvider.Get<IEnumerable<ExpenseViewModel>?>("Expense/GetAllExpenses"))?.ToList() ?? new();
        }

        async Task LoadUnits()
        {
            units = (await _httpServiceProvider.Get<IEnumerable<UnitViewModel>?>("Unit/GetAllUnits"))?.ToList() ?? new();
        }

        async Task Submit()
        {
            if (selectedExpenseId.HasValue && selectedUnitId.HasValue)
            {
                expenseUnit.ExpenseId = selectedExpenseId.Value;
                expenseUnit.UnitId = selectedUnitId.Value;

                var result = await _httpServiceProvider.Post<CreateExpenseUnit, object>("ExpenseUnit/CreateExpenseUnit", expenseUnit);
                if (result != null)
                {
                    MudDialog.Close(DialogResult.Ok(expenseUnit));
                }
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}
