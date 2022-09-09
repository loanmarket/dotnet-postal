#!/usr/bin/env bash
set -euo pipefail

cp -rf libpostaldata tests/LMGTech.DotNetPostal.Nuget.Tests
cp -rf libpostaldata tests/LMGTech.DotNetPostal.Tests
rm -r libpostaldata
rm libpostaldata.zip
