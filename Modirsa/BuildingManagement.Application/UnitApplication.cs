using _0_Framework.Application;
using BuildingManagement.Application.Contract.Unit;
using BuildingManagement.Domain.UnitAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application
{
    public class UnitApplication : IUnitApplication
    {
        private readonly IUnitRepository _unitRepository;

        public UnitApplication(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<OperationResult> CreateAsync(CreateUnit command)
        {
            var operation = new OperationResult();
            if (await _unitRepository.ExsitsAsync(x => x.Name == command.Name && x.BuildingId == command.BuildingId))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }

            var unit = new Unit(command.Name, command.UnitNumber, command.OwnerTenanStatus, command.NumberOfFamilyMembers, command.BuildingId);
            await _unitRepository.CreateAsync(unit);
            await _unitRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> EditAsync(EditUnit command)
        {
            var operation = new OperationResult();
            var unit =await _unitRepository.GetAsync(command.Id);
            if(unit == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            if (await _unitRepository.ExsitsAsync(x => x.Name == command.Name && x.BuildingId == command.BuildingId && x.Id != unit.Id))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }

            unit.Edit(command.Name, command.UnitNumber, command.OwnerTenanStatus, command.NumberOfFamilyMembers, command.BuildingId);
            await _unitRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<List<UnitViewModel>> GetAllUnit()
        {
            var unit = await _unitRepository.GetAllAsync();
            return unit.Select(x => new UnitViewModel {
            Name = x.Name,
            UnitNumber= x.UnitNumber,
            NumberOfFamilyMembers= x.NumberOfFamilyMembers,
            OwnerTenanStatus=x.OwnerTenanStatus,
            BuildingName = x.Building.Name
            }).ToList();
        }

        public async Task<UnitViewModel> GetUnitBy(Guid id)
        {
            var unit = await _unitRepository.GetAsync(id);
            return new UnitViewModel { 
            Name = unit.Name,
            BuildingName = unit.Building.Name,
            NumberOfFamilyMembers = unit.NumberOfFamilyMembers,
            OwnerTenanStatus = unit.OwnerTenanStatus,   
            UnitNumber = unit.UnitNumber
            };
        }

        public async Task<List<UnitViewModel>> Search(UnitSearchModel searchModel)
        {
            var result = await _unitRepository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                result = result.Where(x => x.Name.Contains(searchModel.Name)).ToList();
            }
            return result.Select(x=> new UnitViewModel {
            Name= x.Name,
            UnitNumber = x.UnitNumber,
            NumberOfFamilyMembers = x.NumberOfFamilyMembers,
            OwnerTenanStatus= x.OwnerTenanStatus,
            BuildingName = x.Building.Name
            }).ToList();
        }
    }
}
