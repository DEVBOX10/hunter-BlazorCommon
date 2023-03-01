namespace BlazorCommon.RazorLib.Theme;

public static class ThemeFacts
{
    public static readonly ThemeRecord VisualStudioLightThemeClone = new ThemeRecord(
        new ThemeKey(Guid.Parse("3ea6a4a5-02b3-4b84-9d6f-e663465d3126")),
        "Visual Studio Light Clone",
        "bcrl_visual-studio-light-theme-clone",
        ThemeContrastKind.Default,
        ThemeColorKind.Light);
    
    public static readonly ThemeRecord VisualStudioDarkThemeClone = new ThemeRecord(
        new ThemeKey(Guid.Parse("8eaabd97-186d-40d0-a57b-5fec1c158902")),
        "Visual Studio Dark Clone",
        "bcrl_visual-studio-dark-theme-clone",
        ThemeContrastKind.Default,
        ThemeColorKind.Dark);
}