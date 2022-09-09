# LMGTech.DotNetPostal

.NET bindings for [libpostal](https://github.com/openvenues/libpostal)

## Overview

This project wraps the libpostal C library and provides a more natural .NET experience over the generic p/Invoke DllImport mechanism. It relies on [SWIG](https://www.swig.org) to do the heavy lifting for auto-generating p/Invoke calls to platform-specific libraries.

Things to note:

* 64-bit OS only
* Supports Windows/MacOS/Linux
  * For Windows it requires Universal C Runtime - this is present for Windows 10+ but needs to be installed manually for editions of Windows prior to 10
* Currently does not support ARM
* To use this library you need the libpostal trained data - that can't be included in the repo due to github repo file size limitations
  * A solution for obtaining this data will be delivered soon...watch this space!

## Building

Compiled native libraries for libpostal for Windows/MacOS/Linux with SWIG wrapper entry points are included in this repo. To build simply open the solution and build.

During build a nuget package is created and placed in `/package-feed`

LMGTech.DotNetPostal.Tests use a project reference to LMGTech.DotNetPostal - some trickery is required to allow the tests to load the native libraries on each supported runtime.

## Building Native Libraries

_Note: This is only needed when libpostal is updated - normally not required to just build this repository if you're only adding features to DotNetPostal._

Follow the platform-specific native build instructions below.

In the following steps it's assumed that:

1. You cloned the libpostal git repo into a folder located at `{libpostal-path}`
2. This repo is cloned into a folder located at `{dotnet-postal-path}`

### Linux (Ubuntu/Debian)

#### Linux - Prerequisites

1. Install the following packages
   1. `sudo apt-get install curl autoconf automake libtool pkg-config git`
   2. `sudo apt-get install swig`

#### Linux - Building libpostal

1. Open your preferred terminal at `{dotnet-postal-path}/swig`
2. Run `./generate_swig_files.sh {libpostal-path}` - e.g. `./generate_swig_files.sh ~/github/libpostal`
   1. Creates a `{libpostal-path}/src/libpostal_wrap.c` wrapper C file
   2. Generates C# p/Invoke code at `{dotnet-postal-path}/src/LMGTech.DotNetPostal/Generated`
   3. Includes `libpostal_wrap.c` in `{libpostal-path}/src/Makefile.am` to ensure it is built when building libpostal
3. Follow the [Linux build instructions for libpostal](https://github.com/openvenues/libpostal#installation-maclinux)
    1. Note: You don't need to do the final step `make install` i.e. you don't need to install the library on the machine as we only need the shared library file
    2. You need to make a note of the configured `--datadir` that you specified during the build of libpostal - this directory is configured as part of the libpostal build process and is auto-populated with ML model data during the libpostal build process
4. Open your preferred terminal at `{dotnet-postal-path}/swig`
5. Run `./copy_libpostal_library.sh {libpostal-path}` - e.g. `./copy_libpostal_library.sh ~/github/libpostal`
   1. Copies the relevant platform-specific shared library to the platform-specific area under `{dotnet-postal-path}/src/LMGTech.DotNetPostal/runtimes`
6. Copy the contents of the configured libpostal `--datadir` to the following places:
   1. `/tests/LMGTech.DotNetPostal.Tests/libpostaldata/`
   2. `/tests/LMGTech.DotNetPostal.NuGet.Tests/libpostaldata/`

### MacOS

#### MacOS - Prerequisites

1. Install [Homebrew](https://brew.sh/)
2. Install the following Homebrew packages
   1. `brew install curl autoconf automake libtool pkg-config`
   2. `brew install swig`

#### MacOS - Building libpostal

1. Open your preferred terminal at `{dotnet-postal-path}/swig`
2. Run `./generate_swig_files.sh {libpostal-path}` - e.g. `./generate_swig_files.sh ~/github/libpostal`
   1. Creates a `{libpostal-path}/src/libpostal_wrap.c` wrapper C file
   2. Generates C# p/Invoke code at `{dotnet-postal-path}/src/LMGTech.DotNetPostal/Generated`
   3. Includes `libpostal_wrap.c` in `{libpostal-path}/src/Makefile.am` to ensure it is built when building libpostal
3. Follow the [Linux build instructions for libpostal](https://github.com/openvenues/libpostal#installation-maclinux)
    1. Note: You don't need to do the final step `make install` i.e. you don't need to install the library on the machine as we only need the shared library file
    2. You need to make a note of the configured `--datadir` that you specified during the build of libpostal - this directory is configured as part of the libpostal build process and is auto-populated with ML model data during the libpostal build process
4. Open your preferred terminal at `{dotnet-postal-path}/swig`
5. Run `./copy_libpostal_library.sh {libpostal-path}` - e.g. `./copy_libpostal_library.sh ~/github/libpostal`
   1. Copies the relevant platform-specific shared library to the platform-specific area under `{dotnet-postal-path}/src/LMGTech.DotNetPostal/runtimes`
6. Copy the contents of the configured libpostal `--datadir` to the following places:
   1. `/tests/LMGTech.DotNetPostal.Tests/libpostaldata/`
   2. `/tests/LMGTech.DotNetPostal.NuGet.Tests/libpostaldata/`

### Windows

#### Windows - Prerequisites

1. Install [MSYS2](https://www.msys2.org/)
2. Open MSYS2 by running `MSYS2 MSYS` from the Start menu (note that there a multiple options here so choose the correct one!)
3. Run the following to install common tools - `pacman -S autoconf automake curl git make libtool`
4. Close the `MSYS2 MSYS` terminal
5. Open MSYS2 by running `MSYS2 MinGW UCRT x64` from the Start menu (note we are now using UCRT!)
6. Install the following tools
    1. gcc: `pacman -S mingw-w64-ucrt-x86_64-gcc`
    2. SWIG: `pacman -S mingw-w64-ucrt-x86_64-swig`

#### Windows - Building libpostal

1. Open MSYS2 by running `MSYS2 MinGW UCRT x64` from the Start menu
2. Navigate to `{dotnet-postal-path}/swig`
3. Run `./generate_swig_files.sh {libpostal-path}` - e.g. `./generate_swig_files.sh ~/github/libpostal`
   1. Creates a `{libpostal-path}/src/libpostal_wrap.c` wrapper C file
   2. Generates C# p/Invoke code at `{dotnet-postal-path}/src/LMGTech.DotNetPostal/Generated`
   3. Includes `libpostal_wrap.c` in `{libpostal-path}/src/Makefile.am` to ensure it is built when building libpostal
4. Follow the [Windows build instructions for libpostal](https://github.com/openvenues/libpostal#installation-windows)
    1. Note: You don't need to do the final step `make install` i.e. you don't need to install the library on the machine as we only need the DLL file
    2. You need to make a note of the configured `--datadir` that you specified during the build of libpostal - this directory is configured as part of the libpostal build process and is auto-populated with ML model data during the libpostal build process
5. Open an `MSYS2 MinGW UCRT x64` terminal at `{dotnet-postal-path}/swig`
6. Run `./copy_libpostal_library.sh {libpostal-path}` - e.g. `./copy_libpostal_library.sh ~/github/libpostal`
   1. Copies the relevant platform-specific shared library to the platform-specific area under `{dotnet-postal-path}/src/LMGTech.DotNetPostal/runtimes`
7. Copy the contents of the configured libpostal `--datadir` to the following places:
   1. `/tests/LMGTech.DotNetPostal.Tests/libpostaldata/`
   2. `/tests/LMGTech.DotNetPostal.NuGet.Tests/libpostaldata/`

## Further reading

* https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform
* https://www.msys2.org/ - tools for C/C++ native builds on Windows
* https://www.swig.org/ - generates a C wrapper around a native library and corresponding C# p/Invoke methods and classes to call this wrapper
* https://www.msys2.org/docs/environments/ - SWIG environments, especially why UCRT is preferred for Windows10+
* https://iamsorush.com/posts/cpp-csharp-swig/ - nice example of using SWIG with CMAKE
* https://olegtarasov.me/build-cross-platform-c-library/ - example cross-platform C library called from .NET
* https://itwenty.me/2020/07/understanding-dyld-executable_path-loader_path-and-rpath/ - how dynamic library loading works on MacOS
* https://jacobpan3g.github.io/2017/09/01/build-dylib-on-mac/ - Cheat sheet for dynamic lib adjustments on MacOS
* https://github.com/dotnet/sdk/issues/10575
