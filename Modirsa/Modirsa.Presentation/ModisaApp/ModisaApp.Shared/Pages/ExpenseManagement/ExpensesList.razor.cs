using ExpenseManagement.Application.Contract.Expense;
using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.Interfaces.Providers;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpensesList
    {
        const string APIController = "Expense";
        [Inject] IHttpServiceProvider _HttpServiceProvider {  get; set; }
        public List<ExpenseViewModel> _AllExpenses { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}