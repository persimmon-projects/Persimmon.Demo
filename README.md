# Persimmon.Demo

[![Build status](https://ci.appveyor.com/api/projects/status/1xwm1wkdwq65xgwx/branch/master?svg=true)](https://ci.appveyor.com/project/pocketberserker/persimmon-demo/branch/master)

This project is sample project using Persimmon.

## How to run tests

Install Paket, FAKE, FAKE.Persimmon, and other dependency libraries:

```
./.paket.bootstrap.exe
./.paket.exe restore
```

and run:

```
packages/build/FAKE/tools/FAKE.exe build.fsx
```

## Contributors

The poker example was implemented by @nenono and @bleis-tift.
