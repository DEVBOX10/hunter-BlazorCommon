using BlazorCommon.RazorLib.RenderTracker;

namespace BlazorCommon.RazorLib.Store.RenderTrackerCase;

public partial class RenderTrackerState
{
    public record RegisterAction(RenderTrackerObject RenderTrackerObject);
    public record DisposeAction(string RenderTrackerObjectDisplayName);
    public record AddEntryAction(string RenderTrackerObjectDisplayName, RenderTrackerEntry RenderTrackerEntry);
}
