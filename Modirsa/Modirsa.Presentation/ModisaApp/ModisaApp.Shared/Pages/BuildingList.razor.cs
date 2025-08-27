using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.Components.Dialogs;
using ModisaApp.Shared.Components.Dialogs.Building;
using ModisaApp.Shared.Components.Dialogs.Unit;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Pages
{
    public partial class BuildingList
    {
        const string APIController = "Building";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        public IEnumerable<BuildingViewModel>? Buildings { get; set; } = new List<BuildingViewModel>();
        public bool IsLoading { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            //Buildings = await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>($"{APIController}/GetAllBuilding");
            //await InvokeAsync(StateHasChanged);
            await LoadBuildings();
           
        }
        async Task LoadBuildings()
        {
            Buildings = (await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>($"{APIController}/GetAllBuilding")) ?? new List<BuildingViewModel>();
            IsLoading = true;
        }
        async Task OpenAddDialog()
        {
            var parameters = new DialogParameters<CreateBuilding>();
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = await _DialogService.ShowAsync<AddBuildingDialog>("افزودن ساختمان جدید", parameters, options);
            var result = await dialog.Result; // منتظر می‌مانیم تا دیالوگ بسته شود

            if (!result.Canceled && result.Data is CreateBuilding newBuilding)
            {
                await AddBuilding(newBuilding);
            }
        }
        async Task OpenEditDialog(Guid Id)
        {
            var parameters = new DialogParameters { { "BuildingId", Id } };
            var dialog = await _DialogService.ShowAsync<EditBuildingDialog>("ویرایش ساختمان", parameters);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadBuildings();
            }
        }
        async Task OpenDetailDialog(Guid Id)
        {
            var parameters = new DialogParameters { { "BuildingId", Id } };
            var dialog = await _DialogService.ShowAsync<DetailBuildingDialog>("جزئیات ساختمان", parameters);
            await dialog.Result;
        }
        async Task AddBuilding(CreateBuilding newBuilding)
        {
            await _httpServiceProvider.Post<CreateBuilding, object>($"{APIController}/CreateNewBuilding", newBuilding);
            await LoadBuildings();
        }
        async Task ShowBuildingUnits(BuildingViewModel command)
        {
            var parameters = new DialogParameters<BuildingUnitsListDialog>
            {
                {x=>x.BuildingId , command.Id }
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Large, FullWidth = true };
            var dialog = await _DialogService.ShowAsync<BuildingUnitsListDialog>("افزودن واحد جدید", parameters, options);
        }
    }
}