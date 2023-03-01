using BlazorCommon.RazorLib.Store.ApplicationOptions;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Options;

public partial class InputAppFontSize : ComponentBase, IDisposable
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
    public int FontSizeInPixels
    {
        get => AppOptionsService.AppOptionsStateWrap.Value.Options.FontSizeInPixels ??
               AppOptionsState.MINIMUM_FONT_SIZE_IN_PIXELS;
        set
        {
            if (value < AppOptionsState.MINIMUM_FONT_SIZE_IN_PIXELS)
                value = AppOptionsState.MINIMUM_FONT_SIZE_IN_PIXELS;
            
            AppOptionsService.SetFontSize(value);
        }
    }

    protected override void OnInitialized()
    {
        AppOptionsService.AppOptionsStateWrap.StateChanged += AppOptionsStateWrapOnStateChanged;
        
        base.OnInitialized();
    }

    private void AppOptionsStateWrapOnStateChanged(object? sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        AppOptionsService.AppOptionsStateWrap.StateChanged -= AppOptionsStateWrapOnStateChanged;
    }
}