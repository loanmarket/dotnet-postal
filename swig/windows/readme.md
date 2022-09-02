# Building libpostal on Windows

## Prerequisites

1. Install [MSYS2](https://www.msys2.org/)
2. Open MSYS2 by running `MSYS2 MSYS` from the Start menu (note that there a multiple options here so choose the correct one!)
3. Run the folllowing to install common tools - `pacman -S autoconf automake curl git make libtool`
4. Close the `MSYS2 MSYS` terminal
5. Open MSYS2 by running `MSYS2 MinGW UCRT x64` from the Start menu (note we are now using UCRT!)
6. Install the following tools
    1. gcc: `pacman -S mingw-w64-ucrt-x86_64-gcc`
    2. SWIG: `pacman -S mingw-w64-ucrt-x86_64-swig`

## Building libpostal

1. Open MSYS2 by running `MSYS2 MinGW UCRT x64` from the Start menu
2. Follow the [Windows build instructions for libpostal](https://github.com/openvenues/libpostal#installation-windows)
    1. Note: You don't need to do the final step `make install` i.e. you don't need to install the library on the machine as we only need the DLL file
    2. In the following steps it's assumed you cloned the libpostal git repo into a folder called `libpostal`
3. Copy the following file to the `swig/windows/cppfiles/` folder in this repo
    1. `libpostal/src/.libs/libpostal-1.dll`
4. Copy the following file to the `swig/` folder in this repo
    1. `libpostal/src/libpostal.h`
5. Copy the contents of the configured libpostal `--datadir` to `/src/DotNetPostal/libpostaldata/`
    1. This directory is configured as part of the libpostal build process and is auto-populated with trained ML model data during the libpostal build process
6. In the `MSYS2 MinGW UCRT x64` terminal, navigate to the `swig/windows/cppfiles` directory in this repository
7. Run `./build.sh`, which will:
    1. Generate and compile the C wrapper file `libpostal_wrap.c`
    2. Build the shared library `libpostal.dll`
    3. Copy `libpostal.dll` and `libpostal-1.dll` to `/src/DotNetPostal`
    4. Copy all generated C# files to  `/src/DotNetPostal/Generated`

## Further reading

* https://docs.microsoft.com/en-us/dotnet/standard/native-interop/cross-platform
* https://www.msys2.org/ - tools for C/C++ native builds on Windows
* https://www.swig.org/ - generates a C wrapper around a native library and corresponding C# p/Invoke methods and classes to call this wrapper
* https://www.msys2.org/docs/environments/ - SWIG environments, especially why UCRT is preferred for Windows10+
* https://iamsorush.com/posts/cpp-csharp-swig/ - nice example of using SWIG with CMAKE
* https://olegtarasov.me/build-cross-platform-c-library/ - example cross-platform C library called from .NET

