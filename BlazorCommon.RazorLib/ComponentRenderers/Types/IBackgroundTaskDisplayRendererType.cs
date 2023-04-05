using BlazorCommon.RazorLib.BackgroundTaskCase;

namespace BlazorCommon.RazorLib.ComponentRenderers.Types;

public interface IBackgroundTaskDisplayRendererType
{
    public IBackgroundTask BackgroundTask { get; set; }
}