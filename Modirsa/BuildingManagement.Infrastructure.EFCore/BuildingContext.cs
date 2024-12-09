using BuildingManagement.Domain.BuildingAgg;
using BuildingManagement.Domain.UnitAgg;
using BuildingManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Infrastructure.EFCore
{
    public class BuildingContext : DbContext
    {
        public DbSet<Building> Buildings{ get; set; }
        public DbSet<Unit> Units{ get; set; }
        public BuildingContext(DbContextOptions<BuildingContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BuildingMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
