using BlazorCommon.RazorLib.WatchWindow;

namespace BlazorCommon.RazorLib.ComponentRenderers;

public class BlazorCommonComponentRenderers : IBlazorCommonComponentRenderers
{
    public BlazorCommonComponentRenderers(
        Type? backgroundTaskDisplayRendererType,
        Type? errorNotificationRendererType,
        Type? informativeNotificationRendererType,
        Type? treeViewExceptionRendererType,
        Type? treeViewMissingRendererFallbackType,
        IWatchWindowTreeViewRenderers? watchWindowTreeViewRenderers)
    {
        BackgroundTaskDisplayRendererType = backgroundTaskDisplayRendererType;
        ErrorNotificationRendererType = errorNotificationRendererType;
        InformativeNotificationRendererType = informativeNotificationRendererType;
        TreeViewExceptionRendererType = treeViewExceptionRendererType;
        TreeViewMissingRendererFallbackType = treeViewMissingRendererFallbackType;
        WatchWindowTreeViewRenderers = watchWindowTreeViewRenderers;
    }

    public Type? BackgroundTaskDisplayRendererType { get; }
    public Type? ErrorNotificationRendererType { get; }
    public Type? InformativeNotificationRendererType { get; }
    public Type? TreeViewExceptionRendererType { get; }
    public Type? TreeViewMissingRendererFallbackType { get; }
    public IWatchWindowTreeViewRenderers? WatchWindowTreeViewRenderers { get; }
}