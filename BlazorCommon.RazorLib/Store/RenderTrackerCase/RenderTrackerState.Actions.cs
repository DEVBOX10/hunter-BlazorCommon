using BlazorCommon.RazorLib.RenderTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCommon.RazorLib.Store.RenderTrackerCase;

public partial class RenderTrackerState
{
    public record RegisterAction(RenderTrackerObject RenderTrackerObject);
    public record DisposeAction(string RenderTrackerObjectDisplayName);
    public record AddEntryAction(string RenderTrackerObjectDisplayName, RenderTrackerEntry RenderTrackerEntry);
}
