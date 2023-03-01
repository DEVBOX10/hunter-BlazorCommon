using BlazorCommon.RazorLib.Store.ThemeCase;
using Fluxor;

namespace BlazorCommon.RazorLib.Theme;

public interface IThemeRecordsCollectionService
{
    public IState<ThemeRecordsCollection> ThemeRecordsCollectionWrap { get; }
    
    public void RegisterThemeRecord(ThemeRecord themeRecord);
    public void DisposeThemeRecord(ThemeKey themeKey);
}