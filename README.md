# Persimmon.Demo

[![Build status](https://ci.appveyor.com/api/projects/status/1xwm1wkdwq65xgwx/branch/master?svg=true)](https://ci.appveyor.com/project/pocketberserker/persimmon-demo/branch/master)

This project is sample project using Persimmon.

## How to run tests

### clone this project

```
git clone https://github.com/persimmon-projects/Persimmon.Demo
```

### install Persimmon.Console

```
.\.nuget\NuGet.exe Install Persimmon.Console -OutputDirectory packages -ExcludeVersion
```

### build Persimmon.Demo

execute this command:

```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Persimmon.Demo.sln /property:Configuration=Debug /property:VisualStudioVersion=12.0 /target:rebuild
```

or use IDE.

### run tests

```
.\tools\Persimmon.Console\packages\Persimmon.Console.exe .\Persimmon.Demo\bin\Debug\Persimmon.Demo.dll
```

## use FAKE

Install FAKE, FAKE.Persimmon, and other dependency libraries

```
.\.nuget\NuGet.exe Install FAKE -OutputDirectory packages -ExcludeVersion
.\.nuget\NuGet.exe Install FAKE.Persimmon -OutputDirectory packages -ExcludeVersion
.\.nuget\NuGet.exe Install Persimmon.Console -OutputDirectory packages -ExcludeVersion
.\.nuget\NuGet.exe restore Persimmon.Demo.sln
```

and run.

```
packages/FAKE/tools/FAKE.exe build.fsx
```

## Contributors

The poker example was implemented by @nenono and @bleis-tift.
