using System.Threading.Tasks;

namespace AbpCommunityTalks.Data;

public interface IAbpCommunityTalksDbSchemaMigrator
{
    Task MigrateAsync();
}
