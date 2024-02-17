using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VineForceAPI.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class VineForceAPIDbContextFactory : IDesignTimeDbContextFactory<VineForceAPIDbContext>
{
    public VineForceAPIDbContext CreateDbContext(string[] args)
    {
        VineForceAPIEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<VineForceAPIDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new VineForceAPIDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VineForceAPI.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
