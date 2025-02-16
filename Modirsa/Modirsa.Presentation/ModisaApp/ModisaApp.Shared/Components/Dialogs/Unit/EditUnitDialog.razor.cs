using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Unit
{
    public partial class EditUnitDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public Guid UnitId { get; set; }
        const string APIController = "Unit";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        public EditUnit? EditUnit { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            EditUnit = await _httpServiceProvider.Get<EditUnit?>($"{APIController}/GetUnitByAsync?Id={UnitId}");
        }
        async Task EditUnitAsync()
        {
            MudDialog.Close(DialogResult.Ok(EditUnit));
        }
    }
}