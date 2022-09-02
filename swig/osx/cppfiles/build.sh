#!/usr/bin/env bash
set -euo pipefail

# Copy the header and interface files to this directory
cp ../../libpostal.h .
cp ../../libpostal.i .
# Generate c wrapper and cs interop classes
swig -csharp -dllimport libpostal -outdir ../../../src/DotNetPostal/Generated libpostal.i
# Compile c wrapper 
gcc -c libpostal_wrap.c
# Override the install ID for libpostal.1.dylib
install_name_tool -id libpostal.1.dylib libpostal.1.dylib
# Build libpostal.dylib
gcc -Wall -dynamiclib libpostal_wrap.o libpostal.1.dylib -o libpostal.dylib
# Copy dynamic library to src folder
cp libpostal.dylib ../../../src/DotNetPostal
cp libpostal.1.dylib ../../../src/DotNetPostal
