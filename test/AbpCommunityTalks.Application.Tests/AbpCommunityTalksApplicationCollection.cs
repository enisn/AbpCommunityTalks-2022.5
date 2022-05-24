using AbpCommunityTalks.MongoDB;
using Xunit;

namespace AbpCommunityTalks;

[CollectionDefinition(AbpCommunityTalksTestConsts.CollectionDefinitionName)]
public class AbpCommunityTalksApplicationCollection : AbpCommunityTalksMongoDbCollectionFixtureBase
{

}
