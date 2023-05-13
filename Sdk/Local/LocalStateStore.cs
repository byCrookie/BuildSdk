using System.Text.Json;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Sdk.Local;

public static class LocalStateStore
{
    public static LocalState RetrieveLocalState(TaskLoggingHelper log, string path)
    {
        if (!File.Exists(path))
        {
            log.LogMessage(MessageImportance.High, $"Buildsdk local state file at {path} does not exist, create and write empty state to file.");
            File.WriteAllText(path, JsonSerializer.Serialize(new LocalState()));
        }

        var json = File.ReadAllText(path);
        if (string.IsNullOrEmpty(json))
        {
            log.LogMessage(MessageImportance.High, $"Buildsdk local state file at {path} is empty, write empty state to file.");
            File.WriteAllText(path, JsonSerializer.Serialize(new LocalState()));
        }

        var localState = JsonSerializer.Deserialize<LocalState>(json);
        if (localState is null)
        {
            log.LogError($"Return empty state because deserializing local state failed: {json}.");
            return new LocalState();
        }

        return localState;
    }
    
    public static void SaveLocalState(TaskLoggingHelper log, string path, LocalState state)
    {
        if (!File.Exists(path))
        {
            log.LogMessage(MessageImportance.High, $"Buildsdk local state file at {path} does not exist, create and write state to file.");
            File.WriteAllText(path, JsonSerializer.Serialize(state));
            return;
        }

        File.WriteAllText(path, JsonSerializer.Serialize(state));
    }
}