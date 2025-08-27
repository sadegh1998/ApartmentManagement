using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using Application.Feature.Command.Building.CreateBuilding;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ModisaApp.Shared.Pages
{
    public partial class BuildingCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreateBuildingCommand building = new()
        {
            Name = string.Empty,
            Address = string.Empty,
            Floors = 0,
            BuildingUnitsNo = 0,
            FundBalance = 0,
            Image = null
        };

        async Task CreateBuilding()
        {
            var result = await _httpServiceProvider.Post<CreateBuildingCommand, object>("Building/CreateNewBuilding", building);
            if (result != null)
            {
                var parameters = new DialogParameters
                {
                    { "ContentText", "ساختمان با موفقیت ایجاد شد" },
                    { "ButtonText", "باشه" },
                    { "Color", Color.Success }
                };
                var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                await dialog.Result;
                
                NavigationManager.NavigateTo("/Building/List");
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Building/List");
        }
    }


}
