using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Building
{
    public partial class DetailBuildingDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public EditBuilding EditBuilding { get; set; }

    }
}