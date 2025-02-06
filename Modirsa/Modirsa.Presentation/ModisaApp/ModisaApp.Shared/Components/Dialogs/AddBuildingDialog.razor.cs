using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs
{
    public partial class AddBuildingDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public CreateBuilding NewBuilding { get; set; } = new CreateBuilding()
        {
            Name = "",
            BuildingUnitsNo = 0,
            FundBalance = 0,
            Address = "",
            Floors = 1
        };

        protected override void OnInitialized()
        {
           
        }

        async Task AddBuilding()
        {
            MudDialog.Close(DialogResult.Ok(NewBuilding));
        }

        void Close() => MudDialog.Cancel();
    }
}