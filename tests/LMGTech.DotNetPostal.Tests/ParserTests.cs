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
    public void CanParseAddress_AU_Case_1()
    {
        var address = "17A Marian St, Coorparoo, QLD, 4151, Australia";

        var parsedAddress = PostMaster.ParseAddress(address);
        
        parsedAddress.Should().NotBeNull();
        parsedAddress!.AddressParts.Count.Should().Be(6);
        
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.HouseNumber, "17A");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Road, "Marian St");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Suburb, "Coorparoo");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.State, "Qld");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Postcode, "4151");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Country, "Australia");
    }
    
    [Fact]
    public void CanParseAddress_AU_Case_2()
    {
        var address = "Level 26, 111 Eagle St, Brisbane QLD 4000, Australia";

        var parsedAddress = PostMaster.ParseAddress(address);
        
        parsedAddress.Should().NotBeNull();
        parsedAddress!.AddressParts.Count.Should().Be(7);
        
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Level, "Level 26");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.HouseNumber, "111");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Road, "Eagle St");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.City, "Brisbane");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.State, "Qld");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Postcode, "4000");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Country, "Australia");
    }
    
    [Fact]
    public void CanParseAddress_NZ_Case_1()
    {
        var address = "4/43 Vogel Street, Roslyn, Palmerston North 4414, NEW ZEALAND";

        var parsedAddress = PostMaster.ParseAddress(address);
        
        parsedAddress.Should().NotBeNull();
        parsedAddress!.AddressParts.Count.Should().Be(6);
        
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.HouseNumber, "4/43");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Road, "Vogel Street");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Suburb, "Roslyn");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.City, "Palmerston North");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Postcode, "4414");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Country, "NEW ZEALAND");
    }
    
    [Fact]
    public void CanParseAddress_NZ_Case_2()
    {
        var address = "97 French Farm Valley Road, RD 2, Akaroa 7582, NEW ZEALAND";

        var parsedAddress = PostMaster.ParseAddress(address);
        
        parsedAddress.Should().NotBeNull();
        parsedAddress!.AddressParts.Count.Should().Be(6);
        
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.HouseNumber, "97");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Road, "French Farm Valley Road");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.RuralDeliveryNumber, "RD 2");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.City, "Akaroa");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Postcode, "7582");
        _fixture.ValidateAddressPart(parsedAddress, AddressLabel.Country, "NEW ZEALAND");
    }
}