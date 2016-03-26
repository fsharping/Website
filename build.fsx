// include Fake lib
#I "packages/FAKE/tools/"
#r "FakeLib.dll"

open System
open System.IO
open Fake 
open Fake.AssemblyInfoFile
open System.Diagnostics

let title = "FSharping.Website"
let project = "FSharping Website"
let summary = "Website source for fsharping.cz"

// Directories
let buildAppDir = "./build/app/"
let buildTestDir = "./build/tests/"
let appSrcDir = sprintf "./src/%s/" title
let testSrcDir = sprintf "./tests/%s.Tests/" title

// Read release notes & version info from RELEASE_NOTES.md
let release = File.ReadLines "RELEASE_NOTES.md" |> ReleaseNotesHelper.parseReleaseNotes

// Targets
Target "?" (fun _ ->
    printfn " *********************************************************"
    printfn " *        Avaliable options (call 'build <Target>')      *"
    printfn " *********************************************************"
    printfn " [Build]"
    printfn "  > BuildTests"
    printfn "  > BuildApp"
    printfn " "
    printfn " [Run]"
    printfn "  > RunTests"
    printfn "  > RunApp"
    printfn "  > RunAppWatcher"
    printfn " "
    printfn " [Help]"
    printfn "  > ?"
    printfn " "
    printfn " *********************************************************"
)

Target "AssemblyInfo" <| fun () ->
    for file in !! (appSrcDir + "AssemblyInfo*.fs") do
        let version = release.AssemblyVersion
        CreateFSharpAssemblyInfo file
           [ Attribute.Title title
             Attribute.Product project
             Attribute.Description summary
             Attribute.Version version
             Attribute.FileVersion version]

Target "CleanApp" (fun _ ->
    CleanDir buildAppDir
)

Target "CleanTests" (fun _ ->
    CleanDir buildAppDir
)

Target "PreBuildWww" (fun _ ->
    let npm = tryFindFileOnPath (if isUnix then "npm" else "npm.cmd")
    let errorCode = match npm with
                      | Some g -> Shell.Exec(g, "install", appSrcDir)
                      | None -> -1
    ()
)

Target "BuildWww" (fun _ ->
    let gulp = tryFindFileOnPath (if isUnix then "npm" else "npm.cmd")
    let errorCode = match gulp with
                      | Some g -> Shell.Exec(g, "run gulp", appSrcDir)
                      | None -> -1
    ()
)

Target "BuildApp" (fun _ ->
    !! (appSrcDir + "**/*.fsproj")
    |> MSBuildRelease buildAppDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTests" (fun _ ->
    !! (testSrcDir + "**/*.fsproj")
      |> MSBuildDebug buildTestDir "Build"
      |> Log "TestBuild-Output: "
)

Target "RunTests" (fun _ ->
    !! (buildTestDir + sprintf "/%s.Tests.dll" title)
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = buildTestDir + "TestResults.xml" })
)

let runApp() = 
    execProcess (fun info -> 
        info.WorkingDirectory <- buildAppDir
        info.FileName <- Path.Combine(buildAppDir, sprintf "%s.exe" title)
        info.Arguments <- "") TimeSpan.MaxValue
    

let rec runAppWithWatcher() =
    use watcher = new FileSystemWatcher(appSrcDir, "*.*")
    watcher.EnableRaisingEvents <- true
    watcher.IncludeSubdirectories <- true
    watcher.Changed.Add(handleWatcherEvents)
    watcher.Created.Add(handleWatcherEvents)
    watcher.Renamed.Add(handleWatcherEvents)
   
    let appRunning = runApp()    
    if not appRunning then tracefn "Application shut down."
    watcher.Dispose()

and handleWatcherEvents (e:IO.FileSystemEventArgs) =
    
    let killProcess = (fun _ -> Process.GetProcessesByName(title) |> Seq.iter (fun p -> p.Kill()))

    match Path.GetExtension e.Name with
    | ".fs" | ".fsx" -> 
        killProcess()
        runSingleTarget (getTarget "BuildApp")
        runAppWithWatcher()

    | ".html" | ".js" | ".css" | ".json" | ".less" | ".md" -> 
        killProcess()
        runSingleTarget (getTarget "BuildWww")
        runAppWithWatcher()
    | ".fsproj" -> ignore()
    | _ -> ignore()

Target "RunApp" (fun _ ->
    runApp() |> ignore
)    

Target "RunAppWatcher" (fun _ ->
    runAppWithWatcher()
)

// Dependencies
"PreBuildWww" ==> "BuildWww"
"CleanTests" ==> "BuildTests"
"CleanApp" ==> "AssemblyInfo" ==> "BuildWww" ==> "BuildApp"
"BuildApp"  ==> "BuildTests"  ==> "RunTests"
"BuildApp" ==> "RunApp"
"BuildApp" ==> "RunAppWatcher"

// start build
RunTargetOrDefault "?"