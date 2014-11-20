# Persimmon.Demo

This project is sample project using Persimmon.

## How to run tests

### clone this project

```
git clone https://github.com/persimmon-projects/Persimmon.Demo
```

### install Persimmon.Console

```
.\.nuget\NuGet.exe Install Persimmon.Console -Pre -OutputDirectory tools
```

### build Persimmon.Demo

execute this command:

```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Persimmon.Demo.sln /property:Configuration=Debug /property:VisualStudioVersion=12.0 /target:rebuild
```

or use IDE.

### run tests

```
.\tools\Persimmon.Console.1.0.0-beta1\tools\Persimmon.Console.exe .\Persimmon.Demo\bin\Debug\Persimmon.Demo.dll
```
