namespace BlazorCommon.RazorLib.Theme;

public record ImmutableThemeServiceOptions(
        ThemeKey InitialThemeKey)
    : IThemeServiceOptions;