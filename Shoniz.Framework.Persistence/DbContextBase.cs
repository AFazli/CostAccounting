using Microsoft.EntityFrameworkCore;

namespace Shoniz.Framework.Persistence;

public abstract class DbContextBase : DbContext, IDbContext
{
    protected abstract string GetConnectionString();
    protected abstract Type GetSampleEntityMappingType();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies(false)
            .UseSqlServer(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypeConfigurations = GetSampleEntityMappingType().Assembly
            .GetTypes()
            .Where(t => t.GetInterface(nameof(IEntityMapping)) != null)
            .Select(Activator.CreateInstance)
            .Cast<dynamic>()
            .ToList();

        entityTypeConfigurations.ForEach(config => modelBuilder.ApplyConfiguration(config));
    }

}