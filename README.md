# Persimmon.Demo

This project is sample project using Persimmon.

## How to run tests

### clone this project

```
git clone https://github.com/persimmon-projects/Persimmon.Demo
```

### install Persimmon.Console

```
.\.nuget\NuGet.exe Install Persimmon.Console -Pre -OutputDirectory tools -ExcludeVersion
```

### build Persimmon.Demo

execute this command:

```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Persimmon.Demo.sln /property:Configuration=Debug /property:VisualStudioVersion=12.0 /target:rebuild
```

or use IDE.

### run tests

```
.\tools\Persimmon.Console\tools\Persimmon.Console.exe .\Persimmon.Demo\bin\Debug\Persimmon.Demo.dll
```

## use FAKE

Install FAKE, FAKE.Persimmon, and other dependency libraries

```
.\.nuget\NuGet.exe Install FAKE -Version 4.1.0 -OutputDirectory packages -ExcludeVersion
.\.nuget\NuGet.exe Install FAKE.Persimmon -Pre -Version 1.0.0-beta3 -OutputDirectory packages -ExcludeVersion
.\.nuget\NuGet.exe Install Persimmon.Console -Pre -OutputDirectory tools -ExcludeVersion
.\.nuget\NuGet.exe restore Persimmon.Demo.sln
```

and run.

```
packages/FAKE/tools/FAKE.exe build.fsx
```

## Contributors

The poker example was implemented by @nenono and @bleis-tift.
