using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpCommunityTalks.Data;

/* This is used if database provider does't define
 * IAbpCommunityTalksDbSchemaMigrator implementation.
 */
public class NullAbpCommunityTalksDbSchemaMigrator : IAbpCommunityTalksDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
