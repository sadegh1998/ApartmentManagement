using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Building
{
    public partial class DetailBuildingDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid BuildingId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private BuildingViewModel? EditBuilding;

        protected override async Task OnInitializedAsync()
        {
            await LoadBuilding();
        }

        async Task LoadBuilding()
        {
            var building = await _httpServiceProvider.Get<BuildingViewModel>($"Building/GetBuildingById/{BuildingId}");
            if (building != null)
            {
                EditBuilding = building;
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}