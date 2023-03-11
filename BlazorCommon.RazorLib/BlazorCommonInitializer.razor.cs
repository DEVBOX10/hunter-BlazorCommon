using BlazorCommon.RazorLib.Options;
using BlazorCommon.RazorLib.Theme;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib;

public partial class BlazorCommonInitializer : ComponentBase
{
    [Inject]
    private BlazorCommonOptions BlazorCommonOptions { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            AppOptionsService.SetActiveThemeRecordKey(
                BlazorCommonOptions.InitialThemeKey,
                false);

            await AppOptionsService.SetFromLocalStorageAsync();
        }
        
        await base.OnAfterRenderAsync(firstRender);
    }
}