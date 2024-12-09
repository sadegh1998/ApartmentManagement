using BuildingManagement.Application;
using BuildingManagement.Application.Contract.Building;
using BuildingManagement.Domain.BuildingAgg;
using BuildingManagement.Domain.UnitAgg;
using BuildingManagement.Infrastructure.EFCore;
using BuildingManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Configuration
{
    public class BuildingBootstrapper
    {
        public void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IBuildingApplication, BuildingApplication>();
            services.AddTransient<IUnitRepository, UnitRepository>();


            services.AddDbContext<BuildingContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
