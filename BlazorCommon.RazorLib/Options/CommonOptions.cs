using BlazorCommon.RazorLib.Theme;

namespace BlazorCommon.RazorLib.Options;

public record CommonOptions(
    int? FontSizeInPixels,
    int? IconSizeInPixels,
    ThemeKey? ThemeKey);
    