using System.Threading;

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
var runtime = Argument("runtime", "win-x64");
var configuration = Argument("configuration", "Release");
var version = "1.1.1";

var rootDir = new DirectoryPath("..");
var srcDir = new DirectoryPath("../src");
var artifactsDir = rootDir.Combine("artifacts");

var sln = rootDir.CombineWithFilePath("SteamCMDHub.sln");
var project = srcDir.CombineWithFilePath("SteamCMDHub/SteamCMDHub.csproj");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
        EnsureDirectoryExists(artifactsDir);
        CleanDirectory(artifactsDir);
});

Task("Compile")
    .Does(() => {
        DotNetBuild(sln.FullPath, new DotNetBuildSettings
        {
            Configuration = configuration,
        });
});

Task("Pack")
    .Does(() => {
        DotNetPack(project.FullPath, new DotNetPackSettings {
            OutputDirectory = artifactsDir,
            Configuration = configuration,
            Verbosity = DotNetVerbosity.Minimal
        });
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Compile");


Task("Publish")
    .Does(() => {
        DotNetPublish(sln.FullPath, new DotNetPublishSettings
        {
            Configuration = configuration,
            SelfContained = false,
            Runtime = runtime,
            PublishSingleFile = true,
        });
});


RunTarget(target);