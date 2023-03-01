using BlazorCommon.RazorLib.Theme;

namespace BlazorCommon.RazorLib.Store.ThemeCase;

public partial class ThemeRecordsCollection
{
    public record RegisterAction(ThemeRecord ThemeRecord);
    public record DisposeAction(ThemeKey ThemeKey);
}