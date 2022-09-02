# DotNetPostal
.NET bindings for [libpostal](https://github.com/openvenues/libpostal)

## Overview

This project wraps the libpostal C library and provides a more natural .NET experience over the generic p/Invoke DllImport mechnism. It relies on [SWIG](https://www.swig.org) to do the heavy lifting for auto-generating p/Invoke calls to platform-specific libraries.

Things to note:

* 64-bit OS only
* Supports Windows/MacOS/Linux
  * For Windows it requires Universal C Runtime - this is present for Windows 10+ but needs to be installed manually for editions of Windows prior to 10
* Currently does not support ARM
  * Possible to add this through a PR though...

## Building native libraries

_Note: This is only needed when libpostal is updated - normally not required to just build this repository if you're only adding features to DotNetPostal._

Follow the platform-specific native build instructions

* [Windows](./swig/windows/readme.md)
* [MacOS](./swig/osx/readme.md)
* [Linux](./swig/linux/readme.md)



