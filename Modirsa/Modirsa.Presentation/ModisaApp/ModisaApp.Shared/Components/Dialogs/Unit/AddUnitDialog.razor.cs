using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Unit
{
    public partial class AddUnitDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public Guid BuildingId { get; set; }
        [Parameter]
        public CreateUnit NewUnit { get; set; } = new CreateUnit()
        {
            Name = "",
          NumberOfFamilyMembers = 0,
          OwnerTenanStatus="",
          UnitNumber = 0
        };

      

        async Task AddBuilding()
        {
            NewUnit.BuildingId = BuildingId;
            MudDialog.Close(DialogResult.Ok(NewUnit));
        }

        void Close() => MudDialog.Cancel();
    }
}