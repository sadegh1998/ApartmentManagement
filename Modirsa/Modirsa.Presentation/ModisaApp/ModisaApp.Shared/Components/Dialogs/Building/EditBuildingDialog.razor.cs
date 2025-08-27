using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Building
{
    public partial class EditBuildingDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid BuildingId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private MudForm form;
        private bool success;
        private EditBuilding editBuilding = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadBuilding();
        }

        async Task LoadBuilding()
        {
            var building = await _httpServiceProvider.Get<BuildingViewModel>($"Building/GetBuildingById/{BuildingId}");
            if (building != null)
            {
                editBuilding.Id = building.Id;
                editBuilding.Name = building.Name;
                editBuilding.Address = building.Address;
                editBuilding.Floors = building.Floors;
                editBuilding.BuildingUnitsNo = building.BuildingUnitsNo;
                editBuilding.FundBalance = building.FundBalance;
            }
        }

        async Task Submit()
        {
            var result = await _httpServiceProvider.Put<EditBuilding, object>("Building/EditBuilding", editBuilding);
            if (result != null)
            {
                MudDialog.Close(DialogResult.Ok(true));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}