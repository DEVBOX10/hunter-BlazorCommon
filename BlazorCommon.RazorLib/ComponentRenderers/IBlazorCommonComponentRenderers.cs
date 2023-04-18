using BlazorCommon.RazorLib.WatchWindow;

namespace BlazorCommon.RazorLib.ComponentRenderers;

public interface IBlazorCommonComponentRenderers
{
    public Type? BackgroundTaskDisplayRendererType { get; }
    public Type? ErrorNotificationRendererType { get; }
    public Type? InformativeNotificationRendererType { get; }
    public Type? TreeViewExceptionRendererType { get; }
    public Type? TreeViewMissingRendererFallbackType { get; }
    public IWatchWindowTreeViewRenderers? WatchWindowTreeViewRenderers { get; }
}