using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Pages.Unit
{
    public partial class UnitsList
    {
        const string APIController = "Unit";
        [Inject] IHttpServiceProvider _httpServiceProvider {  get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        public IEnumerable<UnitViewModel>? _AllUnits { get; set; } = new List<UnitViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            _AllUnits = await _httpServiceProvider.Get<IEnumerable<UnitViewModel>?>($"{APIController}/GetAllUnitsAsync");
            IsLoading = true;
        }
        async Task OpenAddDialog()
        {

        }
        async Task OpenEditDialog(Guid Id)
        {

        }
        async Task OpenDetailDialog(Guid Id)
        {

        }
    }
}