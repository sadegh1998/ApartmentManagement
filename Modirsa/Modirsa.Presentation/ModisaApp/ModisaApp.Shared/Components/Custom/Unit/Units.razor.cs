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
            await _httpServiceProvider.Post<CreateUnit, object>($"{APIController}/CreateUnitAsync", newUnit);
            await OnInitializedAsync();
        }

        async Task OpenEditDialog(Guid Id)
        {
            var parameters = new DialogParameters<EditUnitDialog>
            {
                {x=>x.UnitId  , Id }
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = await _DialogService.ShowAsync<EditUnitDialog>("ویرایش واحد ", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled && result.Data is EditUnit update)
            {
                await EditUnit(update);
            }
        }
        async Task EditUnit(EditUnit update)
        {
            await _httpServiceProvider.Put<EditUnit, object>($"{APIController}/EditUnitAsync", update);
            await OnInitializedAsync();
        }
        async Task OpenDetailDialog(Guid Id)
        {
            var parameters = new DialogParameters<DetailUnitDialog>
            {
                {x=>x.UnitId  , Id }
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = await _DialogService.ShowAsync<DetailUnitDialog>("جزییات واحد ", parameters, options);
        }
    }
}