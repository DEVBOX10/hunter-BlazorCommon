namespace BlazorCommon.RazorLib.Theme;

public class ThemeServiceOptions : IThemeServiceOptions
{
    public ThemeKey InitialThemeKey { get; set; } = ThemeFacts
        .VisualStudioDarkThemeClone
        .ThemeKey;
}