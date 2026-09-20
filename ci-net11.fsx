#!/usr/bin/env -S dotnet fsi
// ci-net11.fsx — THIS SCRIPT IS THE CI PIPELINE for the fork's .NET 11 support.
// GitHub Actions (.github/workflows/net11.yml) only installs the SDKs and calls this; run the same thing locally:
//
//   dotnet fsi ci-net11.fsx
//
// It builds MonoMod.RuntimeDetour and hooks a method (then undoes it) on .NET 10 and on the newest installed
// .NET 11 runtime. It also runs weekly, because a newer .NET 11 RC/GA can change the JIT-EE GUID or vtable layout
// and silently break detours; a red weekly run is the signal to regenerate the layout.

#r "nuget: Fun.Build, 1.2.0"

open Fun.Build

let probeDll = "artifacts/bin/net11-probe/release/net11-probe.dll"

pipeline "net11 canary" {
  description "MonoMod detours must work on .NET 10 and the newest .NET 11 runtime"

  stage "build probe" {
    workingDir __SOURCE_DIRECTORY__
    run "dotnet build build/net11-probe -c Release"
  }

  stage "hook on .NET 10" {
    workingDir __SOURCE_DIRECTORY__
    run $"dotnet {probeDll} 10"
  }

  stage "hook on newest .NET 11" {
    workingDir __SOURCE_DIRECTORY__
    envVars [ "DOTNET_ROLL_FORWARD", "LatestMajor"; "DOTNET_ROLL_FORWARD_TO_PRERELEASE", "1" ]
    run $"dotnet {probeDll} 11"
  }

  runIfOnlySpecified false
}
