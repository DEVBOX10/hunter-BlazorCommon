namespace BlazorCommon.RazorLib;

public record ExtensionInitializer(
    string ExtensionDisplayName,
    Func<Task> InitializeAsync);