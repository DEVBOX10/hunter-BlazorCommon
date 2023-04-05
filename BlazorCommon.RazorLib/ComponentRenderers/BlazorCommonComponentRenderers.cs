using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;

namespace BlazorCommon.RazorLib.ComponentRenderers;

public class BlazorCommonComponentRenderers : IBlazorCommonComponentRenderers
{
    public BlazorCommonComponentRenderers(
        Type? backgroundTaskDisplayRendererType,
        Type? booleanPromptOrCancelRendererType,
        Type? errorNotificationRendererType,
        Type? informativeNotificationRendererType,
        Type? treeViewExceptionRendererType,
        Type? treeViewMissingRendererFallbackType,
        IWatchWindowTreeViewRenderers? watchWindowTreeViewRenderers)
    {
        BackgroundTaskDisplayRendererType = backgroundTaskDisplayRendererType;
        BooleanPromptOrCancelRendererType = booleanPromptOrCancelRendererType;
        ErrorNotificationRendererType = errorNotificationRendererType;
        InformativeNotificationRendererType = informativeNotificationRendererType;
        TreeViewExceptionRendererType = treeViewExceptionRendererType;
        TreeViewMissingRendererFallbackType = treeViewMissingRendererFallbackType;
        WatchWindowTreeViewRenderers = watchWindowTreeViewRenderers;
    }

    public Type? BackgroundTaskDisplayRendererType { get; }
    public Type? BooleanPromptOrCancelRendererType { get; }
    public Type? ErrorNotificationRendererType { get; }
    public Type? InformativeNotificationRendererType { get; }
    public Type? TreeViewExceptionRendererType { get; }
    public Type? TreeViewMissingRendererFallbackType { get; }
    public IWatchWindowTreeViewRenderers? WatchWindowTreeViewRenderers { get; }
}