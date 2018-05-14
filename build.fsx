#r @"packages/build/FAKE/tools/FakeLib.dll"
#r @"packages/build/FAKE.Persimmon/lib/net451/FAKE.Persimmon.dll"
open Fake

let solutionFile  = "Persimmon.Demo.sln"

let testAssemblies = "./tests/**/bin/Release/*Demo*.dll"

Target "CopyBinaries" (fun _ ->
  !! "src/**/*.??proj"
  |>  Seq.map (fun f -> ((System.IO.Path.GetDirectoryName f) @@ "bin/Release", "bin" @@ (System.IO.Path.GetFileNameWithoutExtension f)))
  |>  Seq.iter (fun (fromDir, toDir) -> CopyDir toDir fromDir (fun _ -> true))
)

Target "Clean" (fun _ ->
  CleanDirs ["bin"; "temp"]
)

Target "Restore" (fun _ ->
  DotNetCli.Restore (fun p ->
    { p with
        Project = solutionFile
    }
  )
)

Target "Build" (fun _ ->
  !! solutionFile
  |> MSBuildRelease "" "Rebuild"
  |> ignore
)

Target "RunTests" (fun _ ->
  !! testAssemblies
  |> Persimmon id
)

"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "CopyBinaries"
  ==> "RunTests"

RunTargetOrDefault "RunTests"

