using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Permission;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Pages
{
    public partial class PermissionList
    {
        const string APIController = "Permission";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public IEnumerable<PermissionViewModel>? Permissions { get; set; } = new List<PermissionViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadPermissions();
        }

        async Task LoadPermissions()
        {
            Permissions = (await _httpServiceProvider.Get<IEnumerable<PermissionViewModel>?>($"{APIController}/GetAllPermissions")) ?? new List<PermissionViewModel>();
            IsLoading = true;
        }

        async Task OpenAddDialog()
        {
            NavigationManager.NavigateTo("/Permission/Create");
        }

        async Task OpenDetailDialog(Guid Id)
        {
            // TODO: Implement Detail Permission Dialog
            await Task.CompletedTask;
        }
    }
}
