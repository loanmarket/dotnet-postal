#!/usr/bin/env bash
set -euo pipefail

curl -L https://github.com/loanmarket/dotnet-postal/releases/download/dotnet-postal-data-v1.0.0/libpostaldata.zip --output libpostaldata.zip

unzip libpostaldata.zip

cp -rf libpostaldata tests/LMGTech.DotNetPostal.NuGet.Tests
cp -rf libpostaldata tests/LMGTech.DotNetPostal.Tests
rm -r libpostaldata
rm libpostaldata.zip
