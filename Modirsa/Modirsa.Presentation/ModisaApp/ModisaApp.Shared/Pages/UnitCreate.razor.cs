using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.DTO.Building;
using Application.Feature.Command.Unit.CreateUnit;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ModisaApp.Shared.Pages
{
    public partial class UnitCreate
    {
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        private MudForm form;
        private bool success;
        private CreateUnitCommand unit = new()
        {
            Name = string.Empty,
            UnitNumber = 0,
            OwnerTenanStatus = string.Empty,
            NumberOfFamilyMembers = 0,
            BuildingId = Guid.Empty
        };
        private Guid? selectedBuildingId;
        private List<BuildingViewModel> buildings = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadBuildings();
        }

        async Task LoadBuildings()
        {
            buildings = (await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>("Building/GetAllBuilding"))?.ToList() ?? new();
        }

        async Task CreateUnit()
        {
            if (selectedBuildingId.HasValue)
            {
                unit.BuildingId = selectedBuildingId.Value;
                
                var result = await _httpServiceProvider.Post<CreateUnitCommand, object>("Unit/CreateUnit", unit);
                if (result != null)
                {
                    var parameters = new DialogParameters
                    {
                        { "ContentText", "واحد با موفقیت ایجاد شد" },
                        { "ButtonText", "باشه" },
                        { "Color", Color.Success }
                    };
                    var dialog = await _DialogService.ShowAsync<SimpleDialog>("پیام", parameters);
                    await dialog.Result;
                    
                    NavigationManager.NavigateTo("/Unit/List");
                }
            }
        }

        void Cancel()
        {
            NavigationManager.NavigateTo("/Unit/List");
        }
    }


}
