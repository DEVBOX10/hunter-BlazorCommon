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
    private ExtensionInitializersCollection ExtensionInitializersCollection { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            AppOptionsService.SetActiveThemeRecordKey(
                BlazorCommonOptions.InitialThemeKey,
                false);

            await AppOptionsService.SetFromLocalStorageAsync();

            foreach (var extensionInitializer in ExtensionInitializersCollection)
            {
                await extensionInitializer.InitializeAsync
                    .Invoke();
            }
        }
        
        await base.OnAfterRenderAsync(firstRender);
    }
}