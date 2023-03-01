namespace BlazorCommon.RazorLib.Theme;

public interface IThemeServiceOptions
{
    /// <summary>
    /// The <see cref="ThemeKey"/> to be used when the application starts
    /// </summary>
    public ThemeKey InitialThemeKey { get; }
}