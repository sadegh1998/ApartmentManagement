using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Role;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components.Dialogs.Role;
using MudBlazor;

namespace ModisaApp.Shared.Pages
{
    public partial class RoleList
    {
        const string APIController = "Role";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public IEnumerable<RoleViewModel>? Roles { get; set; } = new List<RoleViewModel>();
        public bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadRoles();
        }

        async Task LoadRoles()
        {
            Roles = (await _httpServiceProvider.Get<IEnumerable<RoleViewModel>?>($"{APIController}/GetAllRoles")) ?? new List<RoleViewModel>();
            IsLoading = true;
        }

        async Task OpenAddDialog()
        {
            NavigationManager.NavigateTo("/Role/Create");
        }

        async Task OpenEditDialog(Guid Id)
        {
            var parameters = new DialogParameters { { "RoleId", Id } };
            var dialog = await _DialogService.ShowAsync<EditRoleDialog>("ویرایش نقش", parameters);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadRoles();
            }
        }

        async Task OpenDetailDialog(Guid Id)
        {
            var parameters = new DialogParameters { { "RoleId", Id } };
            var dialog = await _DialogService.ShowAsync<DetailRoleDialog>("جزئیات نقش", parameters);
            await dialog.Result;
        }

        async Task OpenDeleteDialog(Guid Id)
        {
            var role = Roles?.FirstOrDefault(r => r.Id == Id);
            if (role != null)
            {
                var parameters = new DialogParameters 
                { 
                    { "RoleId", Id },
                    { "RoleTitle", role.Title }
                };
                var dialog = await _DialogService.ShowAsync<DeleteRoleDialog>("حذف نقش", parameters);
                var result = await dialog.Result;
                if (!result.Canceled)
                {
                    await LoadRoles();
                }
            }
        }
    }
}
