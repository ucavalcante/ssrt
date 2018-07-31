# ssrt - (Script Space Remove Tool) - A tool for remove not used spaces from asl script.

This tool remove some whitespaces inserted unecessary in validation process from script develop.

Covered extensions: **".ags"** || **".agm"**

To use this you have to have at least .NET Core 2.1,
which has global tools.

To download it, go [here](https://www.microsoft.com/net/download)
and install **the .NET Core SDK**. Don't install the
runtime, as it will not be enough to run global tools.

## Synopsis

```bash
ssrt -d <directory>
```

For current direcory
```bash
ssrt .
```

## Install


```bash
dotnet tool install -g ssrt
```

## Maintainers/Core team

* [@uCavalcante7](https://twitter.com/uCavalcante7)