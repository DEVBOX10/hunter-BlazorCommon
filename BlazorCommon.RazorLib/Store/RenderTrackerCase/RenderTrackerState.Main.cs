using BlazorCommon.RazorLib.RenderTracker;
using Fluxor;
using System.Collections.Immutable;

namespace BlazorCommon.RazorLib.Store.RenderTrackerCase;

[FeatureState]
public partial class RenderTrackerState
{
    private RenderTrackerState()
    {
        Map = ImmutableDictionary<string, RenderTrackerObject>.Empty;
    }
    
    private RenderTrackerState(ImmutableDictionary<string, RenderTrackerObject> map)
    {
        Map = map;
    }

    public ImmutableDictionary<string, RenderTrackerObject> Map { get; }
}
