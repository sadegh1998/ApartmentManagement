using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.ExpenseUnit;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components.Dialogs.ExpenseUnit;
using MudBlazor;

namespace ModisaApp.Shared.Pages.ExpenseManagement
{
    public partial class ExpenseUnitList
    {
        const string APIController = "ExpenseUnit";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public IEnumerable<ExpenseUnitViewModel>? ExpenseUnits { get; set; } = new List<ExpenseUnitViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadExpenseUnits();
        }

        async Task LoadExpenseUnits()
        {
            ExpenseUnits = (await _httpServiceProvider.Get<IEnumerable<ExpenseUnitViewModel>?>($"{APIController}/GetAllExpenseUnits")) ?? new List<ExpenseUnitViewModel>();
            IsLoading = true;
        }

        async Task OpenAddDialog()
        {
            var parameters = new DialogParameters<CreateExpenseUnit>();
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = await _DialogService.ShowAsync<AddExpenseUnitDialog>("افزودن تخصیص هزینه جدید", parameters, options);
            var result = await dialog.Result;

            if (!result.Canceled && result.Data is CreateExpenseUnit newExpenseUnit)
            {
                await AddExpenseUnit(newExpenseUnit);
            }
        }

        async Task OpenEditDialog(Guid Id)
        {
            // TODO: Implement Edit ExpenseUnit Dialog
            await Task.CompletedTask;
        }

        async Task OpenDetailDialog(Guid Id)
        {
            // TODO: Implement Detail ExpenseUnit Dialog
            await Task.CompletedTask;
        }

        async Task AddExpenseUnit(CreateExpenseUnit newExpenseUnit)
        {
            await _httpServiceProvider.Post<CreateExpenseUnit, object>($"{APIController}/CreateExpenseUnit", newExpenseUnit);
            await LoadExpenseUnits();
        }
    }
}
