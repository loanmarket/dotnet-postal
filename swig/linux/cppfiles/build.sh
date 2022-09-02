#!/usr/bin/env bash
set -euo pipefail

# Copy the header and interface files to this directory
cp ../../libpostal.h .
cp ../../libpostal.i .
# Generate c wrapper and cs interop classes
swig -csharp -dllimport libpostal -outdir ../../../src/DotNetPostal/Generated libpostal.i
# Compile c wrapper 
gcc -c -fpic libpostal_wrap.c
# Build libpostal.so
gcc -Wall -shared -Wl,-rpath='$ORIGIN' libpostal_wrap.o libpostal.so.1 -o libpostal.so
# Copy dynamic library to src folder
cp libpostal.so ../../../src/DotNetPostal
cp libpostal.so.1 ../../../src/DotNetPostal
