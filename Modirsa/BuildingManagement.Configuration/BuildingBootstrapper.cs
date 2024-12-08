using BuildingManagement.Domain.BuildingAgg;
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

            services.AddDbContext<BuildingContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
