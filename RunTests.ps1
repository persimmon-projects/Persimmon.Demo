.\.nuget\NuGet.exe Install Persimmon.Console -Pre -OutputDirectory packages -ExcludeVersion

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Persimmon.Demo.sln /property:Configuration=Debug /property:VisualStudioVersion=12.0 /target:rebuild

$inputs = @(
  ".\Persimmon.Demo\bin\Debug\Persimmon.Demo.dll";
  ".\Persimmon.Demo.Poker\bin\Debug\Persimmon.Demo.Poker.dll"
)

.\packages\Persimmon.Console\tools\Persimmon.Console.exe $inputs
