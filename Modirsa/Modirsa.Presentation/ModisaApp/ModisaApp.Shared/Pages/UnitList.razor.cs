using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Pages
{
    public partial class UnitList
    {
        const string APIController = "Unit";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public IEnumerable<UnitViewModel>? Units { get; set; } = new List<UnitViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadUnits();
        }

        async Task LoadUnits()
        {
            Units = (await _httpServiceProvider.Get<IEnumerable<UnitViewModel>?>($"{APIController}/GetAllUnits")) ?? new List<UnitViewModel>();
            IsLoading = true;
        }

        async Task OpenAddDialog()
        {
            NavigationManager.NavigateTo("/Unit/Create");
        }

        async Task OpenEditDialog(Guid Id)
        {
            // TODO: Implement Edit Unit Dialog
            await Task.CompletedTask;
        }

        async Task OpenDetailDialog(Guid Id)
        {
            // TODO: Implement Detail Unit Dialog
            await Task.CompletedTask;
        }
    }
}
