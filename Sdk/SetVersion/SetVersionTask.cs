using Microsoft.Build.Framework;
using Task = Microsoft.Build.Utilities.Task;

namespace Sdk.SetVersion;

public class SetVersionTask : Task
{
    [Required]
    public string Configuration { get; set; } = "Release";
    
    [Required]
    public int PrereleaseCounter { get; set; }
    
    [Required]
    public int MajorVersion { get; set; } = 1;
    
    [Required]
    public int MinorVersion { get; set; }
    
    [Required]
    [Output]
    public int PatchVersion { get; set; }

    [Output]
    public string? VersionPrefix { get; set; }
    
    [Required]
    [Output]
    public string? VersionSuffix { get; set; }
    
    [Output]
    public string? PackageVersion { get; set; }

    public override bool Execute()
    {
        if (IsDebug())
        {
            PatchVersion += 1;
        }
        
        Log.LogMessage(MessageImportance.High, $"Use VersionPrefix: {VersionPrefix}");
        VersionPrefix = $"{MajorVersion}.{MinorVersion}.{PackageVersion}";

        if (string.IsNullOrEmpty(VersionSuffix))
        {
            var now = DateTime.Now;
            var suffix = $"pre-{now:yyyyMMddhhmm}-{PrereleaseCounter}";
            VersionSuffix = suffix;
            Log.LogMessage(MessageImportance.High, $"VersionSuffix is empty, use {VersionSuffix}");
        }

        if (IsDebug())
        {
            PackageVersion = $"{VersionPrefix}-{VersionSuffix}";
            Log.LogMessage(MessageImportance.High, $"Use PackageVersion for Debug: {PackageVersion}");
        } else if (IsRelease())
        {
            PackageVersion = VersionPrefix;
            Log.LogMessage(MessageImportance.High, $"Use PackageVersion for Release: {PackageVersion}");
        }

        return true;
    }

    private bool IsDebug()
    {
        return Configuration == "Debug";
    }
    
    private bool IsRelease()
    {
        return Configuration == "Release";
    }
}