using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;

namespace ModisaApp.Shared.Pages
{
    public partial class BuildingList
    {
        const string APIController = "Building";
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        public IEnumerable<BuildingViewModel>? Buildings { get; set; } = new List<BuildingViewModel>();
        protected override async Task OnInitializedAsync()
        {
            Buildings = await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>($"{APIController}/GetAllBuilding");
            await InvokeAsync(StateHasChanged);
        }
    }
}