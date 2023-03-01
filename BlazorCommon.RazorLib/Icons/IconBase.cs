using BlazorCommon.RazorLib.Store.ApplicationOptions;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Icons;

public class IconBase : FluxorComponent
{
    [Inject]
    private IState<AppOptionsState> AppOptionsStateWrap { get; set; } = null!;
    
    [CascadingParameter(Name="BlazorCommonIconWidthOverride")]
    public int? BlazorCommonIconWidthOverride { get; set; }
    [CascadingParameter(Name="BlazorCommonIconHeightOverride")]
    public int? BlazorCommonIconHeightOverride { get; set; }

    [Parameter]
    public string CssStyleString { get; set; } = string.Empty;

    public int WidthInPixels =>
        BlazorCommonIconWidthOverride ?? 
        AppOptionsStateWrap.Value.Options.IconSizeInPixels ??
        AppOptionsState.MINIMUM_ICON_SIZE_IN_PIXELS;
    
    public int HeightInPixels =>
        BlazorCommonIconHeightOverride ??
        AppOptionsStateWrap.Value.Options.IconSizeInPixels ??
        AppOptionsState.MINIMUM_ICON_SIZE_IN_PIXELS;
}