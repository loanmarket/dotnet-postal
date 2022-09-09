using FluentAssertions;
using LMGTech.DotNetPostal.Models;
using Xunit;

namespace LMGTech.DotNetPostal.Tests;

[Collection(DotNetPostalCollection.CollectionName)]
public class ParserTests : IClassFixture<DotNetPostalFixture>
{
    private DotNetPostalFixture _fixture;

    public ParserTests(DotNetPostalFixture fixture)
    { 
        _fixture = fixture;
    }
    
    [Fact]
    public void CanLoadDotNetPostal()
    {
        PostMaster.IsInitialised.Should().BeTrue();
    }

    [Fact]
    public void CanParseAddress()
    {
        var address = "17A Marian St, Coorparoo, QLD, 4151, Australia";

        var parsedAddress = PostMaster.ParseAddress(address);
        
        parsedAddress.Should().NotBeNull();
        parsedAddress!.AddressParts.Count.Should().Be(6);
        
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Postcode, "4151");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Country, "Australia");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.State, "Qld");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Suburb, "Coorparoo");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.HouseNumber, "17A");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Road, "Marian St");
    }
}