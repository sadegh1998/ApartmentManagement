using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Role;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Role
{
    public partial class EditRoleDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid RoleId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private MudForm form;
        private bool success;
        private EditRole editRole = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadRole();
        }

        async Task LoadRole()
        {
            var role = await _httpServiceProvider.Get<RoleViewModel>($"Role/GetRoleById/{RoleId}");
            if (role != null)
            {
                editRole.Id = role.Id;
                editRole.Title = role.Title;
            }
        }

        async Task Submit()
        {
            var result = await _httpServiceProvider.Put<EditRole, object>("Role/EditRole", editRole);
            if (result != null)
            {
                MudDialog.Close(DialogResult.Ok(true));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }

    public class EditRole
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
