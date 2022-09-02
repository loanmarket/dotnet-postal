# Building libpostal on Linux (Ubuntu/Debian)

## Prerequisites

1. Install the following packages
   1. `sudo apt-get install curl autoconf automake libtool pkg-config git`
   2. `sudo apt-get install swig`

## Building libpostal

1. Open your preferred terminal
2. Follow the [Linux build instructions for libpostal](https://github.com/openvenues/libpostal#installation-maclinux)
    1. Note: You don't need to do the final step `make install` i.e. you don't need to install the library on the machine as we only need the shared object file
    2. In the following steps it's assumed you cloned the libpostal git repo into a folder called `libpostal`
3. Copy the following files to the `swig/linux/cppfiles` folder in this repo
    1. `libpostal/src/.libs/libpostal.so.1.0.1` and rename to `libpostal.so.1`
4. Copy the following file to the `swig/` folder in this repo
    1. `libpostal/src/libpostal.h`
5. Copy the contents of the configured libpostal `--datadir` to `/src/DotNetPostal/libpostaldata/`
    1. This directory is configured as part of the libpostal build process and is auto-populated with ML model data during the libpostal build process
6. In the terminal, navigate to the `swig/linux/cppfiles` directory in this repository
7. Run `./build.sh`, which will:
    1. Generate and compile the C wrapper file `libpostal_wrap.c`
    2. Build the shared library `libpostal.so`
    3. Copy `libpostal.so` and `libpostal.so.1` to `/src/DotNetPostal`
    4. Copy all generated C# files to  `/src/DotNetPostal/Generated`

## Further reading

* https://www.swig.org/ - generates a C wrapper around a native library and corresponding C# p/Invoke methods and classes to call this wrapper
* https://www.msys2.org/docs/environments/ - SWIG environments, especially why UCRT is preferred for Windows10+
* https://iamsorush.com/posts/cpp-csharp-swig/ - nice example of using SWIG with CMAKE
* https://olegtarasov.me/build-cross-platform-c-library/ - example cross-platform C library called from .NET
