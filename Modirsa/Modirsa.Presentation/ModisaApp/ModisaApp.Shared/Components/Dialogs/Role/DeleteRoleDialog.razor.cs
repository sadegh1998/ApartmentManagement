using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Role;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Role
{
    public partial class DeleteRoleDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid RoleId { get; set; }
        [Parameter] public string RoleTitle { get; set; } = string.Empty;
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }

        async Task ConfirmDelete()
        {
            var result = await _httpServiceProvider.Delete<object>($"Role/DeleteRole/{RoleId}");
            if (result != null)
            {
                MudDialog.Close(DialogResult.Ok(true));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}
