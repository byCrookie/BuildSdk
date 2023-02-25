using Microsoft.Build.Framework;
using Task = Microsoft.Build.Utilities.Task;

namespace Sdk.Local.Prerelease;

public class PrereleaseVersionTask : Task
{
    [Required]
    public string LocalPrereleaseVersionFilePath { get; set; } = ".buildsdk.local";
    
    [Output]
    public int OriginalPrereleaseCounter { get; set; }
    
    [Output]
    public int PrereleaseCounter { get; set; }

    public override bool Execute()
    {
        var localState = LocalStateProvider.RetrieveLocalState(Log, LocalPrereleaseVersionFilePath);
        Log.LogMessage(MessageImportance.High, $"increment PrereleaseCounter in local state file at {LocalPrereleaseVersionFilePath}");
        OriginalPrereleaseCounter = localState.PreleaseCounter;
        PrereleaseCounter = localState.PreleaseCounter + 1;
        return true;
    }
}