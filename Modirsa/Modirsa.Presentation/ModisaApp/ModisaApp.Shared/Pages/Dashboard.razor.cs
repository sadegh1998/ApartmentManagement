using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.Interfaces.Providers;

namespace ModisaApp.Shared.Pages
{
    public partial class Dashboard
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        public int buildingCount = 0;
        public int unitCount = 0;
        public int expenseCount = 0;
        public int expenseUnitCount = 0;

        protected override async Task OnInitializedAsync()
        {
            await LoadDashboardData();
        }

        async Task LoadDashboardData()
        {
            try
            {
                // Load counts from API
                var buildings = await _httpServiceProvider.Get<IEnumerable<object>?>("Building/GetAllBuilding");
                buildingCount = buildings?.Count() ?? 0;

                var units = await _httpServiceProvider.Get<IEnumerable<object>?>("Unit/GetAllUnitsAsync");
                unitCount = units?.Count() ?? 0;

                var expenses = await _httpServiceProvider.Get<IEnumerable<object>?>("Expense/GetAllExpenses");
                expenseCount = expenses?.Count() ?? 0;

                var expenseUnits = await _httpServiceProvider.Get<IEnumerable<object>?>("ExpenseUnit/GetAllExpenseUnits");
                expenseUnitCount = expenseUnits?.Count() ?? 0;
            }
            catch
            {
                // If API is not available, show default values
                buildingCount = 0;
                unitCount = 0;
                expenseCount = 0;
                expenseUnitCount = 0;
            }
        }
    }
}


