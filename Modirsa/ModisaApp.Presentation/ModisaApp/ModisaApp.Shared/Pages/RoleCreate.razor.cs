using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Role;
using Application.Feature.Command.Role.CreateRole;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ModisaApp.Shared.Pages
{
    public partial class RoleCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreateRoleCommand role = new()
        {
            Title = string.Empty
        };

        async Task CreateRole()
        {
            var result = await _httpServiceProvider.Post<CreateRoleCommand, object>("Role/CreateRole", role);
            if (result != null)
            {
                var parameters = new DialogParameters
                {
                    { "ContentText", "نقش با موفقیت ایجاد شد" },
                    { "ButtonText", "باشه" },
                    { "Color", Color.Success }
                };
                var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                await dialog.Result;
                
                NavigationManager.NavigateTo("/Role/List");
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Role/List");
        }
    }


}
