namespace BlazorCommon.RazorLib.TreeView.TreeViewClasses;

public record TreeViewRenderer(
    Type DynamicComponentType,
    Dictionary<string, object?> DynamicComponentParameters);