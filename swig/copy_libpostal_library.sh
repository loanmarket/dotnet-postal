#!/usr/bin/env bash
set -euo pipefail

libpostalgitdir="$1"

if [[ $OSTYPE == 'darwin'* ]]; then
  cp $libpostalgitdir/src/.libs/libpostal.1.dylib ../src/LMGTech.DotNetPostal/runtimes/osx-x64/native/libpostal.dylib
elif [[ $OSTYPE == 'msys'* ]]; then
  cp $libpostalgitdir/src/.libs/libpostal-1.dll ../src/LMGTech.DotNetPostal/runtimes/win-x64/native/libpostal.dll
else
  cp $libpostalgitdir/src/.libs/libpostal.so.1 ../src/LMGTech.DotNetPostal/runtimes/linux-x64/native/libpostal.so
fi
