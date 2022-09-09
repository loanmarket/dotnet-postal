# LMGTech.DotNetPostal

This project wraps the [libpostal](https://github.com/openvenues/libpostal) C library and provides a more natural .NET experience over the generic p/Invoke DllImport mechnism. It relies on [SWIG](https://www.swig.org) to do the heavy lifting for auto-generating p/Invoke calls to platform-specific libraries.

Things to note:

* .NET 6.0 only
* 64-bit OS only
* Supports Windows/MacOS/Linux
    * For Windows it requires Universal C Runtime - this is present for Windows 10+ but needs to be installed manually for editions of Windows prior to 10
* Currently does not support ARM
* To use this library you also need the libpostal trained model data
    * Trained binary data is ~2GB (uncompressed) in size and can't be included in the package due to nuget file size limitations

## Installing LMGTech.DotNetPostal

It's likely you've already done the first step by adding the LMGTech.DotNetPostal package to project in your solution. If so, skip that step.

1. Add the `LMGTech.DotNetPostal` nuget package to a project in your solution by either using your IDE package manager, or running `dotnet add package LMGTech.DotNetPostal` from the command prompt in your project's csproj directory
   1. During installation your project's csproj file is updated with:
      1. Information about how to include OS-specific native binaries for libpostal and rules to copy them during build
      2. Information about how to include the `libpostaldata` directory and how to copy the contents during build
2. Download the libpostal trained model data from https://github.com/loanmarket/dotnet-postal/releases/download/dotnet-postal-data-v1.0.0/libpostaldata.zip ~800MB compressed
3. Extract the zipped file into the root directory of the project where you installed LMGTech.DotNetPostal
   1. This should create a folder called `libpostaldata` with the contents containing the trained model data
4. You should now be able to build your project and have the LMGTech.DotNetPostal.dll and trained model data copied to the bin folder

## Using LMGTech.DotNetPostal

Before using any of the features of LMGTech.DotNetPostal you first need to run the setup process for libpostal. This is a time-consuming activity ~O(seconds) and should be done once per running process, typically during startup of the executable.
Similarly, during shutdown of the process or when you are done using LMGTech.DotNetPostal.dll you need to run the tear down process.

A simple .NET console app might look like this

```csharp
using LMGTech.DotNetPostal;

// Setup libpostal
PostMaster.Setup();

// Parse and address
var parsedAddress = PostMaster.ParseAddress("Level 26, 111 Eagle St, Brisbane QLD 4000, Australia");

// Tear down
PostMaster.TearDown();
```

When using LMGTech.DotNetPostal in ASP.NET web hosts you should perform the setup and tear down tasks in a background worker that is registered for startup and shutdown events.