using System.Collections.Immutable;
using BlazorCommon.RazorLib.Theme;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Options;

public partial class InputAppTheme : IDisposable
{
    [Inject]
    private IThemeRecordsCollectionService ThemeRecordsCollectionService { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

    [Parameter]
    public string InputElementCssClass { get; set; } = string.Empty;
    
    protected override void OnInitialized()
    {
        ThemeRecordsCollectionService.ThemeRecordsCollectionWrap.StateChanged += ThemeStateWrapOnStateChanged;
        
        base.OnInitialized();
    }

    private void ThemeStateWrapOnStateChanged(object? sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
    
    private void OnThemeSelectChanged(ChangeEventArgs changeEventArgs)
    {
        if (changeEventArgs.Value is null)
            return;

        var themeState = ThemeRecordsCollectionService.ThemeRecordsCollectionWrap.Value;
        
        var guidAsString = (string)changeEventArgs.Value;

        if (Guid.TryParse(guidAsString, out var guidValue))
        {
            var existingThemeRecord = themeState.ThemeRecordsList
                .FirstOrDefault(btr => btr.ThemeKey.Guid == guidValue);

            if (existingThemeRecord is not null)
                AppOptionsService.SetActiveThemeRecordKey(existingThemeRecord.ThemeKey);
        }
    }
 
    private bool CheckIsActiveValid(
        ImmutableList<ThemeRecord> themeRecordsList, 
        ThemeKey activeThemeKey)
    {
        return themeRecordsList.Any(
            btr => 
                btr.ThemeKey == activeThemeKey);
    }
    
    private bool CheckIsActiveSelection(
        ThemeKey themeKey, 
        ThemeKey activeThemeKey)
    {
        return themeKey == activeThemeKey;
    }
    
    public void Dispose()
    {
        ThemeRecordsCollectionService.ThemeRecordsCollectionWrap.StateChanged -= ThemeStateWrapOnStateChanged;
    }
}