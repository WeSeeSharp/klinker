using Xunit;

namespace BabySitter.Specs.General
{
    [CollectionDefinition(Name)]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
        public const string Name = "ServerFixtureCollection";
    }
}