using System.Threading.Tasks;

namespace VineForceAPI.Data;

public interface IVineForceAPIDbSchemaMigrator
{
    Task MigrateAsync();
}
