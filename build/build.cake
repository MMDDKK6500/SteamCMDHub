using System.Threading;

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
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
        DotNetCoreBuild(sln.FullPath, new DotNetCoreBuildSettings
        {
            Configuration = configuration,
        });
});

Task("Pack")
    .Does(() => {
        DotNetCorePack(project.FullPath, new DotNetCorePackSettings {
            OutputDirectory = artifactsDir,
            Configuration = configuration,
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Compile");

RunTarget(target);