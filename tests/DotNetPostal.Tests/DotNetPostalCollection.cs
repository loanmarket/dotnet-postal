using Xunit;

namespace DotNetPostal.Tests;

[CollectionDefinition(CollectionName)]
public class DotNetPostalCollection : ICollectionFixture<DotNetPostalFixture>
{
    public const string CollectionName = "DotNetPostal collection";
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}