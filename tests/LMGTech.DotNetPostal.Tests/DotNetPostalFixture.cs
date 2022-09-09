using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using FluentAssertions;
using LMGTech.DotNetPostal.Models;

namespace LMGTech.DotNetPostal.Tests;

public class DotNetPostalFixture : IDisposable
{
    public DotNetPostalFixture()
    {
        // This is needed because of this -> https://github.com/dotnet/sdk/issues/10575
        // This is NOT needed when adding the package via nuget
        AssemblyLoadContext.Default.ResolvingUnmanagedDll += (assembly, name) =>
        {
            var rid = "win-x64";
            var ext = "dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                rid = "linux-x64";
                ext = "so";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                rid = "osx-x64";
                ext = "dylib";
            }
            
            NativeLibrary.TryLoad($"runtimes/{rid}/native/{name}.{ext}", out var handle);
            return handle;
        };
        
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