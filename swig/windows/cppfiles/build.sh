#!/usr/bin/env bash
set -euo pipefail

# Copy the header and interface files to this directory
cp ../../libpostal.h .
cp ../../libpostal.i .
# Generate c wrapper and cs interop classes
swig -csharp -dllimport libpostal -outdir ../../../src/DotNetPostal/Generated libpostal.i
# Compile c wrapper - IMPORTANT: For Windows do not use -fpic as it is not supported
gcc -c libpostal_wrap.c
# Build libpostal.dll
gcc -Wall -shared libpostal_wrap.o libpostal-1.dll -o libpostal.dll
# Copy dlls to src folder
cp libpostal-1.dll ../../../src/DotNetPostal
cp libpostal.dll ../../../src/DotNetPostal