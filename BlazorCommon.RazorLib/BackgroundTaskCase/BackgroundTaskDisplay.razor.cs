using BlazorCommon.RazorLib.ComponentRenderers.Types;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.BackgroundTaskCase;

public partial class BackgroundTaskDisplay : ComponentBase, IBackgroundTaskDisplayRendererType
{
    [Parameter, EditorRequired]
    public IBackgroundTask BackgroundTask { get; set; } = null!;
}