using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Role;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Role
{
    public partial class DetailRoleDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid RoleId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private RoleViewModel Role = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadRole();
        }

        async Task LoadRole()
        {
            var role = await _httpServiceProvider.Get<RoleViewModel>($"Role/GetRoleById/{RoleId}");
            if (role != null)
            {
                Role = role;
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}


