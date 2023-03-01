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
    [Inject]
    private IThemeRecordsCollectionService ThemeRecordsCollectionService { get; set; } = null!;
    [Inject]
    private IThemeServiceOptions ThemeServiceOptions { get; set; } = null!;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            AppOptionsService.SetActiveThemeRecordKey(
                ThemeServiceOptions.InitialThemeKey,
                false);

            AppOptionsService.SetFromLocalStorageAsync();
        }
        
        base.OnAfterRender(firstRender);
    }
}