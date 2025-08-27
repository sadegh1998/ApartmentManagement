using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Expense
{
    public partial class EditExpenseDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid ExpenseId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private MudForm form;
        private bool success;
        private EditExpense editExpense = new();
        private Guid? selectedBuildingId;
        private List<BuildingViewModel> buildings = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadExpense();
            await LoadBuildings();
        }

        async Task LoadExpense()
        {
            var expense = await _httpServiceProvider.Get<ExpenseViewModel>($"Expense/GetExpenseById/{ExpenseId}");
            if (expense != null)
            {
                editExpense.Id = expense.Id;
                editExpense.Description = expense.Description;
                editExpense.Amount = expense.Amount;
                editExpense.DateIncurred = expense.DateIncurred;
                editExpense.AllocationMethod = expense.AllocationMethod;
                // Note: BuildingId will be set when buildings are loaded
            }
        }

        async Task LoadBuildings()
        {
            buildings = (await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>("Building/GetAllBuilding"))?.ToList() ?? new();
        }

        async Task Submit()
        {
            if (selectedBuildingId.HasValue)
            {
                editExpense.BuildingId = selectedBuildingId.Value;
                
                var result = await _httpServiceProvider.Put<EditExpense, object>("Expense/EditExpense", editExpense);
                if (result != null)
                {
                    MudDialog.Close(DialogResult.Ok(true));
                }
            }
        }

        void Cancel() => MudDialog.Cancel();
    }

    public class EditExpense
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public string AllocationMethod { get; set; } = string.Empty;
        public Guid BuildingId { get; set; }
    }
}
