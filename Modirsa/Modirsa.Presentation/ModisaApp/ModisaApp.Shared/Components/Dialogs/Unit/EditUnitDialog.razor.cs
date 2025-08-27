using Microsoft.AspNetCore.Components;
using ModisaApp.Shared.DTO.Unit;
using ModisaApp.Shared.DTO.Building;
using ModisaApp.Shared.Interfaces.Providers;
using MudBlazor;

namespace ModisaApp.Shared.Components.Dialogs.Unit
{
    public partial class EditUnitDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid UnitId { get; set; }
        
        [Inject] IHttpServiceProvider _httpServiceProvider { get; set; }
        
        private MudForm form;
        private bool success;
        private EditUnit editUnit = new();
        private Guid? selectedBuildingId;
        private List<BuildingViewModel> buildings = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadUnit();
            await LoadBuildings();
        }

        async Task LoadUnit()
        {
            var unit = await _httpServiceProvider.Get<UnitViewModel>($"Unit/GetUnitById/{UnitId}");
            if (unit != null)
            {
                editUnit.Id = unit.Id;
                editUnit.Name = unit.Name;
                editUnit.UnitNumber = unit.UnitNumber;
                editUnit.OwnerTenanStatus = unit.OwnerTenanStatus;
                editUnit.NumberOfFamilyMembers = unit.NumberOfFamilyMembers;
                // Note: BuildingId will be set when buildings are loaded
            }
        }

        async Task LoadBuildings()
        {
            buildings = (await _httpServiceProvider.Get<IEnumerable<BuildingViewModel>?>("Building/GetAllBuilding"))?.ToList() ?? new();
        }

        async Task Submit()
        {
            if (selectedBuildingId.HasValue)
            {
                editUnit.BuildingId = selectedBuildingId.Value;
                
                var result = await _httpServiceProvider.Put<EditUnit, object>("Unit/EditUnit", editUnit);
                if (result != null)
                {
                    MudDialog.Close(DialogResult.Ok(true));
                }
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}