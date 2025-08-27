using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Permission;
using Application.Feature.Command.Permission.CreatePermission;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ModisaApp.Shared.Pages
{
    public partial class PermissionCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreatePermissionCommand permission = new()
        {
            Name = string.Empty,
            Code = string.Empty
        };

        async Task CreatePermission()
        {
            var result = await _httpServiceProvider.Post<CreatePermissionCommand, object>("Permission/CreatePermission", permission);
            if (result != null)
            {
                var parameters = new DialogParameters
                {
                    { "ContentText", "مجوز با موفقیت ایجاد شد" },
                    { "ButtonText", "باشه" },
                    { "Color", Color.Success }
                };
                var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                await dialog.Result;
                
                NavigationManager.NavigateTo("/Permission/List");
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Permission/List");
        }
    }


}
