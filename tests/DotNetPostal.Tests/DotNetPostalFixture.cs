using System;
using System.Linq;
using DotNetPostal.Models;
using FluentAssertions;

namespace DotNetPostal.Tests;

public class DotNetPostalFixture : IDisposable
{
    public DotNetPostalFixture()
    {
        PostMaster.Setup();
    }
    
    public void Dispose()
    {
        PostMaster.TearDown();
    }
    
    public void ValidateAddressPart(Address address, AddressLabel label, string value)
    {
        var part = GetAddressPart(address, label);

        part.Should().NotBeNull();
        part!.Value.Should().BeEquivalentTo(value);
    }

    private AddressPart? GetAddressPart(Address address, AddressLabel label)
    {
        return address.AddressParts.SingleOrDefault(o => o.Label == label);
    }
}