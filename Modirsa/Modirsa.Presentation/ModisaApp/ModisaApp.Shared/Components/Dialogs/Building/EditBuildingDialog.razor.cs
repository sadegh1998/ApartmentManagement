using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Building
{
    public partial class EditBuildingDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public EditBuilding EditBuilding { get; set; }
        
        async Task EditdBuilding()
        {
            MudDialog.Close(DialogResult.Ok(EditBuilding));
        }
    }
}