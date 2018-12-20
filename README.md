# Dommunity [![Build Status](https://travis-ci.org/dommunity/dommunity.svg?branch=master)](https://travis-ci.org/dommunity/dommunity)

Dommunity is a set of C# libraries for accessing Dommunity network. It contain only Dommunity specific code without any platform-specific code.

## Prerequisites

- .NET Core 2.2.0

## Build instructions

Build:

```sh
dotnet restore src/Dommunity.sln
dotnet build src/Dommunity.sln
```

Run unit tests:

```sh
dotnet test src/*.Tests
```
