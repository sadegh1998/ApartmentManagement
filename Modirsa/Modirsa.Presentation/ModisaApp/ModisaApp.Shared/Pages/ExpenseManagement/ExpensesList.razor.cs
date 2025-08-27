using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Expense;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpensesList
    {
        const string APIController = "Expense";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public IEnumerable<ExpenseViewModel>? Expenses { get; set; } = new List<ExpenseViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadExpenses();
        }

        async Task LoadExpenses()
        {
            Expenses = (await _httpServiceProvider.Get<IEnumerable<ExpenseViewModel>?>($"{APIController}/GetAllExpenses")) ?? new List<ExpenseViewModel>();
            IsLoading = true;
        }

        async Task OpenAddDialog()
        {
            NavigationManager.NavigateTo("/Expense/Create");
        }

        async Task OpenEditDialog(Guid Id)
        {
            // TODO: Implement Edit Expense Dialog
            await Task.CompletedTask;
        }

        async Task OpenDetailDialog(Guid Id)
        {
            // TODO: Implement Detail Expense Dialog
            await Task.CompletedTask;
        }
    }
}