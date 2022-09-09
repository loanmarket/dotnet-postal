#!/usr/bin/env bash
set -euo pipefail

libpostalgitdir="$1"

# Copy the header file to this directory
cp $libpostalgitdir/src/libpostal.h .

# Generate c wrapper and cs interop classes
swig -csharp -dllimport libpostal -outdir ../src/LMGTech.DotNetPostal/Generated -o $libpostalgitdir/src/libpostal_wrap.c libpostal.i

# Remove header file
rm libpostal.h

# Adjust libpostal/src/Makefile.am to prepend libpostal_wrap.c to libpostal_la_SOURCES - only if it's not already there
if ! grep -q "libpostal_wrap" $libpostalgitdir/src/Makefile.am; then
  if [[ $OSTYPE == 'darwin'* ]]; then
    sed -i'.backup' 's/libpostal_la_SOURCES = /libpostal_la_SOURCES = libpostal_wrap.c /g' $libpostalgitdir/src/Makefile.am
    rm $libpostalgitdir/src/Makefile.am.backup
  else
    sed -i 's/libpostal_la_SOURCES = /libpostal_la_SOURCES = libpostal_wrap.c /g' $libpostalgitdir/src/Makefile.am
  fi
fi
