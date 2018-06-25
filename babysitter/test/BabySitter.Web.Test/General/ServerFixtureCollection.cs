using Xunit;

namespace BabySitter.Web.Test.General
{
    [CollectionDefinition(Name)]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
        public const string Name = "ServerFixtureCollection";
    }
}