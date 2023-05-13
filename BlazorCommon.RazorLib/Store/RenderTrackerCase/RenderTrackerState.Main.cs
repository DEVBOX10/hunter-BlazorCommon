using BlazorCommon.RazorLib.RenderTracker;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
