using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.Components.Dialogs.Unit;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Custom.Unit
{
    public partial class Units
    {
        [Parameter]
        public Guid BuildingId { get; set; }
        const string APIController = "Unit";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
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
            var parameters = new DialogParameters<AddUnitDialog> {
                {x=>x.BuildingId , BuildingId}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = await _DialogService.ShowAsync<AddUnitDialog>("افزودن واحد جدید", parameters, options);
            var result = await dialog.Result; // منتظر می‌مانیم تا دیالوگ بسته شود

            if (!result.Canceled && result.Data is CreateUnit newUnit)
            {
                await AddUnit(newUnit);
            }
        }

        async Task AddUnit(CreateUnit newUnit)
        {
            await _httpServiceProvider.Post<CreateUnit, bool>($"{APIController}/CreateUnitAsync", newUnit);
        }

        async Task OpenEditDialog(Guid Id)
        {

        }
        async Task OpenDetailDialog(Guid Id)
        {

        }
    }
}